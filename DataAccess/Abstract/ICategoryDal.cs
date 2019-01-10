using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Convice.Core.DataAccess;
using Convice.Entities;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        Task AddUsertoCategory(UserCategory userCategory);

        Task<List<Category>> GetCategoriesByUser(string userId);

        Task<List<Category>> GetCategoryUsers(Category cat);
    }
}
