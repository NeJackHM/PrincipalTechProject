using PrincipalTechProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrincipalTechProject.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<bool> InsertAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id, bool status);
        Task<IList<Product>> Select();
        Task<Product> SlectById(int id);
    }
}
