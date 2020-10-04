using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeDataGenerator.Server.Interfaces;
using FakeDataGenerator.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeDataGenerator.Server.Controllers
{
    [Route("api/Sensor")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly ISensorService _sensorService;
        public SensorController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSensors()
        {
            try
            {
                var list = await _sensorService.GetSensors();
                return Ok(list);

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSensor(int id)
        {
            try
            {
                var model = await _sensorService.GetSensor(id);
                return Ok(model);

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateSensor(Sensor sensor)
        {
            try
            {
                var id = await _sensorService.CreateSensor(sensor);
                return Ok(id);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSensor(Sensor sensor)
        {
            try
            {
                await _sensorService.UpdateSensor(sensor);
                return Ok();

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensor(int id)
        {
            try
            {
                await _sensorService.DeleteSensor(id);
                return Ok();

            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
