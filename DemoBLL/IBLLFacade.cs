using BLL.BusinessObjects;
using DemoBLL;
using System;
namespace BLL
{
    public interface IBLLFacade
    {
        IService<ShipmentBO> ShipmentService { get; }
        IService<CustomerBO> CustomerService { get; }
        IService<UserBO> UserService { get; }
        IService<ContainerBO> ContainerService { get; }
    }
}
