using Ardalis.Result;
using Ardalis.SharedKernel;
using PruebaTecnicaCRUD.Core.PersonAggregate;

namespace PruebaTecnicaCRUD.UseCases.Person.Update;

public class UpdatePersonHandler : ICommandHandler<UpdatePersonCommand, Result<PersonDTO>>
{
    private readonly IRepository<Core.PersonAggregate.Person> _repository;

    public UpdatePersonHandler(IRepository<Core.PersonAggregate.Person> repository)
    {
        _repository = repository;
    }

    public async Task<Result<PersonDTO>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var existingPerson = await _repository.GetByIdAsync(request.PersonId, cancellationToken);
        if (existingPerson == null)
        {
            return Result.NotFound();
        }

        existingPerson.UpdateName(request.NewName!, request.NewLastname!, request.NewIdentification!, request.NewEmail, request.NewPhone, request.NewAddress);

        await _repository.UpdateAsync(existingPerson, cancellationToken);

        return Result.Success(new PersonDTO(existingPerson.id_person, existingPerson.Name, existingPerson.Lastname, existingPerson.Identification, existingPerson.Email, existingPerson.Phone, existingPerson.Address, existingPerson.Created_Date, existingPerson.Last_Modified_Date));
    }
}
