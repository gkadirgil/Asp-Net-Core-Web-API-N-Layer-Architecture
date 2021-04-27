using AutoMapper;
using NLayerProject.API.DTOs;
using NLayerProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Mapping
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
