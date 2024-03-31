using Ardalis.Result;
using Ardalis.SharedKernel;

namespace PruebaTecnicaCRUD.UseCases.Person.List;

public record ListPersonQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<PersonDTO>>>;
