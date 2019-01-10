using System.Collections.Generic;
using Convice.Entities;

namespace Convice.WebMVCUI.Models
{
    public class UpdateContentViewModel
    {
        public Content Content { get; set; }
        public List<Category> Categories { get; set; }
    }
}