using Ardalis.Result;

namespace PruebaTecnicaCRUD.UseCases.Person.Create;

/// <summary>
/// Create a new person.
/// </summary>
/// <param name="Name"></param>
public record CreatePersonCommand(string Name, string lastname, string identification, string email, string phone, string address) : Ardalis.SharedKernel.ICommand<Result<int>>;
