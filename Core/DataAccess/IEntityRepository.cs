﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Convice.Core.Entities.Abstract;

namespace Convice.Core.DataAccess
{
    public interface IEntityRepository<T> 
        where T: class,IEntity,new()
    {
        Task<T> Get(Expression<Func<T,bool>> filter = null);

        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);

        Task Add(T entity);

        Task Delete(T entity);

        Task Update(T entity);
    }
}
