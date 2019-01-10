using System.Collections.Generic;
using System.Threading.Tasks;
using Convice.Entities;

namespace Convice.Business.Abstract
{
    public interface ICategoryService
    {
        
        Task<List<Category>> GetAll();

        Task<Category> GetById(int id);

        Task Add(Category category);

        Task Delete(int categoryid);

        Task Update(Category category);

        Task AddUsertoCategory(UserCategory userCategory);

        Task<List<Category>> GetCategoriesByUser(string userId);

        Task<List<Category>> GetCategoryUsers(Category cat);
    }
}