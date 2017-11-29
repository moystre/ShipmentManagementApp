using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly ShipmentContext _context;

        public CustomerRepository(ShipmentContext context)
        {
            _context = context;
        }

        public Customer Create(Customer entity)
        {
            _context.Customers.Add(entity);
            return entity;
        }

        public Customer Delete(int Id)
        {
            var customerToDelete = Get(Id);
            _context.Customers.Remove(customerToDelete);
            return customerToDelete;
        }

        public Customer Get(int Id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == Id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers;
        }

        public IEnumerable<Customer> GetAllById(List<int> ids)
        {
            if (ids == null) { return null; }

            return _context.Customers.Where(c => ids.Contains(c.Id));
        }
    }
}
