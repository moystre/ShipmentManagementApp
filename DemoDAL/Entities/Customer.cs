using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WarehouseAddress { get; set; }
        public int ShipmentId { get; set; }
        public List<Shipment> Shipments { get; set; }
    }
}
