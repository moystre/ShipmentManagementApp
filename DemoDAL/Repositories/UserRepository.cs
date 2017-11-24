using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public User Create(User user)
        {
            _context.Users.Add(user);
            return user;
        }

        public User Delete(int Id)
        {
            var userToDelete = Get(Id);
            _context.Users.Remove(userToDelete);
            return userToDelete;
        }

        public User Get(int Id)
        {
            return _context.Users.FirstOrDefault(c => c.Id == Id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public IEnumerable<User> GetAllById(List<int> ids)
        {
            if (ids == null) { return null; }

            return _context.Users.Where(c => ids.Contains(c.Id));

        }
    }
}
