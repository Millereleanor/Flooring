using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;

namespace Flooring.Models
{
    public class MockOrders
    {
        private static List<Order> _orderList;

        public List<Order> LoadOrders()
        {
            if (_orderList == null)
            {
                _orderList =
                    new List<Order>
                    {
                        new Order
                        {
                            OrderDate = DateTime.Parse("1/1/2016"),
                            OrderNumber = 1,
                            OrderArea = 100,
                            FirstName = "John",
                            LastName = "Palazzo",
                            ProductType = "Carpet",
                            StateAbbr = "OH",
                            StateFull = "Ohio",
                            CostperSqFt = 2.25m,
                            LaborperSqFt = 2.1m,
                            TaxRate = .0625m
                        },
                        new Order
                        {
                            OrderDate = DateTime.Parse("1/1/2016"),
                            OrderNumber = 2,
                            OrderArea = 200,
                            FirstName = "Elle",
                            LastName = "Miller",
                            ProductType = "Laminate",
                            StateAbbr = "FL",
                            StateFull = "Florida",
                            CostperSqFt = 1.75m,
                            LaborperSqFt = 2.1m,
                            TaxRate = .07m
                        },
                        new Order
                        {
                            OrderDate = DateTime.Parse("1/1/2016"),
                            OrderNumber = 3,
                            OrderArea = 300,
                            FirstName = "Jeane",
                            LastName = "Hong",
                            ProductType = "Tile",
                            StateAbbr = "IN",
                            StateFull = "Indiana",
                            CostperSqFt = 3.5m,
                            LaborperSqFt = 4.15m,
                            TaxRate = .06m
                        },
                        new Order
                        {
                            OrderDate = DateTime.Parse("2/3/2016"),
                            OrderNumber = 1,
                            OrderArea = 50,
                            FirstName = "Mickey",
                            LastName = "Mouse",
                            ProductType = "Carpet",
                            StateAbbr = "OH",
                            StateFull = "Ohio",
                            CostperSqFt = 2.25m,
                            LaborperSqFt = 2.1m,
                            TaxRate = .0625m
                        },
                        new Order
                        {
                            OrderDate = DateTime.Parse("2/3/2016"),
                            OrderNumber = 1,
                            OrderArea = 150,
                            FirstName = "Donald",
                            LastName = "Duck",
                            ProductType = "Carpet",
                            StateAbbr = "OH",
                            StateFull = "Ohio",
                            CostperSqFt = 2.25m,
                            LaborperSqFt = 2.1m,
                            TaxRate = .0625m
                        },
                        new Order
                        {
                            OrderDate = DateTime.Parse("3/1/2016"),
                            OrderNumber = 1,
                            OrderArea = 100,
                            FirstName = "John",
                            LastName = "Cena",
                            ProductType = "Tile",
                            StateAbbr = "IN",
                            StateFull = "Indiana",
                            CostperSqFt = 3.5m,
                            LaborperSqFt = 4.15m,
                            TaxRate = .06m
                        },
                        new Order
                        {
                            OrderDate = DateTime.Parse("3/2/2016"),
                            OrderNumber = 1,
                            OrderArea = 100,
                            FirstName = "Homer",
                            LastName = "Simpson",
                            ProductType = "Laminate",
                            StateAbbr = "FL",
                            StateFull = "Florida",
                            CostperSqFt = 1.75m,
                            LaborperSqFt = 2.1m,
                            TaxRate = .07m
                        },
                        new Order
                        {
                            OrderDate = DateTime.Parse("3/7/2016"),
                            OrderNumber = 1,
                            OrderArea = 100,
                            FirstName = "Bobby",
                            LastName = "Sura",
                            ProductType = "Laminate",
                            StateAbbr = "FL",
                            StateFull = "Florida",
                            CostperSqFt = 1.75m,
                            LaborperSqFt = 2.1m,
                            TaxRate = .07m
                        },
                        new Order
                        {
                            OrderDate = DateTime.Parse("1/10/2016"),
                            OrderNumber = 1,
                            OrderArea = 100,
                            FirstName = "Lamond",
                            LastName = "Murrary",
                            ProductType = "Tile",
                            StateAbbr = "IN",
                            StateFull = "Indiana",
                            CostperSqFt = 3.5m,
                            LaborperSqFt = 4.15m,
                            TaxRate = .06m
                        },
                        new Order
                        {
                            OrderDate = DateTime.Parse("1/12/2016"),
                            OrderNumber = 1,
                            OrderArea = 100,
                            FirstName = "Wesley",
                            LastName = "Person",
                            ProductType = "Carpet",
                            StateAbbr = "OH",
                            StateFull = "Ohio",
                            CostperSqFt = 2.25m,
                            LaborperSqFt = 2.1m,
                            TaxRate = .0625m
                        }
                    };
        }
            return _orderList;
        }
    }
}
