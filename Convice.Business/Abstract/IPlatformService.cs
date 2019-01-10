using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Convice.Entities;

namespace Convice.Business.Abstract
{
    public interface IPlatformService
    {
        Task<List<Platform>> GetAll();

        Task<Platform> GetById(int id);

        Task<Platform> GetByName(string name);

        Task Add(Platform platform);

        Task Delete(int platformId);

        Task Update(Platform platform);
    }
}
