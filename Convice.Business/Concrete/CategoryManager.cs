using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Convice.Business.Abstract;
using Convice.Entities;
using DataAccess.Abstract;

namespace Convice.Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _categoryDal.GetList();
        }

        public async Task<Category> GetById(int id)
        {
            return await _categoryDal.Get(c => c.Id == id);
        }

        public async Task Add(Category category)
        {
            await _categoryDal.Add(category);
        }

        public async Task Delete(int categoryid)
        {
            await _categoryDal.Delete(new Category{Id = categoryid});
        }

        public async Task Update(Category category)
        {
            await _categoryDal.Update(category);
        }

        public async Task AddUsertoCategory(UserCategory userCategory)
        {
            await _categoryDal.AddUsertoCategory(userCategory);
        }

        public async Task<List<Category>> GetCategoriesByUser(string userId)
        {
            return await _categoryDal.GetCategoriesByUser(userId);
        }

        public async Task<List<Category>> GetCategoryUsers(Category cat)
        {
            return await _categoryDal.GetCategoryUsers(cat);
        }
    }
}
