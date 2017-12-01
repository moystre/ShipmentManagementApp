using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Shipment : IEntity
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
        public Customer Customer { get; set; }
        public List<Container> Containers { get; set; }
    }
}
