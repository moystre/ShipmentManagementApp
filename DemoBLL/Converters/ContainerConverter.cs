using BLL.BusinessObjects;
using DAL.Entities;
using DemoBLL.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class ContainerConverter : IConverter<Container, ContainerBO>
    {
        public Container Convert(ContainerBO businessObject)
        {
            if (businessObject == null) { return null; }
            return new Container()
            {
                Id = businessObject.Id,
                ContainerNumber = businessObject.ContainerNumber,
                Dangerous = businessObject.Dangerous,
                Frozen = businessObject.Frozen,
                Size = businessObject.Size,
                ShipmentId = businessObject.ShipmentId
            };
        }

        public ContainerBO Convert(Container entity)
        {
            if (entity == null) { return null; }
            return new ContainerBO()
            {
                Id = entity.Id,
                ContainerNumber = entity.ContainerNumber,
                Dangerous = entity.Dangerous,
                Frozen = entity.Frozen,
                Size = entity.Size,
                ShipmentId = entity.ShipmentId
            };
        }
    }
}
