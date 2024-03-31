using Ardalis.Result;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaCRUD.UseCases.Person;
using PruebaTecnicaCRUD.UseCases.Person.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaCRUD.Infrastructure.Data.Queries;

public class ListPersonsQueryService : IListPersonQueryService
{
    // You can use EF, Dapper, SqlClient, etc. for queries
    private readonly AppDbContext _db;

    public ListPersonsQueryService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<PersonDTO>> ListAsync()
    {
        var result = await _db.Person.Select(c =>
                    new PersonDTO(
                         c.id_person
                        , c.Name
                        , c.Lastname
                        , c.Identification!
                        , c.Email!
                        , c.Phone!
                        , c.Address!
                        , c.Created_Date
                        , c.Last_Modified_Date
                        )
                    )
        .ToListAsync();

        return result;
    }

    public async Task<IEnumerable<PersonDTO>> GetByIdAsync(int id)
    {
        try
        {
            var result = await _db.Person.Where(p => p.id_person == id).Select(c =>
                  new PersonDTO(
                       c.id_person
                      , c.Name
                      , c.Lastname
                      , c.Identification
                      , c.Email
                      , c.Phone
                      , c.Address
                      , c.Created_Date
                      , c.Last_Modified_Date
                      )
                  ).ToListAsync();


            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return null;
        }

    }

}

