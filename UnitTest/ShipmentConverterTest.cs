using BLL.BusinessObjects;
using BLL.Converters;
using DAL.Entities;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    class ShipmentConverterTest
    {
        ShipmentConverter converter = new ShipmentConverter();

        [Test]
        public void TestConvShipmentEntityToNull()
        {
            Shipment ent = converter.Convert((ShipmentBO)null);

            Assert.IsNull(ent);
        }

        [Test]
        public void TestConvShipmentBusinessObjectToNull()
        {
            ShipmentBO bo = converter.Convert((Shipment)null);

            Assert.IsNull(bo);
        }

        [Test]
        public void TestConvShipmentToEntityId()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { Id = 1 };

            Shipment shipment = new Shipment() { Id = 1 };

            var result = converter.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.Id, expected.Id);
        }

        [Test]
        public void TestConvShipmentToEntityCustId()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { CustomerId = 1 };

            Shipment shipment = new Shipment() { CustomerId = 1 };

            var result = converter.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.CustomerId, expected.CustomerId);
        }

        [Test]
        public void TestConvShipmentToEntityContId()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { ContainerId = 1 };

            Shipment shipment = new Shipment() { ContainerId = 1 };

            var result = converter.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.ContainerId, expected.ContainerId);
        }

        [Test]
        public void TestConvShipmentToEntityBill()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { Bill = 250 };

            Shipment shipment = new Shipment() { Bill = 250 };

            var result = converter.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.Bill, expected.Bill);
        }

        [Test]
        public void TestConvShipmentToEntityCargo()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { CargoInfo = "Info" };

            Shipment shipment = new Shipment() { CargoInfo = "Info" };

            var result = converter.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.CargoInfo, expected.CargoInfo);
        }

        [Test]
        public void TestConvShipmentToEntityContQuant()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { ContainerQuantity = 1 };

            Shipment shipment = new Shipment() { ContainerQuantity = 1 };

            var result = converter.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.ContainerQuantity, expected.ContainerQuantity);
        }

        [Test]
        public void TestConvShipmentToEntityDepart()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { CountryDeparture = "12/12/2012" };

            Shipment shipment = new Shipment() { CountryDeparture = "12/12/2012" };

            var result = converter.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.CountryDeparture, expected.CountryDeparture);
        }

        [Test]
        public void TestConvShipmentToEntityDelivery()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { CountryDelivery = "13/10/2013" };

            Shipment shipment = new Shipment() { CountryDelivery = "13/10/2013" };

            var result = converter.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.CountryDelivery, expected.CountryDelivery);
        }

        [Test]
        public void TestConvShipmentToEntityHandlijng()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { HandlingDetail = "Details" };

            Shipment shipment = new Shipment() { HandlingDetail = "Details" };

            var result = converter.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.HandlingDetail, expected.HandlingDetail);
        }

        [Test]
        public void TestConvShipmentToEntityFinished()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { FinishedDate = "12/05/2014" };

            Shipment shipment = new Shipment() { FinishedDate = "12/05/2014" };

            var result = converter.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.FinishedDate, expected.FinishedDate);
        }

        [Test]
        public void TestConvShipmentToEntityCost()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { Cost = 150 };

            Shipment shipment = new Shipment() { Cost = 150 };

            var result = converter.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.Cost, expected.Cost);
        }

        [Test]
        public void TestConvShipmentToEntityName()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { ShipmentName = "Name" };

            Shipment shipment = new Shipment() { ShipmentName = "Name" };

            var result = converter.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.ShipmentName, expected.ShipmentName);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectId()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { Id = 1 };

            Shipment shipment = new Shipment() { Id = 1 };

            var result = converter.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.Id, expected.Id);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectName()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { ShipmentName = "Name" };

            Shipment shipment = new Shipment() { ShipmentName = "Name" };

            var result = converter.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.ShipmentName, expected.ShipmentName);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectCargo()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { CargoInfo = "Info" };

            Shipment shipment = new Shipment() { CargoInfo = "Info" };

            var result = converter.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.CargoInfo, expected.CargoInfo);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectDepart()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { CountryDeparture = "20/10/2010" };

            Shipment shipment = new Shipment() { CountryDeparture = "20/10/2010" };

            var result = converter.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.CountryDeparture, expected.CountryDeparture);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectDelivery()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { CountryDelivery = "30/10/2010" };

            Shipment shipment = new Shipment() { CountryDelivery = "30/10/2010" };

            var result = converter.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.CountryDelivery, expected.CountryDelivery);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectContQuant()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { ContainerQuantity = 50 };

            Shipment shipment = new Shipment() { ContainerQuantity = 50 };

            var result = converter.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.ContainerQuantity, expected.ContainerQuantity);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectHandling()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { HandlingDetail = "Details" };

            Shipment shipment = new Shipment() { HandlingDetail = "Details" };

            var result = converter.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.HandlingDetail, expected.HandlingDetail);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectFinished()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { FinishedDate = "20/11/2010" };

            Shipment shipment = new Shipment() { FinishedDate = "20/11/2010" };

            var result = converter.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.FinishedDate, expected.FinishedDate);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectBill()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { Bill = 150 };

            Shipment shipment = new Shipment() { Bill = 150 };

            var result = converter.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.Bill, expected.Bill);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectCost()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { Cost = 130 };

            Shipment shipment = new Shipment() { Cost = 130 };

            var result = converter.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.Cost, expected.Cost);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectCustId()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { CustomerId = 1 };

            Shipment shipment = new Shipment() { CustomerId = 1 };

            var result = converter.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.CustomerId, expected.CustomerId);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectContId()
        {
            ShipmentBO shipmentBO = new ShipmentBO() { ContainerId = 2 };

            Shipment shipment = new Shipment() { ContainerId = 2 };

            var result = converter.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.ContainerId, expected.ContainerId);
        }
    }
}