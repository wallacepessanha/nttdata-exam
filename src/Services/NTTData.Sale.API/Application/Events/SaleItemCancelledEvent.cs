using NTTData.Core.Messages;

namespace NTTData.Sale.API.Application.Events
{
    public class SaleItemCancelledEvent : Event
    {
        public SaleItemCancelledEvent(Guid saleId, Guid productItemId, string? custumerEmail, int saleNumber)
        {
            SaleId = saleId;
            ProductItemId = productItemId;
            CustumerEmail = custumerEmail;
            SaleNumber = saleNumber;
        }

        public Guid SaleId { get; private set; }
        public Guid ProductItemId { get; private set; }
        public string? CustumerEmail { get; private set; }
        public int SaleNumber { get; set; }
    }
}
