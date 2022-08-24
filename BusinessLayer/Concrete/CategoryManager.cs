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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void AddCategory(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
        }

        public List<Category> GetCategories()
        {
           return _categoryDal.GetAll();
        }

        public Category GetCategory(int id)
        {
            return _categoryDal.GetEntityByID(id);
        }

        public void UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
