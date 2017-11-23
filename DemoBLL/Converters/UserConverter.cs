using BLL.BusinessObjects;
using DAL.Entities;
using DemoBLL.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class UserConverter : IConverter<User, UserBO>
    {
        public User Convert(UserBO businessObject)
        {
            if (businessObject == null) { return null; }
            return new User()
            {
                Id = businessObject.Id,
                Username = businessObject.Username,
                IsAdmin = businessObject.IsAdmin,
                PasswordHash = businessObject.PasswordHash,
                PasswordSalt = businessObject.PasswordSalt
            };
        }

        public UserBO Convert(User entity)
        {
            if (entity == null) { return null; }
            return new UserBO()
            {
                Id = entity.Id,
                Username = entity.Username,
                IsAdmin = entity.IsAdmin,
                PasswordHash = entity.PasswordHash,
                PasswordSalt = entity.PasswordSalt
            };
        }
    }
}
