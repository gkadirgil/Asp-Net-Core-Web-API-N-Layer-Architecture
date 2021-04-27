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
    public class GenericNotFoundFilter<TEntity> : IAsyncActionFilter where TEntity : class
    {
        private readonly IServicesGeneric<TEntity> _service;

        public GenericNotFoundFilter(IServicesGeneric<TEntity> service)
        {
            _service=service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = (int)context.ActionArguments.Values.FirstOrDefault();

            var entity = await _service.GetByIdAsync(id);

            if (entity!=null)
            {
                await next();
            }

            else
            {
                ErrorDTO errorDTO = new ErrorDTO();

                errorDTO.Status = 404;

                errorDTO.Errors.Add($" Entity is not found being ID:{id}.");

                context.Result = new NotFoundObjectResult(errorDTO);
            }
        }
    }
}
