using NTTData.Core.Messages;

namespace NTTData.Sale.API.Application.Events
{
    public class SaleCreatedEvent : Event
    {
        public SaleCreatedEvent(Guid saleId, string? custumerEmail, int saleNumber)
        {
            SaleId = saleId;
            CustumerEmail = custumerEmail;
            SaleNumber = saleNumber;
        }

        public Guid SaleId { get; private set; }
        public string? CustumerEmail { get; private set; }
        public int SaleNumber { get; set; }
    }
}
