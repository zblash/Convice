using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Convice.Core.Entities.Abstract;

namespace Convice.Entities
{
    public class Category:IEntity
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Kategori Adı Alanı Boş Bırakılamaz.")]
        public string Name { get; set; }

        public List<UserCategory> Users { get; set; }
    }
}