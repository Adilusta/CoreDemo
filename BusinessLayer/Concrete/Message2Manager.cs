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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public void AddEntity(Message2 entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Message2 entity)
        {
            throw new NotImplementedException();
        }

        public Message2 GetEntityByID(int id)
        {
            return _message2Dal.GetEntity(x=> x.MessageID==id);
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            return _message2Dal.GetListWithMessageByWriter(id);
        }

        public List<Message2> GetListEntity()
        {
            return _message2Dal.GetAll();
        }

        public void UpdateEntity(Message2 entity)
        {
            throw new NotImplementedException();
        }
    }
}
