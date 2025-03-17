using NTTData.Core.DomainObjects;

namespace NTTData.Sale.Domain.Sales
{
    public class Customer
    {
        public Customer(string fullName, string email)
        {            
            FullName = fullName;
            Email = email;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
    }
}
