﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Convice.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Convice.Core.DataAccess.EF
{
    public class EntityFrameworkRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
    where TEntity: class, IEntity, new()
    where TContext: DbContext, new()
    {
        public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().Where(filter).SingleOrDefaultAsync();
            }
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var entry = context.Entry(entity);
                entry.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var entry = context.Entry(entity);
                entry.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
            
        }

        public async Task Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var entry = context.Entry(entity);
                entry.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
