using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentRepository : GenericRepository<Comment, Context>, ICommentDal
    {
        public List<Comment> GetCommentListWithBlog()
        {
            using (Context context = new Context())
            {
                return context.Comments.Include(x => x.Blog).ToList();
            } 
        }

        public Comment GetCommentWithBlogByCommentID(int id)
        {
            using (Context context = new Context())
            {
                return context.Comments.Include(x=>x.Blog).Where(y=>y.CommentID==id).SingleOrDefault();
            }
        }
    }
}
