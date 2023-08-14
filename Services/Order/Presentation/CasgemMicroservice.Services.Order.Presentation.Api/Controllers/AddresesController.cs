using CasgemMicroservices.Order.Core.Application.Features.CQRS.Commands;
using CasgemMicroservices.Order.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Order.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddresesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddresesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAddressList()
        {
            var values = await _mediator.Send(new GetAllAddressQueryRequest());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AddressGetById(int id)
        {
            var values = await _mediator.Send(new GetByIdAddressQueryRequest(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddressCreate(CreateAddressCommandRequest createAddressCommandRequest)
        {
            await _mediator.Send(createAddressCommandRequest);
            return Ok("Adres Eklendi");
        }
        
        [HttpPut]
        public async Task<IActionResult> AddressUpdate(UpdateAddressCommandRequest updateAddressCommandRequest)
        {
            await _mediator.Send(updateAddressCommandRequest);
            return Ok("Adres güncellendi.");
        }


        [HttpDelete]
        public async Task<IActionResult> AddressDelete(int id)
        {
            await _mediator.Send(new RemoveAddressCommandRequest(id));
            return Ok("Adres Silindi");
        }
    }
}
