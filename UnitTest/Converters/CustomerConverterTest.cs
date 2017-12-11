using BLL.BusinessObjects;
using BLL.Converters;
using DAL.Entities;
using NUnit.Framework;

namespace BLLTest.Converters
{
    [TestFixture]
    public class CustomerConverterTest
    {
        CustomerConverter converter = new CustomerConverter();

        [Test]
        public void TestConvCustEntityToNull()
        {
            Customer ent = converter.Convert((CustomerBO)null);
            Assert.IsNull(ent);
        }

        [Test]
        public void TestConvCustBusinessObjectToNull()
        {
            CustomerBO bo = converter.Convert((Customer)null);
            Assert.IsNull(bo);
        }

        [Test]
        public void TestConvCustToEntityId()
        {
            CustomerBO customerBO = new CustomerBO { Id = 1 };
            Customer customer = new Customer { Id = 1 };

            var result = converter.Convert(customerBO);
            var expected = customer;

            Assert.AreEqual(result.Id, expected.Id);
        }

        [Test]
        public void TestConvCustToBusinessObjectId()
        {
            CustomerBO customerBO = new CustomerBO { Id = 1 };
            Customer customer = new Customer { Id = 1 };

            var result = converter.Convert(customer);
            var expected = customerBO;

            Assert.AreEqual(result.Id, expected.Id);
        }

        [Test]
        public void TestConvCustToEntityCustName()
        {
            CustomerBO customerBO = new CustomerBO { CustomerName = "Jack" };
            Customer customer = new Customer { CustomerName = "Jack" };

            var result = converter.Convert(customerBO);
            var expected = customer;

            Assert.AreEqual(result.CustomerName, expected.CustomerName);
        }

        [Test]
        public void TestConvCustToBusinessObjectCustName()
        {
            CustomerBO customerBO = new CustomerBO { CustomerName = "Jack" };
            Customer customer = new Customer { CustomerName = "Jack" };

            var result = converter.Convert(customer);
            var expected = customerBO;

            Assert.AreEqual(result.CustomerName, expected.CustomerName);
        }

        [Test]
        public void TestConvCustToEntityAddress()
        {
            CustomerBO customerBO = new CustomerBO { Address = "10 DowningStreet" };
            Customer customer = new Customer { Address = "10 DowningStreet" };

            var result = converter.Convert(customerBO);
            var expected = customer;

            Assert.AreEqual(result.Address, expected.Address);
        }

        [Test]
        public void TestConvCustToBusinessObjectAddress()
        {
            CustomerBO customerBO = new CustomerBO { Address = "10 DowningStreet" };
            Customer customer = new Customer { Address = "10 DowningStreet" };

            var result = converter.Convert(customer);
            var expected = customerBO;

            Assert.AreEqual(result.Address, expected.Address);
        }

        [Test]
        public void TestConvCustToEntityContact()
        {
            CustomerBO customerBO = new CustomerBO { ContactPerson = "John" };
            Customer customer = new Customer { ContactPerson = "John" };

            var result = converter.Convert(customerBO);
            var expected = customer;

            Assert.AreEqual(result.ContactPerson, expected.ContactPerson);
        }

        [Test]
        public void TestConvCustToBusinessObjectContact()
        {
            CustomerBO customerBO = new CustomerBO { ContactPerson = "John" };
            Customer customer = new Customer { ContactPerson = "John" };

            var result = converter.Convert(customer);
            var expected = customerBO;

            Assert.AreEqual(result.ContactPerson, expected.ContactPerson);
        }

        [Test]
        public void TestConvCustToEntityPhone()
        {
            CustomerBO customerBO = new CustomerBO { PhoneNumber = "23568945" };
            Customer customer = new Customer { PhoneNumber = "23568945" };

            var result = converter.Convert(customerBO);
            var expected = customer;

            Assert.AreEqual(result.PhoneNumber, expected.PhoneNumber);
        }

        [Test]
        public void TestConvCustToBusinessObjectPhone()
        {
            CustomerBO customerBO = new CustomerBO { PhoneNumber = "23568945" };
            Customer customer = new Customer { PhoneNumber = "23568945" };

            var result = converter.Convert(customer);
            var expected = customerBO;

            Assert.AreEqual(result.PhoneNumber, expected.PhoneNumber);
        }

        [Test]
        public void TestConvCustToEntityEmail()
        {
            CustomerBO customerBO = new CustomerBO { Email = "testMail@email.com" };
            Customer customer = new Customer { Email = "testMail@email.com" };

            var result = converter.Convert(customerBO);
            var expected = customer;

            Assert.AreEqual(result.Email, expected.Email);
        }

        [Test]
        public void TestConvCustToBusinessObjectEmail()
        {
            CustomerBO customerBO = new CustomerBO { Email = "testMail@email.com" };
            Customer customer = new Customer { Email = "testMail@email.com" };

            var result = converter.Convert(customer);
            var expected = customerBO;

            Assert.AreEqual(result.Email, expected.Email);
        }

        [Test]
        public void TestConvCustToEntityWarehouse()
        {
            CustomerBO customerBO = new CustomerBO { WarehouseAddress = "SomeStreet 255" };
            Customer customer = new Customer { WarehouseAddress = "SomeStreet 255" };

            var result = converter.Convert(customerBO);
            var expected = customer;

            Assert.AreEqual(result.WarehouseAddress, expected.WarehouseAddress);
        }

        [Test]
        public void TestConvCustToBusinessObjectWarehouse()
        {
            CustomerBO customerBO = new CustomerBO { WarehouseAddress = "SomeStreet 255" };
            Customer customer = new Customer { WarehouseAddress = "SomeStreet 255" };

            var result = converter.Convert(customer);
            var expected = customerBO;

            Assert.AreEqual(result.WarehouseAddress, expected.WarehouseAddress);
        }

        [Test]
        public void TestConvCustToEntityShipId()
        {
            CustomerBO customerBO = new CustomerBO { ShipmentId = 2 };
            Customer customer = new Customer { ShipmentId = 2 };

            var result = converter.Convert(customerBO);
            var expected = customer;

            Assert.AreEqual(result.ShipmentId, expected.ShipmentId);
        }

        [Test]
        public void TestConvCustToBusinessObjectShipId()
        {
            CustomerBO customerBO = new CustomerBO { ShipmentId = 2 };
            Customer customer = new Customer { ShipmentId = 2 };

            var result = converter.Convert(customer);
            var expected = customerBO;

            Assert.AreEqual(result.ShipmentId, expected.ShipmentId);
        }

    }    
}

