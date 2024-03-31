using Ardalis.Result;
using Ardalis.SharedKernel;
using FastEndpoints;
using MediatR;
using PruebaTecnicaCRUD.Persons;
using PruebaTecnicaCRUD.Core.PersonAggregate;
using PruebaTecnicaCRUD.UseCases.Person.Update;

namespace PruebaTecnicaCRUD.Persons;

/// <summary>
/// Update an existing Persons.
/// </summary>
/// <remarks>
/// Update an existing person
/// </remarks>
public class Update : Endpoint<UpdatePersonRequest, UpdatePersonResponse>
{
    private readonly IRepository<Person> _repository;
    private readonly IMediator _mediator;

    public Update(IRepository<Person> repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public override void Configure()
    {
        Put(UpdatePersonRequest.Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(
      UpdatePersonRequest request,
      CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UpdatePersonCommand(request.PersonId, request.Name!, request.LastName!, request.Identification, request.Email, request.Phone, request.Address));

        if (result.Status == ResultStatus.NotFound)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        // TODO: Use Mediator
        var existingPerson = await _repository.GetByIdAsync(request.PersonId, cancellationToken);
        if (existingPerson == null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        if (result.IsSuccess)
        {
            var dto = result.Value;
            Response = new UpdatePersonResponse(new PersonRecord(dto.Id, dto.Name, dto.LastName, dto.Identification, dto.Email, dto.Phone, dto.Address, dto.Created_Date, dto.Last_Modified_Date));
            return;
        }
    }
}
