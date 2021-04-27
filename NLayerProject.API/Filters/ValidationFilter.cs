﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NLayerProject.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Filters
{
    public class ValidationFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorDTO errorDTO = new ErrorDTO();

                errorDTO.Status = 400;

                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(s => s.Errors);

                modelErrors.ToList().ForEach(x =>
                {
                    errorDTO.Errors.Add(x.ErrorMessage);
                });


                context.Result = new BadRequestObjectResult(errorDTO);

            }
        }
    }
}
