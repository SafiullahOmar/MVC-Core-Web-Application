using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class CategoryItem
    {

        public int Id { get; set; }

        [Required]
        public string  Title { get; set; }
        public int  CategoryId { get; set; }
        public int MediaTypeId { get; set; }
        public DateTime DateTimeItemReleased { get; set; }

    }
}
