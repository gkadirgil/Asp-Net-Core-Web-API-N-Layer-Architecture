using AutoMapper;
using NLayerProject.Core.Model;
using NLayerProject.MVC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.MVC.Mapping
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
