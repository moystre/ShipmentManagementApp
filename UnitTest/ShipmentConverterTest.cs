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
        public void TestTwo()
        {
            var conv = new ShipmentConverter();

            ShipmentBO shipmentBO = new ShipmentBO()
            {
                Id = 87,
                Bill = 122,
                CargoInfo = "Info",
                ContainerQuantity = 1224,
                Cost = 100,
                CountryDelivery = "Greenland",
                CountryDeparture = "Germany",
                CustomerName = "Cust1",
                FinishedDate = "2017-12-12",
                HandlingDetail = "Details",
                ShipmentName = "#65521"
            };

            Shipment shipment = new Shipment()
            {
                Id = 87,
                Bill = 122,
                CargoInfo = "Info",
                ContainerQuantity = 1224,
                Cost = 100,
                CountryDelivery = "Greenland",
                CountryDeparture = "Germany",
                CustomerName = "Cust1",
                FinishedDate = "2017-12-12",
                HandlingDetail = "Details",
                ShipmentName = "#65521"
            };

            var result = conv.Convert(shipmentBO);
            var expected = shipment;

            Assert.AreEqual(result.Id, expected.Id);
            Assert.AreEqual(result.Bill, expected.Bill);
            Assert.AreEqual(result.CargoInfo, expected.CargoInfo);
            Assert.AreEqual(result.ContainerQuantity, expected.ContainerQuantity);
            Assert.AreEqual(result.Cost, expected.Cost);
            Assert.AreEqual(result.CountryDelivery, expected.CountryDelivery);
            Assert.AreEqual(result.CountryDeparture, expected.CountryDeparture);
            Assert.AreEqual(result.CustomerName, expected.CustomerName);
            Assert.AreEqual(result.FinishedDate, expected.FinishedDate);
            Assert.AreEqual(result.HandlingDetail, expected.HandlingDetail);
            Assert.AreEqual(result.ShipmentName, expected.ShipmentName);
        }
    }
}