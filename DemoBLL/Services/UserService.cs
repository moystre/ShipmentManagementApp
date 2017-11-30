using BLL.BusinessObjects;
using BLL.Converters;
using DAL.Facade;
using DemoBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class UserService : IService<UserBO>
    {
        UserConverter conv = new UserConverter();
        DALFacade _facade;

        public UserService(DALFacade facade)
        {
            _facade = facade;
        }

        public UserBO Create(UserBO bo)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newUser = uow.UserRepository.Create(conv.Convert(bo));
                uow.Complete();
                return conv.Convert(newUser);
            }
        }

        public UserBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newUser = uow.UserRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newUser);
            }
        }

        public UserBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var user = conv.Convert(uow.UserRepository.Get(Id));
                return user;
            }
        }

        public List<UserBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.UserRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public UserBO Update(UserBO bo)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var userFromDb = uow.UserRepository.Get(bo.Id);
                if (userFromDb == null)
                {
                    throw new InvalidOperationException("User not found");
                }

                var userUpdated = conv.Convert(bo);
                userFromDb.Username = userUpdated.Username;
                userFromDb.PasswordHash = userUpdated.PasswordHash;
                userFromDb.PasswordSalt = userUpdated.PasswordSalt;

                uow.Complete();
                return conv.Convert(userFromDb);
            }
        }
    }
}
