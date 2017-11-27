using BLL.BusinessObjects;
using DemoBLL;
using System;
namespace BLL
{
    public interface IBLLFacade
    {
        IService<ShipmentBO> ShipmentService { get; }
        IService<UserBO> UserService { get; }
    }
}
