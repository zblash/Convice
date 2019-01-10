using Convice.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Convice.Entities
{
    public class Content:IEntity
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Kategori Alanı Boş Geçilemez")]
        public int CategoryId { get; set; }
        
        [Required(ErrorMessage = "Platform Alanı Boş Geçilemez")]
        public string Platform { get; set; }
        
        [Required(ErrorMessage = "Link Alanı Boş Geçilemez")]
        public string Link { get; set; }
        
        public bool isEnabled { get; set; }

        [Required(ErrorMessage = "Bu Alanı Boş Geçilemez")]
        public string ContentType { get; set; }
    }
}
