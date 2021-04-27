using NLayerProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Repositories
{
    public interface ICategoryRepository: IRepositoryGeneric<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
