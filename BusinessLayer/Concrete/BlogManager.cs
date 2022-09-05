using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public List<Blog> GetListEntity()
        {
            return _blogDal.GetAll();
        }
        public void AddEntity(Blog entity)
        {
            _blogDal.Insert(entity);
        }

        public void DeleteEntity(Blog entity)
        {
            _blogDal.Delete(entity);
        }


        public void UpdateEntity(Blog entity)
        {
            _blogDal.Update(entity);
        }

        public List<Blog> GetBlogsWithCategory()
        {
          return _blogDal.GetListBlogsWithCategory();
        }

        public Blog GetBlogByBlogID(int id)
        {
            return _blogDal.GetEntity(p=>p.BlogId==id);
        }

        public List<Blog> GetBlogsByWriter(int writerID)
        {
            return _blogDal.GetAll(p=> p.WriterID==writerID);
        }
    }
}
