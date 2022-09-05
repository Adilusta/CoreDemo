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
	public class WriterManager : IWriterService
	{
		private IWriterDal _writerDal;

		public WriterManager(IWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

		public void AddEntity(Writer entity)
		{
			_writerDal.Insert(entity);
		}

		public void DeleteEntity(Writer entity)
		{
			_writerDal.Delete(entity);
		}

		public List<Writer> GetListEntity()
		{
		return	_writerDal.GetAll();
		}

		public void UpdateEntity(Writer entity)
		{
			_writerDal.Update(entity); 
		}
	}
}
