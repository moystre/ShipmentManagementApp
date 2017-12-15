using BLL.BusinessObjects;
using DemoBLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IContainerService : IService<ContainerBO>
    {
        IEnumerable<ContainerBO> GetAllByShipmentId(int t, int ps, int cp);
    }
}
