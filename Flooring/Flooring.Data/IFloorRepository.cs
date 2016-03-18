using System;
using System.Collections.Generic;
using Flooring.Models;

namespace Flooring.Data
{
    public interface IFloorRepository
    {
        Order CreateOrder(Order order);

        //Get all orders is duplicate of get all order by date...so no need
        Dictionary<DateTime, List<Order>> GetAllOrders();
        List<Order> GetAllOrderByDate(DateTime date);

        Order GetOrderByDateId(DateTime date, int orderId);
        void UpdateOrder(DateTime date, int orderId, Order updateOrder);
        //todo:test remove order
        void RemoveOrder(DateTime date, int orderId);

        //don't need write to file
       // void WriteToFile(Dictionary<DateTime, List<Order>> Order);

    }
}