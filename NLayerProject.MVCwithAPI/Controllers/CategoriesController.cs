using Microsoft.AspNetCore.Mvc;
using NLayerProject.MVCwithAPI.APIServices;
using NLayerProject.MVCwithAPI.DTOs;
using NLayerProject.MVCwithAPI.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayerProject.MVCwithAPI.Controllers
{
    public class CategoriesController : Controller
    {
     
        private readonly CategoryAPIServices _categoryAPIServices;
       
       

        public CategoriesController(CategoryAPIServices categoryAPIServices)
        {
          
            _categoryAPIServices = categoryAPIServices;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryAPIServices.GetAllAsync();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            
            await _categoryAPIServices.AddAsync(categoryDTO);
            

            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryAPIServices.GetByIdAsync(id);

            return View(category);
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpPost]
        public async Task<IActionResult> Update(CategoryDTO categoryDTO)
        {
            await _categoryAPIServices.Update(categoryDTO);
            
            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {

            await _categoryAPIServices.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
