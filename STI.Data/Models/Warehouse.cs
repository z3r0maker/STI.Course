using System;
using System.Collections.Generic;
using System.Text;

namespace STI.Data.Models
{
    public class Warehouse
    {
        //Properties
        public int Id { get; set; } //PK
        public string Name { get; set; } //Colum
        public int Region { get; set; } //Colum
        public int WarehouseTypeId { get; set; } //Colum

       


        //NAVIGATION PROPERTIES = Foreing Key
        public virtual WarehouseType WarehouseType { get; set; }

    }
}
