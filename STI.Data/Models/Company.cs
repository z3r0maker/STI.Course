using System;
using System.Collections.Generic;
using System.Text;

namespace STI.Data.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }
    }
}
