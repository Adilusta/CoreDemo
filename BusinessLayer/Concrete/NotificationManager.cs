using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void AddEntity(Notification entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Notification entity)
        {
            throw new NotImplementedException();
        }

        public Notification GetEntityByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetListEntity()
        {
          return  _notificationDal.GetAll();
        }

        public void UpdateEntity(Notification entity)
        {
            throw new NotImplementedException();
        }
    }
}
