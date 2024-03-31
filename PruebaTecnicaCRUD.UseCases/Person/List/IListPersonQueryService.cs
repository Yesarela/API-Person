using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaCRUD.UseCases.Person.List
{
    public interface IListPersonQueryService
    {
        Task<IEnumerable<PersonDTO>> ListAsync();
        Task<IEnumerable<PersonDTO>> GetByIdAsync(int id);
    }

}
