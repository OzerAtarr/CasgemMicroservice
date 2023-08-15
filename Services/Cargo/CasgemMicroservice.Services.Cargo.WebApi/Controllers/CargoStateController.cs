using CasgemMicroservice.Services.Cargo.BusinessLayer.Abstract;
using CasgemMicroservice.Services.Cargo.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoStateController : ControllerBase
    {
        private readonly ICargoStateService _cargoStateService;

        public CargoStateController(ICargoStateService cargoStateService)
        {
            _cargoStateService = cargoStateService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoStateService.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult CargoDetailGet(int id)
        {
            var value = _cargoStateService.GetById(id);
            return Ok(value);
        }


        [HttpPost]
        public IActionResult CargoDetailCreate(CargoState cargoState)
        {
            _cargoStateService.Insert(cargoState);
            return Ok("Kargo Durumu Eklendi");
        }


        [HttpPut]
        public IActionResult CargoDetailUpdate(CargoState cargoState)
        {
            _cargoStateService.Update(cargoState);
            return Ok("Kargo Durumu Güncellendi");
        }

        [HttpDelete]
        public IActionResult CargoDetailDelete(CargoState cargoState)
        {
            _cargoStateService.Delete(cargoState);
            return Ok("Kardo Durumu Silindi");
        }
    }
}
