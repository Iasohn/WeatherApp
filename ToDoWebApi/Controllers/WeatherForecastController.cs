using Microsoft.AspNetCore.Mvc;
using ToDoWebApi.Sevices;

namespace ToDoWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ServiceForAPI _serviceForAPI;

        public WeatherForecastController(ServiceForAPI serviceForAPI)
        {
            _serviceForAPI = serviceForAPI;
        }

        [HttpGet]

        public async Task<IActionResult> GetWeather(string Town)
        {
            try
            {
                var Temperature = await _serviceForAPI.GetWeatherApi(Town);
                return Ok(Temperature);
            }
            catch (Exception ex) {
                throw new Exception("Error -" + ex);
            }
        }


    }
}
