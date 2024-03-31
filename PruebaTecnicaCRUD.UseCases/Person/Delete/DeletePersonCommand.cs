using Ardalis.Result;
using Ardalis.SharedKernel;

namespace PruebaTecnicaCRUD.UseCases.Person.Delete;

public record DeletePersonCommand(int PersonId) : ICommand<Result>;
