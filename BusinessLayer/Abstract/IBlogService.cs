using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IService <Blog>
    {
        List<Blog> GetBlogsWithCategory();
        List<Blog> GetBlogsByWriter(int WriterID);
        List<Blog> GetLastThreeBlogs();
        List<Blog> GetListWithCategoryByWriter(int writerID);

    }
}
