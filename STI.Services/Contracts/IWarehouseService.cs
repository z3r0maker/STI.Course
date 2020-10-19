using STI.Course.DTO;
using STI.Data.Models;
using STI.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace STI.Services.Contracts
{
    public interface IWarehouseService
    {
        IEnumerable<Warehouse> GetWarehouses();
        IEnumerable<WarehouseType> GetWarehousesTypes();
        void OtherMethod();
    }
}
