﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.DTOs
{
    public class CategoryWithProductDTO:CategoryDTO
    {
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
