using DAL.Entities;
using System;
namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }

        int Complete();
    }
}
