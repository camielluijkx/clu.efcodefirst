using System.Collections.Generic;

namespace clu.efcodefirst.web.api.Models
{
    public class ProductDetailsDto
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public int Price { get; set; }

        public List<ReviewDetailsDto> Reviews { get; set; }
    }
}