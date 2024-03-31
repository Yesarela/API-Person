using Ardalis.Result;
using Ardalis.SharedKernel;
using PruebaTecnicaCRUD.Core.PersonAggregate;

namespace PruebaTecnicaCRUD.UseCases.Person.Create;

public class CreatePersonHandler : ICommandHandler<CreatePersonCommand, Result<int>>
{
    private readonly IRepository<Core.PersonAggregate.Person> _repository;

    public CreatePersonHandler(IRepository<Core.PersonAggregate.Person> repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(CreatePersonCommand request,
      CancellationToken cancellationToken)
    {
        var newPerson = new Core.PersonAggregate.Person(request.Name, request.lastname, request.identification, request.email, request.phone, request.address);
        var createdItem = await _repository.AddAsync(newPerson, cancellationToken);

        return createdItem.id_person;
    }
}
