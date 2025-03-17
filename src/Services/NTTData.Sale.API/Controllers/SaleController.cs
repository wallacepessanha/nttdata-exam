using Microsoft.AspNetCore.Mvc;
using NTTData.Core.Mediator;
using NTTData.Sale.API.Application.Commands;
using NTTData.Sale.API.Application.Queries;

namespace NTTData.Sale.API.Controllers
{
    [Route("api/sales")]
    public class SaleController : BaseController
    {
        private readonly IMediatorHandler _mediator;
        public SaleController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("sale")]
        public async Task<IActionResult> Add(SaleCreatedCommand sale)
        {            
            return CustomResponse(await _mediator.SendCommand(sale));
        }

        [HttpPost("sale-cancel")]
        public async Task<IActionResult> Cancel(SaleCancelledCommand sale)
        {
            return CustomResponse(await _mediator.SendCommand(sale));
        }

        [HttpPost("item-cancel")]
        public async Task<IActionResult> CancelItem(SaleItemCancelledCommand sale)
        {
            return CustomResponse(await _mediator.SendCommand(sale));
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetSaleByIdQuery(id);

            return CustomResponse(await _mediator.SendQuery(query));
        }

    }
}
