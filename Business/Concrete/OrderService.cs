using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;


namespace Business.Concrete
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        
        public OrderService(IOrderRepository ordersRepository)
        {
            _orderRepository = ordersRepository;

        }
    }
}
