using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.MVCwithAPI.APIServices;
using NLayerProject.MVCwithAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.MVCwithAPI.Filters
{
    public class NotFoundFilter : IAsyncActionFilter
    {
       
        private readonly CategoryAPIServices _categoryAPIService;

        public NotFoundFilter(CategoryAPIServices categoryAPIService)
        {
            _categoryAPIService = categoryAPIService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = (int)context.ActionArguments.Values.FirstOrDefault();

            var entity = await _categoryAPIService.GetByIdAsync(id);

            if (entity!=null)
            {
                await next();
            }

            else
            {
                ErrorDTO errorDTO = new ErrorDTO();

                errorDTO.Errors.Add($" Category is not found being ID:{id}.");

                context.Result = new RedirectToActionResult("Error", "Home", errorDTO);
            }
        }
    }
}
