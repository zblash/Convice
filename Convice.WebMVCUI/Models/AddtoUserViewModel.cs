using System.Collections.Generic;
using Convice.Entities;

namespace Convice.WebMVCUI.Models
{
    public class AddtoUserViewModel
    {
        public Category Category { get; set; }
        public List<Category> Categories {get;set;}
    }
}