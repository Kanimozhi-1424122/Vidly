using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers      
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MemberShipTypes.ToList();
            var viewModel = new CustomerFromViewModel
            {
                Customer = new Customer(),
                 MemberShipTypes = membershipTypes,
            };
            
            return View("CustomerForm", viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Customer customer)
    {
        if (!ModelState.IsValid)
        {
            var membershipTypes = _context.MemberShipTypes.ToList();
            var viewModel = new CustomerFromViewModel();
            viewModel.MemberShipTypes = membershipTypes;
            return View("CustomerForm", viewModel);
        }
        else
        {
            if (customer.Id != 0)
            {
                var customersInDb = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);
                customersInDb.Name = customer.Name;
                customersInDb.BirthDate = customer.BirthDate;
                customersInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customersInDb.MemberShipType = customer.MemberShipType;
                _context.SaveChanges();
                return RedirectToAction("Details", "Customers");

            }
            else
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Details", "Customers");
            }
        }
    }


    public ActionResult Edit(int id)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
        if (customer == null)
        {
            return HttpNotFound();
        }
        var viewmodel = new CustomerFromViewModel
        {
            Customer = customer,
            MemberShipTypes = _context.MemberShipTypes.ToList()
        };
        return View("CustomerForm", viewmodel);
    }
    public ActionResult Details()
    {
            //var customer = GetCustomers().ToList();
            //var customer = _context.Customers.Include(c => c.MemberShipType).ToList();
            //if (customer != null)
            //{
            //    return View(customer);
            //}

            //return Content("No customer");
            return View();

    }
    public ActionResult DetailsById(int id)
    {
        //var customer = GetCustomers().FirstOrDefault(c => c.Id == id);
        var customer = _context.Customers.Include(c => c.MemberShipType).FirstOrDefault(c => c.Id == id);
        if (customer == null)
        {
            return HttpNotFound();
        }
        return View(customer);
    }
    //public List<Customer> GetCustomers()
    //{
    //    var customer = new List<Customer>()
    //    {
    //        new Customer { Id = 1, Name = "Kani" },
    //        new Customer { Id = 1, Name = "Kavitha" },
    //     };
    //    return customer;
    //}
}
}