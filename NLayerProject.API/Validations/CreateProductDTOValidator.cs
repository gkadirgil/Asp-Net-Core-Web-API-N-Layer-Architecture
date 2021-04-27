using FluentValidation;
using NLayerProject.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Validations
{
    public class CreateProductDTOValidator:AbstractValidator<ProductDTO>
    {
        public CreateProductDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required.");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Price must be bigger than 1 value.");

            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stock must be bigger than 1 value.");
        }
    }
}
