using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ShipmentContext _context;

        public UserRepository(ShipmentContext context)
        {
            _context = context;
        }

        public User Create(User address)
        {
            throw new NotImplementedException();
        }

        public User Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public User Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllById(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
