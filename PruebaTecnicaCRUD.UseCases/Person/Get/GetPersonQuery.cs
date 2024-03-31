using Ardalis.Result;
using Ardalis.SharedKernel;
using PruebaTecnicaCRUD.UseCases.Person;

namespace PruebaTecnicaCRUD.UseCases.Contributors.Get;

public record GetPersonQuery(int PersonId) : IQuery<Result<PersonDTO>>;
