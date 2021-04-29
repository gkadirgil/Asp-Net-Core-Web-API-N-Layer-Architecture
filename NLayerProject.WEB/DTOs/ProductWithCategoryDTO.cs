using NLayerProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.WEB.DTOs
{
    public class ProductWithCategoryDTO:ProductDTO
    {
        public CategoryDTO Category { get; set; }
    }
}
