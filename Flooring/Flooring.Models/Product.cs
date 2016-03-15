using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models
{
    public class Product
    {
        public string ProductType { get; set; }
        public decimal CostperSqFt { get; set; }
        public decimal LaborperSqFt { get; set; }
    }
}
