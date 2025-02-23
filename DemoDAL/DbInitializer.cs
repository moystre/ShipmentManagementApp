﻿using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DAL
{
    public static class DbInitializer
    {

        // This method will create and seed the database.
        public static void Initialize(ShipmentContext context)
        {
            if (context==null)
            {
                Debug.WriteLine("context is null");
                //throw new NullReferenceException();
                context = new ShipmentContext(new DbContextOptions<ShipmentContext>
                {
                    
                });
            }
            // Delete the database, if it already exists. I do this because an
            // existing database may not be compatible with the entity model,
            // if the entity model was changed since the database was created.
            context.Database.EnsureDeleted();
            Debug.WriteLine("DB EnsureDeleted");

            // Create the database, if it does not already exists. This operation
            // is necessary, if you use an SQL Server database.
            context.Database.EnsureCreated();
            Debug.WriteLine("DB EnsureCreated");

            // Look for any TodoItems
            //if (context.TodoItems.Any())
            //{
            //    return;   // DB has been seeded
            //}

            //List<TodoItem> items = new List<TodoItem>
            //{
            //    new TodoItem { IsComplete=true, CustomerName="Deploy TodoApi"}
            //};

            // Create two users with hashed and salted passwords
            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<User> users = new List<User>
            {
                new User {
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe
                },
                new User {
                    Username = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn
                }
            };

            //context.TodoItems.AddRange(items);
            context.Users.AddRange(users);
            context.SaveChanges();

        }

        // This method computes a hashed and salted password using the HMACSHA512 algorithm.
        // The HMACSHA512 class computes a Hash-based Message Authentication Code (HMAC) using 
        // the SHA512 hash function. When instantiated with the parameterless constructor (as
        // here) a randomly Key is generated. This key is used as a password salt.

        // The computation is performed as shown below:
        //   passwordHash = SHA512(password + Key)

        // A password salt randomizes the password hash so that two identical passwords will
        // have significantly different hash values. This protects against sophisticated attempts
        // to guess passwords, such as a rainbow table attack.
        // The password hash is 512 bits (=64 bytes) long.
        // The password salt is 1024 bits (=128 bytes) long.
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
