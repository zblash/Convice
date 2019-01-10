using System;
using System.Collections.Generic;
using System.Text;

using Convice.Entities.IdentityEntities;

namespace Convice.Entities
{
    public class UserCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string UserId { get; set; }
        public virtual CustomIdentityUser User { get; set; }
    }
}
