using MediatR;

namespace NTTData.Sale.API.Application.Events.Handlers
{
    public class SaleCancelledEventHandler : INotificationHandler<SaleCancelledEvent>
    {
        public Task Handle(SaleCancelledEvent notification, CancellationToken cancellationToken)
        {
            Console.Write(notification);
            return Task.CompletedTask;
        }
    }
}
