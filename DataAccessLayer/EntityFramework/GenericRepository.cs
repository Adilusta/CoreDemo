using DataAccessLayer.Abstract;
using EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class GenericRepository<TEntity, TContext> : IGenericDal<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()

    {
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                    context.Remove(entity);
                    context.SaveChanges();
            }
        }

        
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
          
            using (TContext context = new TContext())
            {
                if (filter!= null)
                {
                    return context.Set<TEntity>().Where(filter).ToList();
                   
                }
                else
                {
                    return context.Set<TEntity>().ToList();
                }
               

            }
        }


        public TEntity GetEntityByID(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Find(id);

            }
        }

        public void Insert(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }

        public TEntity GetEntity(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).SingleOrDefault();
            }
        }
    }
}
