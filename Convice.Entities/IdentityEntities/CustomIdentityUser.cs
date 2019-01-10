﻿
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Convice.Entities.IdentityEntities
{
    [Table("AspNetUsers")]
    public class CustomIdentityUser : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<UserCategory> UserCategories { get; set; }
    }
}
