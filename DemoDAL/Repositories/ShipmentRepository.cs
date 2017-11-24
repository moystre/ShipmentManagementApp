using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class ShipmentRepository : IRepository<Shipment>
    {
        private readonly ShipmentContext _context;

        public ShipmentRepository(ShipmentContext context)
        {
            _context = context;
        }

        public Shipment Create(Shipment entity)
        {
            _context.Shipments.Add(entity);
            return entity;
        }

        public Shipment Delete(int Id)
        {
            var shipmentToDelete = Get(Id);
            _context.Shipments.Remove(shipmentToDelete);
            return shipmentToDelete;
        }

        public Shipment Get(int Id)
        {
            return _context.Shipments.FirstOrDefault(c => c.Id == Id);
        }

        public IEnumerable<Shipment> GetAll()
        {
            return _context.Shipments;
        }

        public IEnumerable<Shipment> GetAllById(List<int> ids)
        {
            if (ids == null) { return null; }

            return _context.Shipments.Where(c => ids.Contains(c.Id));
        }
    }
}
