using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.API.DTOs;
using NLayerProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Filters
{
    public class ProductNotFoundFilter:ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public ProductNotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _productService.GetByIdAsync(id);

            if (product!=null)
            {
                await next();
            }

            else
            {
                ErrorDTO errorDTO = new ErrorDTO();

                errorDTO.Status = 404;

                errorDTO.Errors.Add($" Product is not found being ID:{id}.");

                context.Result = new NotFoundObjectResult(errorDTO);
            }

        }
    }
}
