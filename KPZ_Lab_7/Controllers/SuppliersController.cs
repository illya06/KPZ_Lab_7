using KPZ_Lab_7.Models;
using KPZ_Lab_7.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPZ_Lab_7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuppliersController
    {
        private readonly IDBService _DBService;

        public SuppliersController(IDBService db)
        {
            _DBService = db;
        }

        /// <summary>
        /// Returns all Supliers
        /// </summary>
        [HttpGet]
        public IEnumerable<Supplier> Get()
        {
            return _DBService.GetAllSuppliers();
        }

        [Route("{ammount:int}")]
        [HttpGet]
        public IEnumerable<Supplier> Get(int ammount)
        {
            return _DBService.GetSuppliers(ammount);
        }

        /// <summary>
        /// Updates Supplier by given #id
        /// </summary>
        /// <response code="400">Validation is not passed</response>
        [HttpPut]
        public void Update(Supplier supl)
        {
            _DBService.UpdateSupplier(supl);
        }

        /// <summary>
        /// Creates Supplier
        /// </summary>
        /// <response code="400">Validation is not passed</response>
        [HttpPost]
        public void Create(Supplier supl)
        {
            _DBService.CreateSupplier(supl);
        }

        /// <summary>
        /// Deletes Supplier by given #id
        /// </summary>
        [HttpDelete]
        public void Delete(int id)
        {
            _DBService.DeleteSupplier(id);
        }
    }
}
