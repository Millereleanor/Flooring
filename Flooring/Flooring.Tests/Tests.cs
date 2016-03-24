using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Data;
using Flooring.Models;
using NUnit.Framework;

namespace Flooring.Tests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void CanLoadOrder()
        {
            var repo = new FloorRepository();


            DateTime orderDate = DateTime.Parse("01/14/1992");
            var orders = repo.GetAllOrderByDate(orderDate);
            Assert.AreEqual(1, orders[0].OrderNumber);
            Assert.AreEqual("Elle Miller", orders[0].FirstName + " " + orders[0].LastName);
            Assert.AreEqual(100, orders[0].OrderArea);
        }

        [Test]
        public void CanAddOrder()
        {
            var repo = new FloorRepository();


            DateTime orderDate = DateTime.Parse("01/14/1992");
            var orders = repo.GetAllOrderByDate(orderDate);

            int expectedCount = orders.Count + 1;

            var o = repo.CreateOrder(new Order()
            {
                OrderDate = orderDate,
                FirstName = "jen",
                LastName = "Miller",
                ProductType = "wood",
                StateFull = "Ohio",
                StateAbbr = "OH",
                CostperSqFt = 7,
                TaxRate = 8,
                LaborperSqFt = 0,
                OrderArea = 100
            });

            var c = repo.GetAllOrderByDate(orderDate);

            Assert.AreEqual(expectedCount, c.Count);



        }

        [Test]
        public void CanRemoveOrder()
        {
            var repo = new FloorRepository();


            DateTime orderDate = DateTime.Parse("01/14/1992");
            var orders = repo.GetAllOrderByDate(orderDate);

            int expectedCount = orders.Count;

            var o = repo.CreateOrder(new Order()
            {
                OrderDate = orderDate,
                FirstName = "jen",
                LastName = "Miller",
                ProductType = "wood",
                StateFull = "Ohio",
                StateAbbr = "OH",
                CostperSqFt = 7,
                TaxRate = 8,
                LaborperSqFt = 0,
                OrderArea = 100
            });
            repo.RemoveOrder(orderDate, o.OrderNumber);
            var c = repo.GetAllOrderByDate(orderDate);

            Assert.AreEqual(expectedCount, c.Count);


            
            //creat and order
            //check the order number
            //deleat an order
            //checked the order count
        }

        [Test]
        public void CanEditOrder()
        {
            var repo = new FloorRepository();


            DateTime orderDate = DateTime.Parse("01/14/1992");
            var orders = repo.GetAllOrderByDate(orderDate);
            var newOrder = new Order()
            {
                OrderNumber = 1,
                OrderDate = orderDate,
                FirstName = "jill",
                LastName = "bob",
                StateAbbr = "OH",
                StateFull = "Ohio",
                TaxRate = 7,
                ProductType = "Wood",
                OrderArea = 100,
                CostperSqFt = 5,
                LaborperSqFt = 5,

            };
            repo.UpdateOrder(orderDate, 1, newOrder);

            Assert.AreEqual("jill", orders[0].FirstName);
            Assert.AreEqual("bob",orders[0].LastName);
            Assert.AreEqual("goo",orders[1].FirstName);
          
        }
        [Test]
        public void CanReadStates()
        {
            var repo = new ReadStateProduct();

            var states = repo.GetStatefromTxt();
            var testState = new State();
            {
                testState.Abbr = "MI";
                testState.FullName = "Michigan";
                testState.TaxRate = 5.75m;
            };

            Assert.AreEqual(states[2].Abbr, testState.Abbr);
            Assert.AreEqual(states[2].FullName, testState.FullName);
            Assert.AreEqual(states[2].TaxRate, testState.TaxRate/100);
        }
        [Test]
        public void CanReadProducts()
        {
            var repo = new ReadStateProduct();

            var products = repo.GetProductfromTxt();
            var testProduct = new Product();
            {
                testProduct.ProductType = "Wood";
                testProduct.CostperSqFt = 5.15m;
                testProduct.LaborperSqFt = 4.75m;
            };

            Assert.AreEqual(products[3].ProductType, testProduct.ProductType);
            Assert.AreEqual(products[3].CostperSqFt, testProduct.CostperSqFt);
            Assert.AreEqual(products[3].LaborperSqFt, testProduct.LaborperSqFt);
        }
    }
}