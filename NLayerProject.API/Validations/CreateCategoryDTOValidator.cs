using FluentValidation;
using NLayerProject.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Validations
{
    public class CreateCategoryDTOValidator : AbstractValidator<CategoryDTO>
    {
        public CreateCategoryDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required.");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Category Name is required.");

            RuleFor(x=>x.Id).NotEmpty().WithMessage("Category Id is required.");
        }
    }
}
