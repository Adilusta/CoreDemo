using EntityLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IService<TEntity>
        where TEntity : class, IEntity,new()
    {
        void AddEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
        void UpdateEntity(TEntity entity);
        List<TEntity> GetListEntity();
        TEntity GetEntityByID(int id);
    }
}
