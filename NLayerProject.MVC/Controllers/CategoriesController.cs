using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Model;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWorks;
using NLayerProject.MVC.DTOs;
using NLayerProject.MVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();

            var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(categories);

            return View(categoriesDTO);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
           
                var category = _mapper.Map<Category>(categoryDTO);
                await _categoryService.AddAsync(category);


                return RedirectToAction("Index");
           

           


        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            return View(_mapper.Map<CategoryDTO>(category));
        }

        [HttpPost]
        public IActionResult Update(CategoryDTO categoryDTO)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDTO));

            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Category>))]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(category);

            return RedirectToAction("Index");
        }
    }
}
