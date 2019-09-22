using dotnetdemo.data.Abstract;
using Microsoft.AspNetCore.Mvc;
using dotnetdemo.data.Entities;
using System.Data;
using System.Linq;

namespace dotnetdemo.api.Controllers {
    public class CustomersController : Controller {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController (IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        // GET: /Customer/

        public ViewResult Index () {
            var Customers = _unitOfWork.CustomerRepository.Get ();
            return View (Customers.ToList ());
        }

        // GET: /Customer/Details/5

        public ViewResult Details (int id) {
            Customer Customer = _unitOfWork.CustomerRepository.GetByID (id);
            return View (Customer);
        }

        // GET: /Customer/Create

        public ActionResult Create () {
            return View ();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Customer Customer) {
            try {
                if (ModelState.IsValid) {
                    _unitOfWork.CustomerRepository.Insert (Customer);
                    _unitOfWork.Commit ();
                    return RedirectToAction ("Index");
                }
            } catch (DataException) {
                ModelState.AddModelError ("", "Unable to save changes.");
            }
            return View (Customer);
        }

        public ActionResult Edit (int id) {
            Customer Customer = _unitOfWork.CustomerRepository.GetByID (id);
            return View (Customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (
            Customer Customer) {
            try {
                if (ModelState.IsValid) {
                    _unitOfWork.CustomerRepository.Update (Customer);
                    _unitOfWork.Commit ();
                    return RedirectToAction ("Index");
                }
            } catch (DataException) {
                ModelState.AddModelError ("", "Unable to save changes.");
            }
            return View (Customer);
        }

        // GET: /Customer/Delete/5

        public ActionResult Delete (int id) {
            Customer Customer = _unitOfWork.CustomerRepository.GetByID (id);
            return View (Customer);
        }

        // POST: /Customer/Delete/5

        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed (int id) {
            Customer Customer = _unitOfWork.CustomerRepository.GetByID (id);
            _unitOfWork.CustomerRepository.Delete (id);
            _unitOfWork.Commit ();
            return RedirectToAction ("Index");
        }

        protected override void Dispose (bool disposing) {
            _unitOfWork.Dispose ();
            base.Dispose (disposing);
        }
    }
}