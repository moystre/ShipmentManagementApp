using DemoBLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessObjects
{
    public class ShipmentBO : IBusinessObject
    {
        public int Id { get; set; }
        public string ShipmentName { get; set; }
        public string CargoInfo { get; set; }
        public string CountryDeparture { get; set; }
        public string CountryDelivery { get; set; }
        public int ContainerQuantity { get; set; }
        public string HandlingDetail { get; set; }
        public string FinishedDate { get; set; }
        public double Bill { get; set; }
        public double Cost { get; set; }
        public int CustomerId { get; set; }
        public CustomerBO Customer { get; set; }
    }
}
