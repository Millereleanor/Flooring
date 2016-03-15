using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models
{
   public class Order
    {
        public int OrderNumber { get; set; }
        public int OrderArea { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProductType { get; set; }
        public string StateAbbr { get; set; }
        public string StateFull { get; set; }
        public decimal CostperSqFt { get; set; }
        public decimal LaborperSqFt { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal OrderTotal { get; set; }
       
        public DateTime OrderDate { get; set; }
    }
}
