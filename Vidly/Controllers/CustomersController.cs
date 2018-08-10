using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
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

        //
        // GET: /Customers/
        [Route("customers")]
        public ActionResult GetCustomers()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View("Customers", customers);
        }

        [Route("Customers/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            var cust = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(cus => cus.ID == Id);

            if (cust == null) { return HttpNotFound(); }

            return View("CustomerDetails", cust);
        }


        [Route("Customers/Edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            var cust = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(cus => cus.ID == Id);

            if (cust == null) { return HttpNotFound(); }

            var MembershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = cust,
                MembershipTypes = MembershipTypes,
                Mode = "Edit"
            };

            return View("CustormerForm", viewModel);
        }


        [Route("Customers/New")]
        public ActionResult New()
        {
            var MembershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                // Customer property will be initialise to the default values--> this prevents validation on Id in the ModelState bcos it wld hv been null
                Customer = new Customer(),
                MembershipTypes = MembershipTypes,
                Mode = "New"
            };

            return View("CustormerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUpdate(CustomerFormViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                var viewModel2 = new CustomerFormViewModel{
                    Customer = viewModel.Customer,
                    MembershipTypes = _context.MembershipTypes.ToList()

                };

                return View("CustormerForm", viewModel2);
            }


            var cus = MapCustomer(viewModel);
         
            // Create CusId = 0
            if (cus.ID == 0)
            {
                _context.Customers.Add(cus);

            }
            // Create CusId != 0 Update
            else
            {
                var cusInDb = _context.Customers.First(x => x.ID == cus.ID);

                cusInDb.Name = cus.Name;
                cusInDb.Birthdate = cus.Birthdate;
                cusInDb.MembershipTypeId = cus.MembershipTypeId;
                cusInDb.IsSubscribedToNewLetter = cus.IsSubscribedToNewLetter;

            }

            _context.SaveChanges();
     
            return RedirectToAction("GetCustomers");
        }


        private Customer MapCustomer(dynamic model)
        {
            var customer = new Customer();
            customer.Name = model.Customer.Name;
            customer.IsSubscribedToNewLetter = model.Customer.IsSubscribedToNewLetter;
            customer.MembershipTypeId = model.Customer.MembershipTypeId;
            customer.Birthdate = model.Customer.Birthdate;
            customer.ID = model.Customer.ID;

            return customer;
        }
    }
}