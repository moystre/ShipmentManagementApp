using System;
using Microsoft.Extensions.Configuration;
using BLL;
using DAL;
using DAL.Facade;
using BLL.BusinessObjects;
using BLL.Services;

namespace DemoBLL.Facade
{
    public class BLLFacade : IBLLFacade
    {
        private DALFacade facade;
        
        public BLLFacade(IConfiguration conf)
        {
            facade = new DALFacade(new DbOptions()
            {
                ConnectionString = conf.GetConnectionString("ShipmentConnection"),
                Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            });
        }

        public IService<UserBO> UserService
        {
            get { return new UserService(facade); }
        }
        
        public IService<ShipmentBO> ShipmentService
        {
            get { return new ShipmentService(facade); }
        }

        public IService<CustomerBO> CustomerService
        {
            get { return new CustomerService(facade); }
        }

        public IService<ContainerBO> ContainerService
        {
            get { return new ContainerService(facade); }
        }
    }
}
