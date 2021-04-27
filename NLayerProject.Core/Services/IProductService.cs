using NLayerProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
    public interface IProductService:IServicesGeneric<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
