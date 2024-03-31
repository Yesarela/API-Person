using FastEndpoints;
using PruebaTecnicaCRUD.UseCases.Person.Create;
using MediatR;
using PruebaTecnicaCRUD.Persons.Creates;

namespace PruebaTecnicaCRUD.Persons;

/// <summary>
/// Create a new Person
/// </summary>
/// <remarks>
/// Creates a new Person
/// </remarks>
public class Create : Endpoint<CreatePersonRequest, CreatePersonResponse>
{
    private readonly IMediator _mediator;

    public Create(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post(CreatePersonRequest.Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.ExampleRequest = new CreatePersonRequest
            {
                Name = "Luis"
                ,
                LastName = "Diaz"
                ,
                Identification = "001-154578-9632C"
                ,
                Email = "test@gmail.com"
                ,
                Phone = "78963254"
                ,
                Address = "Managua"
            };
        });
    }

    public override async Task HandleAsync(
      CreatePersonRequest request,
      CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreatePersonCommand(request.Name!, request.LastName!, request.Identification, request.Email, request.Phone, request.Address));

        if (result.IsSuccess)
        {
            Response = new CreatePersonResponse(result.Value, request.Name!, request.LastName!, request.Identification, request.Email, request.Phone, request.Address);
            return;
        }
    }
}
