using MovieStoreBE;
using System.Web.Mvc;
using MovieStoreAdminUI.Infrastructure;

namespace MovieStoreAdminUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly ServiceGateway gateway = new ServiceGateway();

        // GET: Order
        public ActionResult Index()
        {
            return View(gateway.GetOrders());
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            Order order = gateway.GetOrder(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                gateway.CreateOrder(order);
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            Order order = gateway.GetOrder(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                gateway.UpdateOrder(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            Order order = gateway.GetOrder(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gateway.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}
