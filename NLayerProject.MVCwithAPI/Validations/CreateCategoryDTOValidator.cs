using FluentValidation;
using NLayerProject.MVCwithAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.MVCwithAPI.Validations
{
    public class CreateCategoryDTOValidator : AbstractValidator<CategoryDTO>
    {
        public CreateCategoryDTOValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Category Name is required.");
        }
    }
}
