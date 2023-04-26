using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void AddEntity(Message entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Message entity)
        {
            throw new NotImplementedException();
        }

        public Message GetEntityByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetListEntity()
        {
            return _messageDal.GetAll();
        }
        public void UpdateEntity(Message entity)
        {
            throw new NotImplementedException();
        }
        public List<Message> GetInboxListByWriter(string writerMail)
        {
            return _messageDal.GetAll(x=> x.Receiver==writerMail);
        }
    }
}
