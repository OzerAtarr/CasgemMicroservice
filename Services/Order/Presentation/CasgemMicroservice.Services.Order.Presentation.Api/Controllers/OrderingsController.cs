using CasgemMicroservice.Shared.Services;
using CasgemMicroservices.Order.Core.Application.Features.CQRS.Commands;
using CasgemMicroservices.Order.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Order.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISharedIdentityService _sharedIdentityService;
        public OrderingsController(IMediator mediator, ISharedIdentityService sharedIdentityService = null)
        {
            _mediator = mediator;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetAllOrderingQueryRequest());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>  OrderingGetById(int id)
        {
            var value = await _mediator.Send(new GetByIdOrderingQueryRequest(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> OrderingCreate(CreateOrderingCommandRequest createOrderingCommandRequest)
        {
            await _mediator.Send(createOrderingCommandRequest);
            return Ok("Sipariş Eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> OrderingUpdate(UpdateOrderingCommandRequest updateOrderingCommandRequest)
        {
            await _mediator.Send(updateOrderingCommandRequest);
            return Ok("Sipariş Güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> OrderingDelete(int id)
        {
            await _mediator.Send(new RemoveOrderingCommandRequest(id));
            return Ok("Sipariş Silindi");
        }
        [HttpGet("orderinggetuser")]
        public async Task<IActionResult> OrderingGetUser()
        {
            var response = await _mediator.Send(new GetOrderingByUserIdQueryRequest
            {
                Id = _sharedIdentityService.GetUserID
            });
            return Ok(response);
        }
    }
}
