using KPZ_Lab_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPZ_Lab_7.Services
{
    public interface IDBService
    {
        //Customers related
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Customer> GetCustomers(int ammount);
        void UpdateCustomer(Customer customer);
        void CreateCustomer(Customer customer);
        void DeleteCustomer(int id);

        //Suppliers related
        IEnumerable<Supplier> GetAllSuppliers();
        IEnumerable<Supplier> GetSuppliers(int ammount);
        void UpdateSupplier(Supplier supplier);
        void CreateSupplier(Supplier supplier);
        void DeleteSupplier(int id);
    }
}
