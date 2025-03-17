using MediatR;

namespace NTTData.Sale.API.Application.Events.Handlers
{
    public class SaleCreatedEventHandler : INotificationHandler<SaleCreatedEvent>
    {
        public Task Handle(SaleCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.Write(notification);
            return Task.CompletedTask;
        }
    }
}
