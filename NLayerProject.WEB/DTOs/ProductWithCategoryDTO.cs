using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.MVCwithAPI.DTOs
{
    public class ProductWithCategoryDTO:ProductDTO
    {
        public CategoryDTO Category { get; set; }
    }
}
