﻿using DemoDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoDAL.Context
{
    class EASVContext : DbContext
    {
        public EASVContext(DbContextOptions<EASVContext> options): base(options)  { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<Entity> Entites { get; set; }
        public DbSet<Joke> Jokes { get; set; }
    }
}