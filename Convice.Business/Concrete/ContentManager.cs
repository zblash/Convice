using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Convice.Business.Abstract;
using Convice.Entities;
using DataAccess.Abstract;

namespace Convice.Business.Concrete
{
    public class ContentManager : IContentService
    {
        private IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public async Task<Content> GetById(int id)
        {
            return await _contentDal.Get(c => c.Id == id);
        }
        
        public async Task Add(Content content)
        {
            await _contentDal.Add(content);
        }

        public async Task Delete(int contentId)
        {
           await _contentDal.Delete(new Content {Id = contentId});
        }

        public async Task<List<Content>> GetAll()
        {
            return await _contentDal.GetList();
        }


        public async Task<List<Content>> GetByCategoryId(int id)
        {
            return await _contentDal.GetList(c => c.CategoryId == id);
        }

        public async Task Update(Content content)
        {
            await _contentDal.Update(content);
        }
    }
}
