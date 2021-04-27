using NLayerProject.Core.Model;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Service.Services
{
    public class ProductService : ServiceGeneric<Product>, IProductService
    {
        public ProductService(IUnitOfWorks unitOfWorks, IRepositoryGeneric<Product> repositoryGeneric):base(unitOfWorks,repositoryGeneric)
        {

        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWorks.Products.GetWithCategoryByIdAsync(productId);
            
        }
    }
}
