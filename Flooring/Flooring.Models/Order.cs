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
        public decimal TaxTotal
        {
            get { return this.TaxRate*this.OrderTotal; }
        } 
        public decimal OrderTotal { get; set; } //todo: set OrderTotal get return to calculate total
        public DateTime OrderDate { get; set; }
    }
}
