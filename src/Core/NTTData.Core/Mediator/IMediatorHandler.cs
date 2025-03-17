using FluentValidation.Results;
using MediatR;
using NTTData.Core.CommunicationResponse;
using NTTData.Core.Messages;


namespace NTTData.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
        Task<TResponse> SendQuery<TResponse>(IRequest<TResponse> request) where TResponse : BaseDTO;
    }
}
