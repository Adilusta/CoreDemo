using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal <TEntity> where TEntity : class,IEntity
    {
        
        void Insert (TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetEntityByID(int id);
    }
}
