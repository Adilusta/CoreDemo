using DataAccessLayer.Abstract;
using EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class GenericRepository<TEntity, TContext> : IGenericDal<TEntity> where TEntity : class, IEntity, new()
                                                                            where TContext : DbContext, new()
    {
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList();

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
    }
}
