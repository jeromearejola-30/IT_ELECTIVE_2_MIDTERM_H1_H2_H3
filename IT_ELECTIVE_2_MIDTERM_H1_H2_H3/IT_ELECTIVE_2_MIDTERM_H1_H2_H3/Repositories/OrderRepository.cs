using IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.Entities;

namespace IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Repositories
{
    public class OrderRepository
    {
        private readonly List<Order> _orders = new();

        public void SaveOrder(Order order)
        {
            _orders.Add(order);
        }

        public Order? GetOrderById(string orderId)
        {
            return _orders.FirstOrDefault(o => o.OrderId == orderId);
        }
    }
}