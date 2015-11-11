using MovieStoreDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieStoreBE;

namespace API.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly CustomerRepository customerRepo = new CustomerRepository();

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetAllCustomers()
        {
            return customerRepo.GetAll();
        }

        /// <summary>
        /// Get customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomer(int id)
        {
            Customer customer = customerRepo.Get(id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;
        }

        /// <summary>
        /// Add customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public HttpResponseMessage PostCustomer(Customer customer)
        {
            customerRepo.Add(customer);
            return Request.CreateResponse(HttpStatusCode.Created, customer);
        }

        /// <summary>
        /// Update customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public HttpResponseMessage PutCustomer(Customer customer)
        {
            customerRepo.Edit(customer);
            return Request.CreateResponse(HttpStatusCode.Accepted, customer);
        }

        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCustomer(int id)
        {
            customerRepo.Remove(id);
        }
    }
}