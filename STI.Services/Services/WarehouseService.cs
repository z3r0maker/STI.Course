using STI.Course.DTO;
using STI.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace STI.Services.Services
{
    public class WarehouseService : IWarehouseService
    {
        IUserService _userService;

        public WarehouseService(IUserService userService)
        {
            _userService = userService;
        }
        public IEnumerable<WarehouseDto> GetWarehouses()
        {
            return new List<WarehouseDto>() {
             new WarehouseDto()
              {
                  Id = 1,
                   Name = "Almacen 1",
                   Region = 3,
                   UserName = _userService.GetDefaultUser()
              },
             new WarehouseDto()
              {
                  Id = 2,
                   Name = "Almacen 2",
                   Region = 2,
                   UserName = _userService.GetDefaultUser()
              }
          };
        }

        public void OtherMethod()
        {
            throw new NotImplementedException();
        }
    }
}
