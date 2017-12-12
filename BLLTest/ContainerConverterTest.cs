using BLL.BusinessObjects;
using BLL.Converters;
using DAL.Entities;
using NUnit.Framework;

namespace BLLTest
{
    [TestFixture]
    class ContainerConverterTest
    {
        ContainerConverter converter = new ContainerConverter();

        [Test]
        public void TestConvContainerEntityToNull()
        {
            Container ent = converter.Convert((ContainerBO)null);

            Assert.IsNull(ent);
        }

        [Test]
        public void TestConvContainerBusinessObjectToNull()
        {
            ContainerBO bo = converter.Convert((Container)null);

            Assert.IsNull(bo);
        }

        [Test]
        public void TestConvContainerToEntityId()
        {
            ContainerBO containerBO = new ContainerBO() {Id = 2 };

            Container container = new Container() { Id = 2 };

            var result = converter.Convert(containerBO);
            var expected = container;

            Assert.AreEqual(result.Id, expected.Id);
        }

        [Test]
        public void TestConvContainerToEntityCN()
        {
            ContainerBO containerBO = new ContainerBO() { ContainerNumber = "232" };

            Container container = new Container() { ContainerNumber = "232" };

            var result = converter.Convert(containerBO);
            var expected = container;

            Assert.AreEqual(result.ContainerNumber, expected.ContainerNumber);
        }

        [Test]
        public void TestConvContainerToEntityDan()
        {
            ContainerBO containerBO = new ContainerBO() { Dangerous = "Yes" };

            Container container = new Container() { Dangerous = "Yes" };

            var result = converter.Convert(containerBO);
            var expected = container;

            Assert.AreEqual(result.Dangerous, expected.Dangerous);
        }

        [Test]
        public void TestConvContainerToEntityFr()
        {
            ContainerBO containerBO = new ContainerBO() { Frozen = "Yes" };
            
            Container container = new Container() { Frozen = "Yes" };

            var result = converter.Convert(containerBO);
            var expected = container;

            Assert.AreEqual(result.Frozen, expected.Frozen);
        }

        [Test]
        public void TestConvContainerToEntitySize()
        {
            ContainerBO containerBO = new ContainerBO() { Size = "Large" };

            Container container = new Container() { Size = "Large" };

            var result = converter.Convert(containerBO);
            var expected = container;

            Assert.AreEqual(result.Size, expected.Size);
        }

        [Test]
        public void TestConvContainerToEntityShipId()
        {
            ContainerBO containerBO = new ContainerBO() { ShipmentId = 1 };

            Container container = new Container() { ShipmentId = 1 };

            var result = converter.Convert(containerBO);
            var expected = container;

            Assert.AreEqual(result.ShipmentId, expected.ShipmentId);
        }

        [Test]
        public void TestConvContainerToBusinessObjectId()
        {
            Container container = new Container() { Id = 5 };

            ContainerBO containerBO = new ContainerBO() { Id = 5 };

            var result = converter.Convert(container);
            var expected = containerBO;

            Assert.AreEqual(result.Id, expected.Id);
        }

        [Test]
        public void TestConvContainerToBusinessObjectDan()
        {
            Container container = new Container() { Dangerous = "No" };

            ContainerBO containerBO = new ContainerBO() { Dangerous = "No" };

            var result = converter.Convert(container);
            var expected = containerBO;

            Assert.AreEqual(result.Dangerous, expected.Dangerous);
        }

        [Test]
        public void TestConvContainerToBusinessObjectFr()
        {
            Container container = new Container() { Frozen = "Yes" };

            ContainerBO containerBO = new ContainerBO() { Frozen = "Yes" };

            var result = converter.Convert(container);
            var expected = containerBO;

            Assert.AreEqual(result.Frozen, expected.Frozen);
        }

        [Test]
        public void TestConvContainerToBusinessObjectSize()
        {
            Container container = new Container() { Size = "Small" };

            ContainerBO containerBO = new ContainerBO() { Size = "Small" };

            var result = converter.Convert(container);
            var expected = containerBO;

            Assert.AreEqual(result.Size, expected.Size);
        }

        [Test]
        public void TestConvContainerToBusinessObjectCN()
        {
            Container container = new Container() { ContainerNumber = "2563" };

            ContainerBO containerBO = new ContainerBO() { ContainerNumber = "2563" };

            var result = converter.Convert(container);
            var expected = containerBO;

            Assert.AreEqual(result.ContainerNumber, expected.ContainerNumber);
        }

        [Test]
        public void TestConvContainerToBusinessObjectShipId()
        {
            Container container = new Container() { ShipmentId = 5 };

            ContainerBO containerBO = new ContainerBO() { ShipmentId = 5 };

            var result = converter.Convert(container);
            var expected = containerBO;

            Assert.AreEqual(result.ShipmentId, expected.ShipmentId);
        }
    }
}
