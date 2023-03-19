using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    
    public class AboutManager : IAboutService
	{
		IAboutDal _aboutDal;

		public AboutManager(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}
        public About GetEntityByID(int id)
        {
            return _aboutDal.GetEntity(x => x.AboutID == id);
        }
        public List<About> GetListEntity()
        {
            return _aboutDal.GetAll();
        }

        public void AddEntity(About entity)
		{
			_aboutDal.Insert(entity);
		}

		public void DeleteEntity(About entity)
		{
			_aboutDal.Delete(entity);
		}


		public void UpdateEntity(About entity)
		{
			 _aboutDal.Update(entity);
		}
	}
}
