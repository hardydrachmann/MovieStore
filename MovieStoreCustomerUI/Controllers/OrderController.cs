using MovieStoreBE;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MovieStoreCustomerUI.Infrastructure;

public class OrderController : Controller
{
    private readonly ServiceGateway gateway = new ServiceGateway();

    // GET: Order
    public ActionResult Index()
    {
        return View();
    }

    // Order List
    public ActionResult OrderList(string eMail)
    {
        IEnumerable<Customer> customers = gateway.GetCustomers();

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
