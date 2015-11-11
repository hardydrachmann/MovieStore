using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieStoreBE;
using MovieStoreDAL;

namespace API.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly OrderRepository orderRepo = new OrderRepository();

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> GetAllOrders()
        {
            return orderRepo.GetAll();
        }

        /// <summary>
        /// Get order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order GetOrder(int id)
        {
            Order order = orderRepo.Get(id);
            if (order == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return order;
        }

        /// <summary>
        /// Add order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public HttpResponseMessage PostOrder(Order order)
        {
            orderRepo.Add(order);
            return Request.CreateResponse(HttpStatusCode.Created, order);
        }

        /// <summary>
        /// Update order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public HttpResponseMessage PutOrder(Order order)
        {
            orderRepo.Edit(order);
            return Request.CreateResponse(HttpStatusCode.Accepted, order);
        }

        /// <summary>
        /// Delete order
        /// </summary>
        /// <param name="id"></param>
        public void DeleteOrder(int id)
        {
            orderRepo.Remove(id);
        }
    }
}