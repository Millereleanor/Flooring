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

            
            DateTime orderDate = DateTime.Parse("01/14/1992");
            var orders = repo.GetAllOrderByDate(orderDate);
            Assert.AreEqual(1, orders[0].OrderNumber);
            Assert.AreEqual("Elle Miller", orders[0].FirstName + " " + orders[0].LastName);
           Assert.AreEqual(100,orders[0].OrderArea);
        }
    }
}
