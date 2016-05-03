using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Openhouse.ResponseModels
{
    public class OpenhouseListViewModel
    {
        public int ItemCount { get; set; } = 3;

        public IEnumerable<OpenhouseViewModel> Openhouses { get; set; } = new List<OpenhouseViewModel>()
        {
            new OpenhouseViewModel() {OwnerName = "Jim",RealtorName="Bob" },
            new OpenhouseViewModel() {OwnerName = "Ben",RealtorName="Kate" },
            new OpenhouseViewModel() {OwnerName = "Jill",RealtorName="John" }
        };
    }
}
