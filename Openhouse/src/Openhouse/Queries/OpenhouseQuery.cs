using Openhouse.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Openhouse.Queries
{
    public class OpenhouseQuery
    {
        public OpenhouseListViewModel GetOpenhouses()
        {
            return new OpenhouseListViewModel();
        }

        public OpenhouseViewModel GetOpenhouse(int id)
        {
            return new OpenhouseViewModel();
        }
    }
}
