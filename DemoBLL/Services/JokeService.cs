using System;
using System.Collections.Generic;
using DemoBLL.BusinessObjects;
using DemoBLL.Converters;
using DemoDAL;
using DemoDAL.Entities;
using DemoDAL.Facade;

namespace DemoBLL.Services
{
    public class JokeService : IJokeService
    {
        private IDALFacade _facade;
        private IConverter<Joke, JokeBO> jConverter;
        public JokeService(IDALFacade facade)
        {
            _facade = facade;
            jConverter = new JokeConverter();
        }

        public JokeBO Create(JokeBO joke)
        {
            throw new NotImplementedException();
        }

        public JokeBO Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public JokeBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return jConverter.Convert(
                    uow.JokeRepository.Get(Id));
            }
        }

        public List<JokeBO> GetAll()
        {
            throw new NotImplementedException();
        }

        public JokeBO Update(JokeBO joke)
        {
            throw new NotImplementedException();
        }
    }
}
