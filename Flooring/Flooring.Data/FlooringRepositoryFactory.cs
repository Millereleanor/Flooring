using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public static class FlooringRepositoryFactory
    {
        public static IFloorRepository CreateFloorRepository(string type)
        {
            //TODO: THIS
            return new FloorRepository();
        }
    }
}