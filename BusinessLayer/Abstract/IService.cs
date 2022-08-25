using EntityLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
        TEntity GetEntity(int id);
    }
}
