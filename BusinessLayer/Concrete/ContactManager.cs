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
	
	public class ContactManager : IContactService
	{
		IContactDal _contactDal;

		public ContactManager(IContactDal contactDal)
		{
			_contactDal = contactDal;
		}
        public Contact GetEntityByID(int id)
        {
            return _contactDal.GetEntity(x => x.ContactID == id);
        }
        public List<Contact> GetListEntity()
        {
            return _contactDal.GetAll();
        }
        public void AddEntity(Contact entity)
		{
			_contactDal.Insert(entity);
		}

		public void DeleteEntity(Contact entity)
		{
			_contactDal.Delete(entity);
		}
		public void UpdateEntity(Contact entity)
		{
			_contactDal.Update(entity);
		}
	}
}
