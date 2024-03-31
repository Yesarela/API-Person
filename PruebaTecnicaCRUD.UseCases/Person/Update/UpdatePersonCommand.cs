using Ardalis.Result;
using Ardalis.SharedKernel;

namespace PruebaTecnicaCRUD.UseCases.Person.Update;

public record UpdatePersonCommand(int PersonId, string NewName, string NewLastname, string NewIdentification, string NewEmail, string NewPhone, string NewAddress) : ICommand<Result<PersonDTO>>;
