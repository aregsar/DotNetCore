using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Openhouse.Models
{
    public class Openhouse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string OwnerName { get; set; } 
        public string RealtorName { get; set; } 
        public string Address { get; set; } 
    }
}
