using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLSampleAPI.Data.Interfaces;
using GraphQLSampleAPI.Models;
using GraphQLSampleAPI.UnitOfWorkPattern;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GraphQLSampleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICosmosCarRepository cosmosCarRepository;
        private readonly IUnitOfWork unitOfWork;

        public CarController(ICosmosCarRepository cosmosCarRepository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.cosmosCarRepository = cosmosCarRepository;
        }

        [HttpGet("GetCarById/{id}")]
        public async Task<IActionResult> GetCarById(string id)
        {
            return Ok(await cosmosCarRepository.GetById(id));
        }

        [HttpGet("GetAllCars")]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok(await cosmosCarRepository.GetAll());
        }

        [HttpPost("AddCar")]
        public async Task<IActionResult> AddCar(Gadget car)
        {
            var response = await unitOfWork.CosmosGadgetRepository.Add(car);
            return Ok(response);
        }
        // [HttpPut]
        // public async Task<IActionResult> GetAllCars()
        // {
        //     return await cosmosCarRepository.GetAll();
        // }
        // [HttpPost]
        // public async Task<IActionResult> GetAllCars()
        // {
        //     return await cosmosCarRepository.GetAll();
        // }
        // [HttpPost]
        // public async Task<IActionResult> GetAllCars()
        // {
        //     return await cosmosCarRepository.GetAll();
        // }

    }
}
