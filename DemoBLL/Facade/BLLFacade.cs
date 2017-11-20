﻿using System;
using Microsoft.Extensions.Configuration;
using BLL;
using DAL;
using DAL.Facade;

namespace DemoBLL.Facade
{
    public class BLLFacade : IBLLFacade
    {
        private IDALFacade facade;

        public BLLFacade(IConfiguration conf){
            facade = new DALFacade(new DbOptions()
            {
                ConnectionString = conf.GetConnectionString("DefaultConnection"),
                Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            });
        }

        /*public IJokeService JokeService => 
            new JokeService(facade);**/

        //public IJokeService JokeService {
        //    get{ return new JokeService(facade); }
        //}
    }
}
