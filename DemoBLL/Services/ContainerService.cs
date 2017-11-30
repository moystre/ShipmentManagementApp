using BLL.BusinessObjects;
using BLL.Converters;
using DAL.Facade;
using DemoBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class ContainerService : IService<ContainerBO>
    {
        ContainerConverter conv = new ContainerConverter();
        DALFacade _facade;

        public ContainerService(DALFacade facade)
        {
            _facade = facade;
        }

        public ContainerBO Create(ContainerBO bo)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newContainer = uow.ContainerRepository.Create(conv.Convert(bo));
                uow.Complete();
                return conv.Convert(newContainer);
            }
        }

        public ContainerBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newContainer = uow.ContainerRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newContainer);
            }
        }

        public ContainerBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var container = conv.Convert(uow.ContainerRepository.Get(Id));
                return container;
            }
        }

        public List<ContainerBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.ContainerRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public ContainerBO Update(ContainerBO bo)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var containerFromDb = uow.ContainerRepository.Get(bo.Id);
                if (containerFromDb == null)
                {
                    throw new InvalidOperationException("Container not found");
                }

                var containerUpdated = conv.Convert(bo);
                containerFromDb.ContainerNumber = containerUpdated.ContainerNumber;
                containerFromDb.Dangerous = containerUpdated.Dangerous;
                containerFromDb.Frozen = containerUpdated.Frozen;
                containerFromDb.Size = containerUpdated.Size;

                uow.Complete();
                return conv.Convert(containerFromDb);
            }
        }
    }
}
