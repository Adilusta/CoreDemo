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
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newsLetterDal;
        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }
        public void AddEntity(NewsLetter entity)
        {
            _newsLetterDal.Insert(entity);
        }

        public void DeleteEntity(NewsLetter entity)
        {
            _newsLetterDal.Delete(entity);
        }

        public List<NewsLetter> GetListEntity()
        {
           return  _newsLetterDal.GetAll();
        }

        public void UpdateEntity(NewsLetter entity)
        {
             _newsLetterDal.Update(entity);
        }
    }
}
