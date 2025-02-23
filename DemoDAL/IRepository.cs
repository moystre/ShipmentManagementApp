﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IRepository<IEntity>
    {
        //C
        IEntity Create(IEntity entity);
        //R
        IEnumerable<IEntity> GetAll();
        IEnumerable<IEntity> GetAllById(List<int> ids);
        IEntity Get(int Id);
        //U
        //No Update for Repository, It will be the task of Unit of Work
        //D
        IEntity Delete(int Id);
    }
}
