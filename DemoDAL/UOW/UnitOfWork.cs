﻿using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories;

namespace DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<User> UserRepository { get; internal set; }
        public IRepository<Shipment> ShipmentRepository { get; internal set; }
        public IRepository<Customer> CustomerRepository { get; internal set; }
        public IRepository<Container> ContainerRepository { get; internal set; }
        private ShipmentContext _context;
        private static DbContextOptions<ShipmentContext> optionsStatic;
           
        public UnitOfWork(DbOptions opt)
        {
             if(opt.Environment == "Development" && String.IsNullOrEmpty(opt.ConnectionString)){
                optionsStatic = new DbContextOptionsBuilder<ShipmentContext>()
                   .UseInMemoryDatabase("TheDB")
                   .Options;
                _context = new ShipmentContext(optionsStatic);
            }
            else{
                var options = new DbContextOptionsBuilder<ShipmentContext>()
                .UseSqlServer(opt.ConnectionString)
                    .Options;
                _context = new ShipmentContext(options);
            }

            UserRepository = new UserRepository(_context);
            ShipmentRepository = new ShipmentRepository(_context);
            CustomerRepository = new CustomerRepository(_context);
            ContainerRepository = new ContainerRepository(_context);
        }

        public int Complete()
		{
			//The number of objects written to the underlying database.
            return _context.SaveChanges();
		}

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
