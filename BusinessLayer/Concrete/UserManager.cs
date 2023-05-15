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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void AddEntity(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public AppUser GetEntityByID(int id)
        {
          return  _userDal.GetEntity(x => x.Id == id);
        }

        public List<AppUser> GetListEntity()
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(AppUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
