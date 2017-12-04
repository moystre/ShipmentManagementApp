using BLL.BusinessObjects;
using BLL.Converters;
using DAL.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestFixture]
    class ContainerConverterTest
    {
        [Test]
        public void TestThree()
        {
            var conv = new ContainerConverter();

            ContainerBO containerBO = new ContainerBO()
            {
                Id = 25,
                ContainerNumber = "#2563",
                Dangerous = "Yes",
                Frozen = "No",
                Size = "25",
                ShipmentId = 1
            };

            Container container = new Container()
            {
                Id = 25,
                ContainerNumber = "#2563",
                Dangerous = "Yes",
                Frozen = "No",
                Size = "25",
                ShipmentId = 1
            };

            var result = conv.Convert(containerBO);
            var expected = container;

            Assert.AreEqual(result.Id, expected.Id);
            Assert.AreEqual(result.ContainerNumber, expected.ContainerNumber);
            Assert.AreEqual(result.Dangerous, expected.Dangerous);
            Assert.AreEqual(result.Frozen, expected.Frozen);
            Assert.AreEqual(result.Size, expected.Size);
            Assert.AreEqual(result.ShipmentId, expected.ShipmentId);
        }
    }
}
