using System;
using DemoDAL.Context;
using DemoDAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DemoDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IJokeRepository JokeRepository { get;  internal set; }
        private EASVContext _context;
        private static DbContextOptions<EASVContext> optionsStatic;
           
        public UnitOfWork(DbOptions opt)
        {
             if(opt.Environment == "Development" && String.IsNullOrEmpty(opt.ConnectionString)){
                optionsStatic = new DbContextOptionsBuilder<EASVContext>()
                   .UseInMemoryDatabase("TheDB")
                   .Options;
                _context = new EASVContext(optionsStatic);
            }
            else{
                var options = new DbContextOptionsBuilder<EASVContext>()
                .UseSqlServer(opt.ConnectionString)
                    .Options;
                _context = new EASVContext(options);
            }

            JokeRepository = new JokeRepository(_context);
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
