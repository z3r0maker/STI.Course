using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STI.Course.Controllers
{
    [ApiController]
    //Esta ruta tomara prescedencia para los endpoints
    [Route("api/[controller]")]
    public class WarehouseTestController : ControllerBase
    {
        //[FromRoute] Pasando un parametro

        //Se tiene que poner el nombre en el httpGet del parametro que quieren recibir por medio de la ruta
        //El metodo tiene que recibir un parametro del tipo que se le mandara en la ruta
        //El parametro tiene que tener el attributo [FromRoute] como prefijo
        //El nombre del parametro en el [HttpGet] tiene que hacer match con el parametro de [FromRoute]
        //La el parametro se manda en la ruta en este caso /api/WarehouseTest/{warehouseId},
        //lo que seria... ejemplo: /api/WarehouseTest/100
        [HttpGet("{warehouseId}")]
        public IActionResult GetWarehouseTestFromRoute([FromRoute] int warehouseId)
        {
            return Ok($"{warehouseId}");
        }



        //[FromRoute] Usando otra URL

        //Si necesitaramos un segundo metodo que su ruta sea la misma, necesitamos cambiar la ruta.
        //Para esto tenemos 2 maneras, la primera es cambiar el path en el [HttpGet] como se muestra a continuacion
        //la segunda seria quitar el [Route] del controlador y ponerlo individualmente en cada uno de los metodos
        [HttpGet("GetWarehouseTestFromRoute2/{warehouseId}")]
        public IActionResult GetWarehouseTestFromRoute2([FromRoute] int warehouseId)
        {
            return Ok($"{warehouseId}");
        }

        //[FromQuery]

        //Este es el metodo mas comun de pasar parametros entre paginas o entre apis para metodos GET
        //Para hacerlo solamente es necesario establecer un parametro con el atributo en prefijo de [FromQuery]
        //a partir de este momento la API espera que el parametro pasado en la url tenga el simbolo-> ?
        //y ademas haga match con el nombre del parametro por ejemplo:
        //ejemplo: /api/WarehouseTest?warehouseId=100
        
        [HttpGet]
        public IActionResult GetWarehouseTestFromQuery([FromQuery] int warehouseId)
        {
            return Ok($"{warehouseId}");
        }

        //[FromQuery] Multiples parametros

        //si necesitaramos multiples parametros se pueden pasar concatenando los parametros en el querystring
        //para esto se usa el operador & entonces la url quedaria algo asi /api/WarehouseTest?warehouseId=100&userId=200
        //y es necesario a cada uno de los parametros ponerle el prefijo [FromQuery]
        [HttpGet("MultipleParameters")]
        public IActionResult GetWarehouseTestFromQuery2Parameters([FromQuery] int warehouseId, [FromQuery] int userId)
        {
            return Ok($"warehouse id : {warehouseId} and userId {userId}");
        }

        //[FromBody]

        [HttpPost]
        public IActionResult AddForeCast([FromBody] WeatherForecast forecast)
        {
            string newforecast = $"I received the new forecast with date {forecast.Date}, temperature {forecast.TemperatureC}";
            return Ok(newforecast);
        }














    }
}
