using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }


        // GET /api/Customers
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            var response = _dbContext.Customers
                        .Include(x => x.MembershipType)
                        .ToList().Select(Mapper.Map<Customer, CustomerDTO>);

            return response;
        }


        //GET api/customers/id
        public IHttpActionResult GetCustomerById(int Id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(x => x.ID == Id);

            if (customer == null) { return NotFound(); }

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }


        //POST api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDTO, Customer>(customerdto);

            _dbContext.Customers.Add(customer);

            _dbContext.SaveChanges();

            customerdto.ID = customer.ID;

            return Created( new Uri(Request.RequestUri + "/" + customer.ID), customerdto);
        }



        //PUT api/customers/1
        [HttpPut]
        public void UpdateCustomer(int Id, CustomerDTO customerdto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDB = _dbContext.Customers.Single(x => x.ID == Id);

            if (customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<CustomerDTO, Customer>(customerdto, customerInDB);
           
            
            _dbContext.SaveChanges();

        }




        //DELETE api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDB = _dbContext.Customers.Single(x => x.ID == Id);

            if (customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _dbContext.Customers.Remove(customerInDB);

            _dbContext.SaveChanges();
        }

    }
}
