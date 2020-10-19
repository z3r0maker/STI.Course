using System;
using System.Collections.Generic;
using System.Text;

namespace STI.DTOs
{
    public class ReportDto
    {
        public string CompanyName { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseTypeName { get; set; }

        public string OtherID { get; set; }
        public string WarehouseFixedName { get; set; }

        public string Calculo { get; set; }
    }
}
