using System;
using System.Collections.Generic;
using System.Text;
using Convice.Core.DataAccess.EF;
using Convice.Entities;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EF
{
    public class EfPlatformDal:EntityFrameworkRepositoryBase<Platform,ConviceContext>,IPlatformDal
    {
    }
}
