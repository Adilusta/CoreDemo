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
    public class AdminManager : IAdminService
    {
        private IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AddEntity(Admin entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Admin entity)
        {
            throw new NotImplementedException();
        }

        public Admin GetEntityByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetListEntity()
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
