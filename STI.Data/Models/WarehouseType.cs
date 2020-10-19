using System;
using System.Collections.Generic;
using System.Text;

namespace STI.Data.Models
{
    public class WarehouseType
    {
        public int Id { get; set; }
        public string Description { get; set; }

        //NAVIGATION PROPERTIES
        public virtual List<Warehouse> Warehouses { get; set; }

    }
}
