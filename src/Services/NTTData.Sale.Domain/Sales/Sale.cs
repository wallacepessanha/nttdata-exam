using NTTData.Core.DomainObjects;
using NTTData.Sale.Domain.Enums;

namespace NTTData.Sale.Domain.Sales
{
    public class Sale : Entity, IAggregateRoot
    {
        public Sale(Customer customer, List<ProductSaleItem> products, int number, string? branch, decimal totalSaleAmount)
        {            
            Customer = customer;
            ProductItems = products;
            Number = number;
            Branch = branch;
            TotalSaleAmount = totalSaleAmount;
            Status = SaleStatus.NotCancelled;
            CreatedAt = DateTime.Now;          
        }
        public Sale() { }

        public int Number { get; private set; }
        public decimal TotalSaleAmount { get; private set; }
        public Customer Customer { get; private set; }
        public List<ProductSaleItem> ProductItems { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public SaleStatus Status { get; private set; }
        public string? Branch { get; set; }
        public DateTime? CancelledDate { get; private set; }

        public void SetAsCancelled(DateTime? cancelledDate)
        {
            CancelledDate = cancelledDate;
            Status = SaleStatus.Cancelled;
        }

        public void SetAsNotCancelled()
        {
            Status = SaleStatus.NotCancelled;
        }

        public void CalculateTotalSaleAmount()
        {
            TotalSaleAmount = ProductItems.Where(x=> x.Status != ProductItemEnum.Cancelled).Sum(p => p.CalculateTotal());            
        }        
    }
}
