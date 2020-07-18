using STI.Course.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace STI.DTOs
{
    class WarehouseCompleteRelationDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<object> Companies { get; set; }

    }
}
