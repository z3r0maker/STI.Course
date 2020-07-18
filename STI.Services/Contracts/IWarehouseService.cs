using STI.Course.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace STI.Services.Contracts
{
    public interface IWarehouseService
    {
        IEnumerable<WarehouseDto> GetWarehouses();
        void OtherMethod();
    }
}
