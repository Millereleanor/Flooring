using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Data;
using NUnit.Framework;

namespace Flooring.Tests
{
    [TestFixture]
    public class Tests
    {
        //testing the floor repo
        [Test]
        public void CanLoadAccount()
        {
            var repo = new FloorRepository();

            var orders = repo.GetAllOrders();
            DateTime orderDate = DateTime.Parse("01/14/1992");

            Assert.AreEqual(1, orders[orderDate].OrderNumber );
            Assert.AreEqual("Elle Miller", orders[orderDate].FirstName + " " + orders[orderDate].LastName);
            Assert.AreEqual(100,orders[orderDate].OrderArea);
        }
    }
}
