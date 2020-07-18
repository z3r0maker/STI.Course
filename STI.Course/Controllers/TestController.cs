using Microsoft.AspNetCore.Mvc;
using STI.Course.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STI.Course.Controllers
{
    //Defines an Api controller
    [ApiController]
    //defines the route in http
    [Route("api/[controller]")]
    //inherit from controllerbase
    public class TestController : ControllerBase
    {
        [HttpGet("HolaMundo")]
        public IActionResult GetWarehouse()
        {
            return Ok("Hola Mundo");
        }

        [HttpGet("HolaMundo2")]
        public IActionResult GetWarehouse2()
        {
            return Ok("Hola Mundo 2");
        }


        //[FromRoute] Pasando un parametro

        //Se tiene que poner el nombre en el httpGet del parametro que quieren recibir por medio de la ruta
        //El metodo tiene que recibir un parametro del tipo que se le mandara en la ruta
        //El parametro tiene que tener el attributo [FromRoute] como prefijo
        //El nombre del parametro en el [HttpGet] tiene que hacer match con el parametro de [FromRoute]
        //La el parametro se manda en la ruta en este caso /api/GetWarehouse/{warehouseId},
        //lo que seria... ejemplo: /api/Test/GetWarehouse/100
        [HttpGet("GetWarehouse/{warehouseId}/{userId}")]
        public IActionResult GetWarehouseById([FromRoute] int warehouseId, [FromRoute] string UserId)
        {
            //string interpolation
            return Ok($"Warehouse id {warehouseId} and UserId {UserId}");
            //return Ok("Warehouse id" + warehouseId + "and UserId" + UserId);
        }


        //Este es el metodo mas comun de pasar parametros entre paginas o entre apis para metodos GET
        //Para hacerlo solamente es necesario establecer un parametro con el atributo en prefijo de [FromQuery]
        //a partir de este momento la API espera que el parametro pasado en la url tenga el simbolo-> ?
        //y ademas haga match con el nombre del parametro por ejemplo:
        //ejemplo: /api/Test/GetWarehouseByName?warehouseName=MiAlmacen
        [HttpGet("GetWarehouseByName")]
        public IActionResult GetWarehouseByName([FromQuery] string warehouseName)
        {
            return Ok(warehouseName);
        }

        //[FromQuery] Multiples parametros

        //si necesitaramos multiples parametros se pueden pasar concatenando los parametros en el querystring
        //para esto se usa el operador & entonces la url quedaria algo asi /api/Test/GetWarehouseByNameAndId?warehouseName=MiAlmacen&warehouseId=200
        //y es necesario a cada uno de los parametros ponerle el prefijo [FromQuery]
        [HttpGet("GetWarehouseByNameAndId")]
        public IActionResult GetWarehouseByName([FromQuery] string warehouseName, [FromQuery] int warehouseId)
        {
            return Ok($"{warehouseName} {warehouseId}");
        }

        [HttpPost("CreateWarehouse")]
        public IActionResult CreateWarehouse([FromBody] WarehouseDto warehouse)
        {
            return Ok(warehouse);
        }
    }
}
