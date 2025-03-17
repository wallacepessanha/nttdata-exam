using FluentValidation.Results;
using MediatR;
using NTTData.Core.CommunicationResponse;
using NTTData.Core.Messages;

namespace NTTData.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }

        public async Task<TResponse> SendQuery<TResponse>(IRequest<TResponse> request) where TResponse : BaseDTO
        {
            return await _mediator.Send(request);
        }

        public async Task PublishEvent<T>(T @event) where T : Event
        {
            await _mediator.Publish(@event);
        }
    }
}
