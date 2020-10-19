using Microsoft.EntityFrameworkCore;
using STI.Course.DTO;
using STI.Data;
using STI.Data.Models;
using STI.DTOs;
using STI.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STI.Services.Services
{
    public class WarehouseService : IWarehouseService
    {
        IUserService _userService;
        STIContext _context;

        public WarehouseService(IUserService userService, STIContext context)
        {
            _userService = userService;
            _context = context;
        }
        public IEnumerable<Warehouse> GetWarehouses()
        {
            //TODO: arreglar este codigo porque regreso[]
            var warehouses = _context.Warehouse.Where(t => t.Id != 0).Include(t=> t.WarehouseType);
            var x = warehouses.ToList();
            return warehouses;

        }

        //Agregar a la BD

        //Actualizar a la BD

        //Eliminar de la BD 

        public IEnumerable<WarehouseType> GetWarehousesTypes()
        {
            var warehouseTypes = _context.WarehouseType.Where(t => t.Id != 0);
            return warehouseTypes;
            //return warehouseTypes.AsEnumerable();
        }

        public void OtherMethod()
        {
            throw new NotImplementedException();
        }
    }
}
