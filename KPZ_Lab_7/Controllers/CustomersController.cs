using KPZ_Lab_7.Models;
using KPZ_Lab_7.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KPZ_Lab_7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("Any")]
    public class CustomersController : ControllerBase
    {
        private readonly IDBService _DBService;

        public CustomersController(IDBService db)
        {
            _DBService = db;
        }

        /// <summary>
        /// Returns all Customers
        /// </summary>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _DBService.GetAllCustomers();
        }

        /// <summary>
        /// Returns specified ammount of customers
        /// </summary>
        [Route("{ammount:int}")]
        [HttpGet]
        public IEnumerable<Customer> Get(int ammount)
        {
            return _DBService.GetCustomers(ammount);
        }

        /// <summary>
        /// Updates Customer by given #id
        /// </summary>
        /// <response code="400">Validation is not passed</response>
        [HttpPut]
        public void Update(Customer cust)
        {
            _DBService.UpdateCustomer(cust);
        }

        /// <summary>
        /// Creates Customer
        /// </summary>
        /// <response code="400">Validation is not passed</response>
        [HttpPost]
        public IEnumerable<Customer> Create(Customer cust)
        {
            _DBService.CreateCustomer(cust);
            yield return cust;
        }

        /// <summary>
        /// Deletes Customer by given #id
        /// </summary>
        [HttpDelete]
        public void Delete(int id)
        {
            _DBService.DeleteCustomer(id);
        }
    }
}
