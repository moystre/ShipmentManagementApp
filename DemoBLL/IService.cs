using DemoBLL.BusinessObjects;
using System.Collections.Generic;

namespace DemoBLL
{
    public interface IService<IEntityBO>
    {
        //C
        IEntityBO Create(IEntityBO cust);
        //R
        List<IEntityBO> GetAll();
        IEntityBO Get(int Id);
        //U
        IEntityBO Update(IEntityBO cust);
        //D
        IEntityBO Delete(int Id);
    }
    
}
