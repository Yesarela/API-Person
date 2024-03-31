using Ardalis.Result;
using FastEndpoints;
using MediatR;
using PruebaTecnicaCRUD.UseCases.Contributors.Get;

namespace PruebaTecnicaCRUD.Persons.GetById
{
    public class GetById : Endpoint<GetPersonByIdRequest, PersonRecord>
    {
        private readonly IMediator _mediator;

        public GetById(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get(GetPersonByIdRequest.Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetPersonByIdRequest request,
          CancellationToken cancellationToken)
        {
            var command = new GetPersonQuery(request.PersonId);

            var result = await _mediator.Send(command);

            if (result.Status == ResultStatus.NotFound)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }

            if (result.IsSuccess)
            {
                Response = new PersonRecord(result.Value.Id, result.Value.Name, result.Value.LastName, result.Value.Identification, result.Value.Email, result.Value.Phone
                , result.Value.Address, result.Value.Created_Date, result.Value.Last_Modified_Date);
            }
        }
    }
}
