using MediatR;

namespace NTTData.Sale.API.Application.Events.Handlers
{
    public class SaleItemCancelledEventHandler : INotificationHandler<SaleItemCancelledEvent>
    {
        public Task Handle(SaleItemCancelledEvent notification, CancellationToken cancellationToken)
        {
            Console.Write(notification);
            return Task.CompletedTask;
        }
    }
}
