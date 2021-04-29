using FluentValidation;
using NLayerProject.WEB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.WEB.Validations
{
    public class CreateCategoryDTOValidator : AbstractValidator<CategoryDTO>
    {
        public CreateCategoryDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category Name is required.");
        }
    }
}
