using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Category
    {

        public int Id { get; set; }
        [Required]
        
        [StringLength(20,MinimumLength =2)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
      //  [DisplayColumn("Image Path")]
        public string ThumbnailImgPath { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ICollection<CategoryItem> CategoryItems { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ICollection<UserCategory> UserCategory { get; set; }

    }
}
