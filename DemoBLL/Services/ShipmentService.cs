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
    public class ShipmentService : IService<ShipmentBO>
    {
        ShipmentConverter conv = new ShipmentConverter();
        CustomerConverter c = new CustomerConverter();
        ContainerConverter _convert = new ContainerConverter();
        DALFacade _facade;

        public ShipmentService(DALFacade facade)
        {
            _facade = facade;
        }

        public ShipmentBO Create(ShipmentBO bo)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newShipment = uow.ShipmentRepository.Create(conv.Convert(bo));
                uow.Complete();
                return conv.Convert(newShipment);
            }
        }

        public ShipmentBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newShipment = uow.ShipmentRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newShipment);
            }
        }

        public ShipmentBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var shipment = conv.Convert(uow.ShipmentRepository.Get(Id));

                shipment.Containers = uow.ContainerRepository.GetAll()
                    .Select(co => _convert.Convert(co)).ToList();

                shipment.Customer = c.Convert(uow.CustomerRepository.Get(shipment.CustomerId));

                return shipment;
            }
        }

        public List<ShipmentBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.ShipmentRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public ShipmentBO Update(ShipmentBO bo)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var shipmentFromDb = uow.ShipmentRepository.Get(bo.Id);
                if (shipmentFromDb == null)
                {
                    throw new InvalidOperationException("Shipment not found");
                }

                var shipmentUpdated = conv.Convert(bo);
                shipmentFromDb.ShipmentName = shipmentUpdated.ShipmentName;
                shipmentFromDb.Bill = shipmentUpdated.Bill;
                shipmentFromDb.CargoInfo = shipmentUpdated.CargoInfo;
                shipmentFromDb.ContainerQuantity = shipmentUpdated.ContainerQuantity;
                shipmentFromDb.Cost = shipmentUpdated.Cost;
                shipmentFromDb.CountryDelivery = shipmentUpdated.CountryDelivery;
                shipmentFromDb.CountryDeparture = shipmentUpdated.CountryDeparture;
                shipmentFromDb.FinishedDate = shipmentUpdated.FinishedDate;
                shipmentFromDb.HandlingDetail = shipmentUpdated.HandlingDetail;
                shipmentFromDb.Containers = shipmentUpdated.Containers;
                shipmentFromDb.CustomerId = shipmentUpdated.CustomerId;

                uow.Complete();
                return conv.Convert(shipmentFromDb);
            }
        }
    }
}
