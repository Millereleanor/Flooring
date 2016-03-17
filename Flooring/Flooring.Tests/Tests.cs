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
        //testing the floor repo
        [Test]
        public void CanLoadOrder()
        {
            var repo = new FloorRepository();

            
            DateTime orderDate = DateTime.Parse("01/14/1992");
            var orders = repo.GetAllOrderByDate(orderDate);
            Assert.AreEqual(1, orders[0].OrderNumber);
            Assert.AreEqual("Elle Miller", orders[0].FirstName + " " + orders[0].LastName);
           Assert.AreEqual(100,orders[0].OrderArea);
        }
        [Test]
        public void CanAddOrder()
        {
            var repo = new FloorRepository();


            DateTime orderDate = DateTime.Parse("01/14/1992");
            var orders = repo.GetAllOrderByDate(orderDate);

            int expectedCount = orders.Count +1;

            var o = repo.CreateOrder(new Order()
            {
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


            // var createOrder = repo.CreateOrder();
            //creat and order
            //check the order number
            //deleat an order
            //checked the order count
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
            repo.RemoveOrder(orderDate,o.OrderNumber);
            var c = repo.GetAllOrderByDate(orderDate);

            Assert.AreEqual(expectedCount,c.Count);


            // var createOrder = repo.CreateOrder();
            //creat and order
            //check the order number
            //deleat an order
            //checked the order count
        }
    }
}
