using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STI.Services.Contracts;
using STI.Services.Services;

namespace STI.API.Controllers
{
    [ApiController]
    //defines the route in http
    [Route("api/[controller]")]
    public class WarehouseController : Controller
    {
        //IWarehouseService _warehouseService;

        //public WarehouseController(IWarehouseService warehouseService)
        //{
        //    _warehouseService = warehouseService;
        //}

        [HttpGet("GetWarehouses")]
        public IActionResult GetWarehouse([FromServices] IWarehouseService _warehouseService)
        {
            var warehouses = _warehouseService.GetWarehouses();
            return Ok(warehouses);
        }
    }
}
