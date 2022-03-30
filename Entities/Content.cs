using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Content
        {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string HTMLContent { get; set; }
        public string VedioLink { get; set; }
        public CategoryItem CategoryItem { get; set; }
    }
}
