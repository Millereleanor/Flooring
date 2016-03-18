using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;

namespace Flooring.Data
{
    public class ReadStateProduct
    {

        public List<State> GetStatefromTxt()
        {

            string f = "Taxes.txt";
            List<State> states = new List<State>();

            var reader = File.ReadAllLines(f);
            using (StreamReader r = new StreamReader(f))
            {
                string line;
                    for (int i = 1; i < reader.Length; i++)
                    {
                        var newState = new State();
                        var columns = reader[i].Split(',');
                        newState.Abbr = columns[0];
                        newState.FullName = columns[1];
                        newState.TaxRate = decimal.Parse(columns[2]);
                        states.Add(newState);
                    
                }
            }
            return states;
        }
    

    public List<Product> GetProductfromTxt()
        {

            string f = "Products.txt";
            List<Product> products = new List<Product>();

            var reader = File.ReadAllLines(f);
            using (StreamReader r = new StreamReader(f))
            {
                string line;
                    for (int i = 1; i < reader.Length; i++)
                    {
                        var newProduct = new Product();
                        var columns = reader[i].Split(',');
                        newProduct.ProductType = columns[0];
                        newProduct.CostperSqFt = decimal.Parse(columns[1]);
                        newProduct.LaborperSqFt = decimal.Parse(columns[2]);
                        products.Add(newProduct);
                    }
                
            }
        return products;
        }
    }
}
