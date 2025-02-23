﻿using BLL.BusinessObjects;
using DAL.Entities;
using DemoBLL.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
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
                ShipmentName = businessObject.ShipmentName,
                Bill = businessObject.Bill,
                CargoInfo = businessObject.CargoInfo,
                ContainerQuantity = businessObject.ContainerQuantity,
                Cost = businessObject.Cost,
                CountryDelivery = businessObject.CountryDelivery,
                CountryDeparture = businessObject.CountryDeparture,
                FinishedDate = businessObject.FinishedDate,
                HandlingDetail = businessObject.HandlingDetail,
                Containers = businessObject.ContainerIds?.Select(coId => new Container()
                {
                    Id = coId
                }).ToList(),
                CustomerId = businessObject.CustomerId
            };
        }

        public ShipmentBO Convert(Shipment entity)
        {
            if (entity == null) { return null; }
            return new ShipmentBO()
            {
                Id = entity.Id,
                ShipmentName = entity.ShipmentName,
                Bill = entity.Bill,
                CargoInfo = entity.CargoInfo,
                ContainerQuantity = entity.ContainerQuantity,
                Cost = entity.Cost,
                CountryDelivery = entity.CountryDelivery,
                CountryDeparture = entity.CountryDeparture,
                FinishedDate = entity.FinishedDate,
                HandlingDetail = entity.HandlingDetail,
                CustomerId = entity.CustomerId,
                Customer = new CustomerConverter().Convert(entity.Customer),
                ContainerIds = entity.Containers?.Select(co => co.Id).ToList()
            };
        }
    }
}
