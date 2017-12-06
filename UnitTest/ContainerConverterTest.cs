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
        public void TestConvContainerEntityToNull()
        {
            var converter = new ContainerConverter();
            Container ent = converter.Convert((ContainerBO)null);

            Assert.IsNull(ent);
        }

        [Test]
        public void TestConvContainerBusinessObjectToNull()
        {
            var converter = new ContainerConverter();
            ContainerBO bo = converter.Convert((Container)null);

            Assert.IsNull(bo);
        }

        [Test]
        public void TestConvContainerToEntityId()
        {
            var conv = new ContainerConverter();

            ContainerBO containerBO = new ContainerBO() {Id = 2 };

            Container container = new Container() { Id = 2 };

            var result = conv.Convert(containerBO);
            var expected = container;

            Assert.AreEqual(result.Id, expected.Id);
        }

        [Test]
        public void TestConvContainerToEntityCN()
        {
            var conv = new ContainerConverter();

            ContainerBO containerBO = new ContainerBO() { ContainerNumber = "232" };

            Container container = new Container() { ContainerNumber = "232" };

            var result = conv.Convert(containerBO);
            var expected = container;

            Assert.AreEqual(result.ContainerNumber, expected.ContainerNumber);
        }

        [Test]
        public void TestConvContainerToEntityDan()
        {
            var conv = new ContainerConverter();

            ContainerBO containerBO = new ContainerBO() { Dangerous = "Yes" };

            Container container = new Container() { Dangerous = "Yes" };

            var result = conv.Convert(containerBO);
            var expected = container;

            Assert.AreEqual(result.Dangerous, expected.Dangerous);
        }

        [Test]
        public void TestConvContainerToEntityFr()
        {
            var conv = new ContainerConverter();

            ContainerBO containerBO = new ContainerBO() { Frozen = "Yes" };
            
            Container container = new Container() { Frozen = "Yes" };

            var result = conv.Convert(containerBO);
            var expected = container;

            Assert.AreEqual(result.Frozen, expected.Frozen);
        }

        [Test]
        public void TestConvContainerToEntitySize()
        {
            var conv = new ContainerConverter();

            ContainerBO containerBO = new ContainerBO() { Size = "Large" };

            Container container = new Container() { Size = "Large" };

            var result = conv.Convert(containerBO);
            var expected = container;

            Assert.AreEqual(result.Size, expected.Size);
        }

        [Test]
        public void TestConvContainerToEntityShipId()
        {
            var conv = new ContainerConverter();

            ContainerBO containerBO = new ContainerBO() { ShipmentId = 1 };

            Container container = new Container() { ShipmentId = 1 };

            var result = conv.Convert(containerBO);
            var expected = container;

            Assert.AreEqual(result.ShipmentId, expected.ShipmentId);
        }

        [Test]
        public void TestConvContainerToBusinessObjectId()
        {
            var conv = new ContainerConverter();

            Container container = new Container() { Id = 5 };

            ContainerBO containerBO = new ContainerBO() { Id = 5 };

            var result = conv.Convert(container);
            var expected = containerBO;

            Assert.AreEqual(result.Id, expected.Id);
        }

        [Test]
        public void TestConvContainerToBusinessObjectDan()
        {
            var conv = new ContainerConverter();

            Container container = new Container() { Dangerous = "No" };

            ContainerBO containerBO = new ContainerBO() { Dangerous = "No" };

            var result = conv.Convert(container);
            var expected = containerBO;

            Assert.AreEqual(result.Dangerous, expected.Dangerous);
        }

        [Test]
        public void TestConvContainerToBusinessObjectFr()
        {
            var conv = new ContainerConverter();

            Container container = new Container() { Frozen = "Yes" };

            ContainerBO containerBO = new ContainerBO() { Frozen = "Yes" };

            var result = conv.Convert(container);
            var expected = containerBO;

            Assert.AreEqual(result.Frozen, expected.Frozen);
        }

        [Test]
        public void TestConvContainerToBusinessObjectSize()
        {
            var conv = new ContainerConverter();

            Container container = new Container() { Size = "Small" };

            ContainerBO containerBO = new ContainerBO() { Size = "Small" };

            var result = conv.Convert(container);
            var expected = containerBO;

            Assert.AreEqual(result.Size, expected.Size);
        }

        [Test]
        public void TestConvContainerToBusinessObjectCN()
        {
            var conv = new ContainerConverter();

            Container container = new Container() { ContainerNumber = "2563" };

            ContainerBO containerBO = new ContainerBO() { ContainerNumber = "2563" };

            var result = conv.Convert(container);
            var expected = containerBO;

            Assert.AreEqual(result.ContainerNumber, expected.ContainerNumber);
        }

        [Test]
        public void TestConvContainerToBusinessObjectShipId()
        {
            var conv = new ContainerConverter();

            Container container = new Container() { ShipmentId = 5 };

            ContainerBO containerBO = new ContainerBO() { ShipmentId = 5 };

            var result = conv.Convert(container);
            var expected = containerBO;

            Assert.AreEqual(result.ShipmentId, expected.ShipmentId);
        }
    }
}
