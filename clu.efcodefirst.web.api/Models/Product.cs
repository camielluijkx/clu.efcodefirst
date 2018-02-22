using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace clu.efcodefirst.web.api.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Category { get; set; }

        public int Price { get; set; }

        //Navigation Property
        public ICollection<Review> Reviews { get; set; }
    }
}