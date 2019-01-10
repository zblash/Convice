using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Convice.Entities;
using Convice.Core.DataAccess.EF;
using Convice.Entities.IdentityEntities;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EF
{
    public class EfCategoryDal : EntityFrameworkRepositoryBase<Category, ConviceContext>, ICategoryDal
    {
        
        public async Task AddUsertoCategory(UserCategory userCategory)
        {
            using (var context = new ConviceContext())
            {
               
                var entry = context.Entry(userCategory);
                entry.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        

        public async Task<List<Category>> GetCategoriesByUser(string userId)
        {
            using (var context = new ConviceContext())
            {
               return await context.UserCategories.Where(e => e.UserId == userId).Select(mc => mc.Category).ToListAsync();
            }
        }

        public async Task<List<Category>> GetCategoryUsers(Category cat)
        {
            using (var context = new ConviceContext())
            {
                return await context.Categories.Include(e => e.Users).ThenInclude(e => e.User).ToListAsync();
            }
        }
    }

}
