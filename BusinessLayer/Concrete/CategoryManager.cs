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

        //Kategori ekler
        public void AddEntity(Category entity)
        {
            _categoryDal.Insert(entity);
        }
        public void DeleteEntity(Category entity)
        {
            _categoryDal.Delete(entity);
        }
        public Category GetCategoryByCategoryID(int id)
        {
            return _categoryDal.GetEntity(p => p.CategoryID == id);
        }

        public List<Category> GetListEntity()
        {
            return _categoryDal.GetAll();
        }
        public void UpdateEntity(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
