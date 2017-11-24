using BLL.BusinessObjects;
using DAL.Entities;
using DemoBLL.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class ShipmentConverter : IConverter<Shipment, ShipmentBO>
    {
        public Shipment Convert(ShipmentBO businessObject)
        {
            if (businessObject == null) { return null; }
            return new Shipment()
            {
                Id = businessObject.Id,
                Bill = businessObject.Bill,
                CargoInfo = businessObject.CargoInfo,
                ContainerQuantity = businessObject.ContainerQuantity,
                Cost = businessObject.Cost,
                CountryDelivery = businessObject.CountryDelivery,
                CountryDepature = businessObject.CountryDepature,
                Customer = businessObject.Customer,
                FinishedDate = businessObject.FinishedDate,
                HandlingDetail = businessObject.HandlingDetail
            };
        }

        public ShipmentBO Convert(Shipment entity)
        {
            if (entity == null) { return null; }
            return new ShipmentBO()
            {
                Id = entity.Id,
                Bill = entity.Bill,
                CargoInfo = entity.CargoInfo,
                ContainerQuantity = entity.ContainerQuantity,
                Cost = entity.Cost,
                CountryDelivery = entity.CountryDelivery,
                CountryDepature = entity.CountryDepature,
                Customer = entity.Customer,
                FinishedDate = entity.FinishedDate,
                HandlingDetail = entity.HandlingDetail
            };
        }
    }
}
