using System;
using System.Collections.Generic;
using System.Text;
using Convice.Core.DataAccess;
using Convice.Entities;

namespace DataAccess.Abstract
{
    public interface IContentDal: IEntityRepository<Content>
    {
    }
}
