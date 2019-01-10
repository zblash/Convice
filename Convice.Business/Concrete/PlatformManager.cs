using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Convice.Business.Abstract;
using Convice.Entities;
using DataAccess.Abstract;

namespace Convice.Business.Concrete
{
    public class PlatformManager:IPlatformService
    {
        private IPlatformDal _platformDal;

        public PlatformManager(IPlatformDal platformDal)
        {
            _platformDal = platformDal;
        }

        public async Task<List<Platform>> GetAll()
        {
           return await _platformDal.GetList();
        }

        public async Task<Platform> GetById(int id)
        {
           return await _platformDal.Get(c => c.Id == id);
        }

        public async Task<Platform> GetByName(string name)
        {
            return await _platformDal.Get(c => c.Name == name);
        }

        public async Task Add(Platform platform)
        {
            await _platformDal.Add(platform);
        }

        public async Task Delete(int platformId)
        {
            await _platformDal.Delete(new Platform{Id = platformId});
        }

        public async Task Update(Platform platform)
        {
            await _platformDal.Update(platform);
        }
    }

    
}
