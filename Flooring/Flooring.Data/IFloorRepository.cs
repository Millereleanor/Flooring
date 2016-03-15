using System;
using System.Collections.Generic;
using Flooring.Models;

namespace Flooring.Data
{
    public interface IFloorRepository
    {
        Order CreateOrder(DateTime date, Order order);
        Dictionary<DateTime, List<Order>> GetAllOrders();
        List<Order> GetAllOrderByDate(DateTime date);
        Order GetOrderByDateId(DateTime date, int orderId);
        void UpdateOrder(DateTime date, int orderId, Order updateOrder);
        void RemoteOrder(DateTime date, int orderId);
        void WriteToFile(Dictionary<DateTime, Order> Order);

    }
}