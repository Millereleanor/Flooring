using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class FlooringRepositoryFactory
    {
        public static IFloorRepository CreateFloorRepository(string path)
        {
            switch (path)
            {
                case "DataFiles\\":
                    return new FloorRepository();
                default:
                    return new MockFloorRepository();

            }
        }
    }
}