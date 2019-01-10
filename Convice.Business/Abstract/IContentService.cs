using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Convice.Entities;

namespace Convice.Business.Abstract
{
    public interface IContentService
    {
        Task<List<Content>> GetAll();

        Task<Content> GetById(int id);

        Task<List<Content>> GetByCategoryId(int id);

        Task Add(Content content);

        Task Delete(int contentId);

        Task Update(Content content);
    }
}
