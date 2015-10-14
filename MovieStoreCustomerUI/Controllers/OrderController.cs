using MovieStoreDAL;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

public class OrderController : Controller
{
    private CustomerRepository cusRepo = new CustomerRepository();
    private OrderRepository ordRepo = new OrderRepository();

    // GET: Order
    public ActionResult Index()
    {
        return View();
    }

    // Order List
    public ActionResult OrderList(string eMail)
    {
        IEnumerable<Customer> customers = cusRepo.GetAll();

        foreach (var customer in customers)
        {
            if (eMail == customer.Email)
            {
                return View(customer);
            }
        }
        return RedirectToAction("index");
    }
}
