using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyProject.Models;
using System.Data.Entity;
using VidlyProject.ViewModels;
using System.Data.Entity.Validation;

namespace VidlyProject.Controllers
{
 
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
    
        public ViewResult Index()
        {
            //var customers = _context.Customers.Include(model => model.MembershipType).ToList();
            return View(/*customers*/);
        }
        public ActionResult Details(int id)
        {
            var Customer = _context.Customers.Include(c =>c.MembershipType).SingleOrDefault(c=>c.Id == id);
            if (Customer == null) return HttpNotFound();
            
            return View(Customer);
        }
        public ActionResult New()
        {
            var MembershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = MembershipTypes
                ,
                Customer = new Customer()
            };
            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer  customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm" , viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribeToNewsModel = customer.IsSubscribeToNewsModel;
                customerInDb.BirthDay = customer.BirthDay;
            }
            try
            {
                _context.SaveChanges();
            }
            catch(DbEntityValidationException)
            {
                Console.WriteLine();
            }
            return RedirectToAction("Index" , "Customers");
        }
      
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c =>c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

       
    }
}