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
        public HumidityController(IHumidityService humidityService)
        {
            _humidityService = humidityService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHumidities([FromBody] int on)
        {
            try
            {
                bool isOn;
                if (on == 1) isOn = true;
                else isOn = false;

                return Ok(await _humidityService.CreateHumidities(isOn));

                
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
