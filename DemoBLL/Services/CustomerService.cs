using BLL.BusinessObjects;
using BLL.Converters;
using DAL.Facade;
using DemoBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class CustomerService : IService<CustomerBO>
    {
        CustomerConverter conv = new CustomerConverter();
        DALFacade _facade;

        public CustomerService(DALFacade facade)
        {
            _facade = facade;
        }

        public CustomerBO Create(CustomerBO bo)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newCustomer = uow.CustomerRepository.Create(conv.Convert(bo));
                uow.Complete();
                return conv.Convert(newCustomer);
            }
        }

        public CustomerBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newCustomer = uow.CustomerRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newCustomer);
            }
        }

        public CustomerBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var customer = conv.Convert(uow.CustomerRepository.Get(Id));
                return customer;
            }
        }

        public List<CustomerBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.CustomerRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public CustomerBO Update(CustomerBO bo)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var customerFromDb = uow.CustomerRepository.Get(bo.Id);
                if (customerFromDb == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }

                var customerUpdated = conv.Convert(bo);
                customerFromDb.Address = customerUpdated.Address;
                customerFromDb.ContactPerson = customerUpdated.ContactPerson;
                customerFromDb.Email = customerUpdated.Email;
                customerFromDb.Name = customerUpdated.Name;
                customerFromDb.PhoneNumber = customerUpdated.PhoneNumber;
                customerFromDb.WarehouseAddress = customerUpdated.WarehouseAddress;

                uow.Complete();
                return conv.Convert(customerFromDb);
            }
        }
    }
}
