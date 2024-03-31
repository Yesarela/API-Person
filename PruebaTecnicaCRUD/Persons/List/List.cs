using FastEndpoints;
using MediatR;
using PruebaTecnicaCRUD.UseCases.Person.List;

namespace PruebaTecnicaCRUD.Persons.List;

/// <summary>
/// List all Persons
/// </summary>
/// <remarks>
/// List all persons - returns a PersonListResponse containing the persons.
/// </remarks>
public class List : EndpointWithoutRequest<PersonListResponse>
{
    private readonly IMediator _mediator;

    public List(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Get("/persons");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new ListPersonQuery(null, null));

        if (result.IsSuccess)
        {
            Response = new PersonListResponse
            {
                Persons = result.Value.Select(c => new PersonRecord(c.Id, c.Name, c.LastName, c.Identification, c.Email, c.Phone
                , c.Address, c.Created_Date, c.Last_Modified_Date)).ToList()
            };
        }
    }
}
