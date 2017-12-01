using BLL.BusinessObjects;
using DAL.Entities;
using DemoBLL.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class CustomerConverter : IConverter<Customer, CustomerBO>
    {
        public Customer Convert(CustomerBO businessObject)
        {
            if (businessObject == null) { return null; }
            return new Customer()
            {
                Id = businessObject.Id,
                Address = businessObject.Address,
                ContactPerson = businessObject.ContactPerson,
                Email = businessObject.Email,
                CustomerName = businessObject.CustomerName,
                PhoneNumber = businessObject.PhoneNumber,
                WarehouseAddress = businessObject.WarehouseAddress
            };
        }

        public CustomerBO Convert(Customer entity)
        {
            if (entity == null) { return null; }
            return new CustomerBO()
            {
                Id = entity.Id,
                Address = entity.Address,
                ContactPerson = entity.ContactPerson,
                Email = entity.Email,
                CustomerName = entity.CustomerName,
                PhoneNumber = entity.PhoneNumber,
                WarehouseAddress = entity.WarehouseAddress
            };
        }
    }
}
