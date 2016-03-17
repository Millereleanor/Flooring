using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models
{
    public class Order
    {
        private decimal _orderTotal;
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

        public decimal OrderTotal
        {
            get { return CostperSqFt*OrderArea + LaborperSqFt*OrderArea; }

        }

        public DateTime OrderDate { get; set; }

        public override string ToString()
        {

            return this.OrderNumber+ "," + this.FirstName+ "," + this.LastName+ "," + this.StateAbbr+ "," + this.StateFull+ "," +
                    this.TaxRate+ "," + this.ProductType+ "," + this.OrderArea+ "," + this.CostperSqFt+ "," + this.LaborperSqFt+ "," + this.TaxTotal+ "," + this.OrderTotal
        }
    }
}
