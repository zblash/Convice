using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Convice.Entities;
using Convice.Core.DataAccess.EF;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EF
{
    public class EfContentDal: EntityFrameworkRepositoryBase<Content,ConviceContext>,IContentDal
    {

    }
}
