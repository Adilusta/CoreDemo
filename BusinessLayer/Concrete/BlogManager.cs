using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public void AddEntity(Blog entity)
        {
            _blogDal.Insert(entity);
        }

        public void DeleteEntity(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public Blog GetEntity(int id)
        {
            return _blogDal.GetEntityByID(id);
        }

        public List<Blog> GetListEntity()
        {
            return _blogDal.GetAll();
        }

        public void UpdateEntity(Blog entity)
        {
            _blogDal.Update(entity);
        }
    }
}
