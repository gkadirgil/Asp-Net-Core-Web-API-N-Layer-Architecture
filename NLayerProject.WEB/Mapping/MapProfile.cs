using AutoMapper;
using NLayerProject.Core.Model;
using NLayerProject.WEB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.WEB.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();

            CreateMap<Category, CategoryWithProductDTO>().ReverseMap();

            CreateMap<Product, ProductWithCategoryDTO>().ReverseMap();
        }
    }
}
