using BLL.BusinessObjects;
using BLL.Converters;
using DAL.Entities;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class ShipmentConverterTest
    {
        [Test]
        public void TestConvShipmentEntityToNull()
        {
            var converter = new ShipmentConverter();
            Shipment ent = converter.Convert((ShipmentBO)null);

            Assert.IsNull(ent);
        }

        [Test]
        public void TestConvShipmentBusinessObjectToNull()
        {
            var converter = new ShipmentConverter();
            ShipmentBO bo = converter.Convert((Shipment)null);

            Assert.IsNull(bo);
        }

        [Test]
        public void TestConvShipmentToEntityId()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { Id = 1 };

            Shipment shipment = new Shipment() { Id = 1 };

            var result = conv.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.Id, expected.Id);
        }

        [Test]
        public void TestConvShipmentToEntityCustId()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { CustomerId = 1 };

            Shipment shipment = new Shipment() { CustomerId = 1 };

            var result = conv.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.CustomerId, expected.CustomerId);
        }

        [Test]
        public void TestConvShipmentToEntityContId()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { ContainerId = 1 };

            Shipment shipment = new Shipment() { ContainerId = 1 };

            var result = conv.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.ContainerId, expected.ContainerId);
        }

        [Test]
        public void TestConvShipmentToEntityBill()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { Bill = 250 };

            Shipment shipment = new Shipment() { Bill = 250 };

            var result = conv.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.Bill, expected.Bill);
        }

        [Test]
        public void TestConvShipmentToEntityCargo()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { CargoInfo = "Info" };

            Shipment shipment = new Shipment() { CargoInfo = "Info" };

            var result = conv.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.CargoInfo, expected.CargoInfo);
        }

        [Test]
        public void TestConvShipmentToEntityContQuant()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { ContainerQuantity = 1 };

            Shipment shipment = new Shipment() { ContainerQuantity = 1 };

            var result = conv.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.ContainerQuantity, expected.ContainerQuantity);
        }

        [Test]
        public void TestConvShipmentToEntityDepart()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { CountryDeparture = "12/12/2012" };

            Shipment shipment = new Shipment() { CountryDeparture = "12/12/2012" };

            var result = conv.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.CountryDeparture, expected.CountryDeparture);
        }

        [Test]
        public void TestConvShipmentToEntityDelivery()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { CountryDelivery = "13/10/2013" };

            Shipment shipment = new Shipment() { CountryDelivery = "13/10/2013" };

            var result = conv.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.CountryDelivery, expected.CountryDelivery);
        }

        [Test]
        public void TestConvShipmentToEntityHandlijng()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { HandlingDetail = "Details" };

            Shipment shipment = new Shipment() { HandlingDetail = "Details" };

            var result = conv.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.HandlingDetail, expected.HandlingDetail);
        }

        [Test]
        public void TestConvShipmentToEntityFinished()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { FinishedDate = "12/05/2014" };

            Shipment shipment = new Shipment() { FinishedDate = "12/05/2014" };

            var result = conv.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.FinishedDate, expected.FinishedDate);
        }

        [Test]
        public void TestConvShipmentToEntityCost()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { Cost = 150 };

            Shipment shipment = new Shipment() { Cost = 150 };

            var result = conv.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.Cost, expected.Cost);
        }

        [Test]
        public void TestConvShipmentToEntityName()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { ShipmentName = "Name" };

            Shipment shipment = new Shipment() { ShipmentName = "Name" };

            var result = conv.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.ShipmentName, expected.ShipmentName);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectId()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { Id = 1 };

            Shipment shipment = new Shipment() { Id = 1 };

            var result = conv.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.Id, expected.Id);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectName()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { ShipmentName = "Name" };

            Shipment shipment = new Shipment() { ShipmentName = "Name" };

            var result = conv.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.ShipmentName, expected.ShipmentName);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectCargo()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { CargoInfo = "Info" };

            Shipment shipment = new Shipment() { CargoInfo = "Info" };

            var result = conv.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.CargoInfo, expected.CargoInfo);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectDepart()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { CountryDeparture = "20/10/2010" };

            Shipment shipment = new Shipment() { CountryDeparture = "20/10/2010" };

            var result = conv.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.CountryDeparture, expected.CountryDeparture);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectDelivery()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { CountryDelivery = "30/10/2010" };

            Shipment shipment = new Shipment() { CountryDelivery = "30/10/2010" };

            var result = conv.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.CountryDelivery, expected.CountryDelivery);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectContQuant()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { ContainerQuantity = 50 };

            Shipment shipment = new Shipment() { ContainerQuantity = 50 };

            var result = conv.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.ContainerQuantity, expected.ContainerQuantity);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectHandling()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { HandlingDetail = "Details" };

            Shipment shipment = new Shipment() { HandlingDetail = "Details" };

            var result = conv.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.HandlingDetail, expected.HandlingDetail);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectFinished()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { FinishedDate = "20/11/2010" };

            Shipment shipment = new Shipment() { FinishedDate = "20/11/2010" };

            var result = conv.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.FinishedDate, expected.FinishedDate);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectBill()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { Bill = 150 };

            Shipment shipment = new Shipment() { Bill = 150 };

            var result = conv.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.Bill, expected.Bill);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectCost()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { Cost = 130 };

            Shipment shipment = new Shipment() { Cost = 130 };

            var result = conv.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.Cost, expected.Cost);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectCustId()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { CustomerId = 1 };

            Shipment shipment = new Shipment() { CustomerId = 1 };

            var result = conv.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.CustomerId, expected.CustomerId);
        }

        [Test]
        public void TestConvShipmentToBusinessObjectContId()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO() { ContainerId = 2 };

            Shipment shipment = new Shipment() { ContainerId = 2 };

            var result = conv.Convert(shipment);
            var expected = shipmentBO;

            Assert.AreEqual(result.ContainerId, expected.ContainerId);
        }
    }
}