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
                    throw new InvalidOperationException("Customer not found");
                }

                var shipmentUpdated = conv.Convert(bo);
                shipmentFromDb.Bill = shipmentUpdated.Bill;
                shipmentFromDb.CargoInfo = shipmentUpdated.CargoInfo;
                shipmentFromDb.ContainerQuantity = shipmentUpdated.ContainerQuantity;
                shipmentFromDb.Cost = shipmentUpdated.Cost;
                shipmentFromDb.CountryDelivery = shipmentUpdated.CountryDelivery;
                shipmentFromDb.CountryDepature = shipmentUpdated.CountryDepature;
                shipmentFromDb.Customer = shipmentUpdated.Customer;
                shipmentFromDb.FinishedDate = shipmentUpdated.FinishedDate;
                shipmentFromDb.HandlingDetail = shipmentUpdated.HandlingDetail;

                uow.Complete();
                return conv.Convert(shipmentFromDb);
            }
        }
    }
}
