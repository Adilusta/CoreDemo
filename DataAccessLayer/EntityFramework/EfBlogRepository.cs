using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog, Context>, IBlogDal
    {
        public List<Blog> GetListBlogsWithCategory()
        {
            using (Context context = new Context())
            {
                return context.Blogs.Include(x => x.Category).ToList();
            }
          
        }
    }
}
