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
    public class ContainerService : IContainerService
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
                var container = uow.ContainerRepository.Get(Id);
                return conv.Convert(container);
            }
        }

        public List<ContainerBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.ContainerRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public IEnumerable<ContainerBO> GetAllByShipmentId(int t, int ps, int cp)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var skip = (ps * cp) - ps;
                return uow.ContainerRepository.GetAll()
                    .Where(co => co.ShipmentId.Equals(t))
                    .Skip(skip)
                    .Take(ps)
                    .Select(co => conv.Convert(co))
                    .ToList();
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
