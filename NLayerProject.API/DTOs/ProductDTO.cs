using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        //[Required(ErrorMessage ="{0} is required.")]
        public string Name { get; set; }

        //[Range(1,int.MaxValue,ErrorMessage ="{0} must be bigger than 1 value.")]
        public int Stock { get; set; }

        //[Range(1, double.MaxValue, ErrorMessage = "{0} must be bigger than 1 value.")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
