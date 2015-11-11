using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MovieStoreAdminUI.Infrastructure;
using MovieStoreBE;

namespace MovieStoreAdminUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ServiceGateway gateway = new ServiceGateway();

        // GET: Customer
        public ActionResult Index()
        {
            return View(gateway.GetCustomers());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            Customer customer = gateway.GetCustomer(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                gateway.CreateCustomer(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = gateway.GetCustomer(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                gateway.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer = gateway.GetCustomer(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gateway.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
