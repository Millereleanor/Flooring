using System;
using System.Collections.Generic;
using Flooring.Models;

namespace Flooring.Data
{
    public interface IFloorRepository
    {
        Order CreateOrder(Order order);
        Dictionary<DateTime, List<Order>> GetAllOrders();
        List<Order> GetAllOrderByDate(DateTime date);
        Order GetOrderByDateId(DateTime date, int orderId);
        void UpdateOrder(DateTime date, int orderId, Order updateOrder);
        void RemoveOrder(DateTime date, int orderId);
        void WriteToFile(Dictionary<DateTime, Order> Order);

    }
}