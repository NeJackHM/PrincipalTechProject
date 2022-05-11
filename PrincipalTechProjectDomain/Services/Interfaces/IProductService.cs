using PrincipalTechProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrincipalTechProject.Domain.Repository.Interfaces
{
    public interface IProductService
    {
        Task<bool> InsertProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<Product> GetProductById(int id);
        Task<IList<Product>> GetProducts();
    }
}
