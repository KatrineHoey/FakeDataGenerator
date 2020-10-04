using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FakeDataGenerator.Server.Data;
using FakeDataGenerator.Server.Interfaces;
using FakeDataGenerator.Server.Services;
using FakeDataGenerator.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FakeDataGenerator.Server.Controllers
{
    [Route("api/humidity")]
    [ApiController]
    public class HumidityController : ControllerBase
    {
        private readonly IHumidityService _humidityService;
        private readonly ISensorService _sensorService;
        public HumidityController(IHumidityService humidityService, ISensorService sensorService)
        {
            _humidityService = humidityService;
            _sensorService = sensorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHumidities(Sensor sensor)
        {
            try
            {
                await _sensorService.UpdateSensor(sensor);
                return Ok(await _humidityService.CreateHumidities(sensor));
  
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        
        [HttpPost("one")]
        public async Task<IActionResult> CreateHumidity(Humidity humidity)
        {
            try
            {
                return Ok(await _humidityService.CreateHumidity(humidity));

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        [HttpDelete]
        public async Task<ActionResult> CleanDatabase()
        {
            try
            {
                return Ok(await _humidityService.CleanDatabase());
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
