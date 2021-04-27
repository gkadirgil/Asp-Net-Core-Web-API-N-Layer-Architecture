using NLayerProject.Core.Model;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Service.Services
{
    public class CategoryService : ServiceGeneric<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWorks unitOfWorks, IRepositoryGeneric<Category> repositoryGeneric):base(unitOfWorks,repositoryGeneric)
        {

        }
        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _unitOfWorks.Categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
