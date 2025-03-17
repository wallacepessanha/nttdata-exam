using NTTData.Core.DomainObjects;
using NTTData.Sale.Domain.Enums;
using System.Net.NetworkInformation;

namespace NTTData.Sale.Domain.Sales
{
    public class ProductSaleItem : Entity
    {
        public ProductSaleItem(int quantity, decimal unitPrice, string? productName)
        {
            Quantity = quantity;
            UnitPrice = unitPrice;
            ProductName = productName;
            TotalAmount = Quantity * unitPrice;
            Status = ProductItemEnum.NotCancelled;
        }

        public Guid SaleId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount => Quantity > 4 && Quantity < 10 ? 10 : 20;
        public decimal TotalAmount { get; private set; }
        public string? ProductName { get; private set; }
        public ProductItemEnum Status { get; private set; }
        public DateTime? CancelledDate { get; private set; }

        // EF Rel.
        public Domain.Sales.Sale Sale { get; set; }

        public decimal CalculateTotal()
        {
            var desconto = (TotalAmount * Discount) / 100;
            TotalAmount -= desconto;
            return TotalAmount;
        }

        public void SetAsCancelled(DateTime? cancelledDate)
        {
            CancelledDate = cancelledDate;
            Status = ProductItemEnum.Cancelled;
        }

        public void SetAsNotCancelled()
        {
            Status = ProductItemEnum.NotCancelled;
        }
    }
}
