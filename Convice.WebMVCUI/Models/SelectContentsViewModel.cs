using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convice.Entities;

namespace Convice.WebMVCUI.Models
{
    public class SelectContentsViewModel
    {
        public List<Content> Categories { get; set; }
        public List<Platform> Platforms { get; set; }
        public List<Category> SelectedCategories { get; set; }
        public List<Platform> SelectedPlatforms { get; set; }
    }
}
