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
	public class CommentManager : ICommentService
	{
		ICommentDal _commentDal;
		public CommentManager(ICommentDal commentDal)
		{
			_commentDal = commentDal;
		}
        public Comment GetEntityByID(int id)
        {
            return _commentDal.GetEntity(x => x.CommentID == id);

        }
        public List<Comment> GetListEntity()
        {
            return _commentDal.GetAll();
        }
        public void AddEntity(Comment entity)
		{
			_commentDal.Insert(entity);
			
		}

		public void DeleteEntity(Comment entity)
		{
			_commentDal.Delete(entity);
		}
		public List<Comment> GetListCommentByBlogID(int id)
		{
			return _commentDal.GetAll(p=> p.BlogId==id);
		}
		public void UpdateEntity(Comment entity)
		{
			_commentDal.Update(entity);
			
		}

        public List<Comment> GetListCommentWithBlog()
        {
           return _commentDal.GetCommentListWithBlog();
        }

        public Comment GetCommentWithBlogByCommentID(int id)
        {
			return _commentDal.GetCommentWithBlogByCommentID(id);
        }
    }
}
