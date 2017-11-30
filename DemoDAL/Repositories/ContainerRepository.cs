using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class ContainerRepository : IRepository<Container>
    {
        private readonly ShipmentContext _context;

        public ContainerRepository(ShipmentContext context)
        {
            _context = context;
        }

        public Container Create(Container entity)
        {
            _context.Containers.Add(entity);
            return entity;
        }

        public Container Delete(int Id)
        {
            var containerToDelete = Get(Id);
            _context.Containers.Remove(containerToDelete);
            return containerToDelete;
        }

        public Container Get(int Id)
        {
            return _context.Containers.FirstOrDefault(c => c.Id == Id);
        }

        public IEnumerable<Container> GetAll()
        {
            return _context.Containers;
        }

        public IEnumerable<Container> GetAllById(List<int> ids)
        {
            if (ids == null) { return null; }

            return _context.Containers.Where(c => ids.Contains(c.Id));
        }
    }
}
