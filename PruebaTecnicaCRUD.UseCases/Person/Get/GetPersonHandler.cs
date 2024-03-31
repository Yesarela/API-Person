using Ardalis.Result;
using Ardalis.SharedKernel;
using PruebaTecnicaCRUD.Core.PersonAggregate;
using PruebaTecnicaCRUD.UseCases.Contributors.Get;
using PruebaTecnicaCRUD.UseCases.Person;
using PruebaTecnicaCRUD.UseCases.Person.List;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
//using NimblePros.SampleToDo.Core.ContributorAggregate.Specifications;

namespace PruebaTecnicaCRUD.UseCases.Contributors.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetPersonHandler : IQueryHandler<GetPersonQuery, Result<PersonDTO>>
{
    private readonly IListPersonQueryService _query;

    public GetPersonHandler(IListPersonQueryService query)
    {
        _query = query;
    }

    public async Task<Result<PersonDTO>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        var result = await _query.GetByIdAsync(request.PersonId);

        var resultReturn = result.FirstOrDefault();

        return new PersonDTO(resultReturn.Id, resultReturn.Name, resultReturn.LastName, resultReturn.Identification, resultReturn.Email, resultReturn.Phone, resultReturn.Address, resultReturn.Created_Date, resultReturn.Last_Modified_Date);
    }
}
