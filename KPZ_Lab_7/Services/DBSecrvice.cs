using KPZ_Lab_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPZ_Lab_7.Services
{
    public class DBSecrvice : IDBService
    {
        //Customers related
        public IEnumerable<Customer> GetAllCustomers()
        {
            using SupermarketNetworkDBContext db = new SupermarketNetworkDBContext();

            return db.Customers.Select(x => x).ToList();
        }

        public IEnumerable<Customer> GetCustomers(int ammount)
        {
            using SupermarketNetworkDBContext db = new SupermarketNetworkDBContext();

            return db.Customers.Select(x => x).Take(ammount).ToList();
        }

        public void CreateCustomer(Customer customer)
        {
            using SupermarketNetworkDBContext db = new SupermarketNetworkDBContext();

            var lastId = db.Customers.Select(x => x.CustomerId).OrderByDescending(x => x).FirstOrDefault();
            customer.CustomerId = lastId + 1;

            db.Customers.Add(customer);
            db.SaveChanges();

        }

        public void DeleteCustomer(int id)
        {
            using SupermarketNetworkDBContext db = new SupermarketNetworkDBContext();

            var delTarget = db.Customers.Select(x => x).Where(x => x.CustomerId == id).FirstOrDefault();
            if(delTarget != null)
            {
                db.Customers.Remove(delTarget);
                db.SaveChanges();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using SupermarketNetworkDBContext db = new SupermarketNetworkDBContext();

            var custToUpdate = db.Customers.Select(x => x).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault();
            if(custToUpdate != null)
            {
                custToUpdate.CustomerPhone = customer.CustomerPhone;
                custToUpdate.CustomerAddress = customer.CustomerAddress;
                custToUpdate.CustomerName = customer.CustomerName;
                custToUpdate.CustomerEmail = customer.CustomerEmail;

                db.SaveChanges();
            }
        }

        //Supplier related
        public IEnumerable<Supplier> GetAllSuppliers()
        {
            using SupermarketNetworkDBContext db = new SupermarketNetworkDBContext();

            return db.Suppliers.Select(x => x).ToList();
        }

        public IEnumerable<Supplier> GetSuppliers(int ammount)
        {
            using SupermarketNetworkDBContext db = new SupermarketNetworkDBContext();

            return db.Suppliers.Select(x => x).Take(ammount).ToList();
        }

        public void CreateSupplier(Supplier supplier)
        {
            using SupermarketNetworkDBContext db = new SupermarketNetworkDBContext();

            var lastId = db.Suppliers.Select(x => x.SupplierId).OrderByDescending(x => x).FirstOrDefault();
            supplier.SupplierId = lastId + 1;

            db.Suppliers.Add(supplier);

            db.SaveChanges();
        }

        public void DeleteSupplier(int id)
        {
            using SupermarketNetworkDBContext db = new SupermarketNetworkDBContext();

            var delTarget = db.Suppliers.Select(x => x).Where(x => x.SupplierId == id).FirstOrDefault();
            if (delTarget != null)
            {
                db.Suppliers.Remove(delTarget);
                db.SaveChanges();
            }
        }

        public void UpdateSupplier(Supplier supplier)
        {
            using SupermarketNetworkDBContext db = new SupermarketNetworkDBContext();

            var supplierToUpdate = db.Suppliers.Select(x => x).Where(x => x.SupplierId == supplier.SupplierId).FirstOrDefault();
            if (supplierToUpdate != null)
            {
                supplierToUpdate.ContactName = supplier.ContactName;
                supplierToUpdate.Products = supplier.Products;
                supplierToUpdate.SupplierAddress = supplier.SupplierAddress;
                supplierToUpdate.SupplierEmail = supplier.SupplierEmail;
                supplierToUpdate.SupplierPhone = supplier.SupplierPhone;
                supplierToUpdate.SupplierName = supplier.SupplierName;
             
                db.SaveChanges();
            }
        }
    }
}
