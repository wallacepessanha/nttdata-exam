using MediatR;
using NTTData.Sale.API.Application.DTO.Response;

namespace NTTData.Sale.API.Application.Queries
{
    public class GetSaleByIdQuery : IRequest<SaleResponseDTO>
    {
        public GetSaleByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }  

    }
}
