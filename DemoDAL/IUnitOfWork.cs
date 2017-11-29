using DAL.Entities;
using System;
namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<Shipment> ShipmentRepository { get; }
        IRepository<Customer> CustomerRepository { get; }

        int Complete();
    }
}
