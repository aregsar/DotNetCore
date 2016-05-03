using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Openhouse.RequestModels
{
    public class OpenhousePut
    {
        public int Id { get; set; }
        public string OwnerName { get; set; } = "Areg";
        public string RealtorName { get; set; } = "Jack";
        public string Address { get; set; } = "310 Parkwood Drive";
    }
}
