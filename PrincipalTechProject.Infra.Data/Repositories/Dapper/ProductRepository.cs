using PrincipalTechProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using PrincipalTechProject.Infra.Data.Sql;
using System.Linq;
using PrincipalTechProject.Domain.Repositories;

namespace PrincipalTechProject.Infra.Data.Repositories.Dapper
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> InsertAsync(Product product)
        {
            using var sqlConnection = new SqlConnection(_connectionString);

            var affectedRows = await sqlConnection.ExecuteAsync(SqlStatements.InsertProduct,
                new
                {
                    Name = product.Name,
                    Description = product.Description,
                    Status = product.Status,
                    Category = product.Category,
                    Stock = product.Stock,
                    CreatedDate = product.Status
                });

            return affectedRows > 0;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            using var sqlConnection = new SqlConnection(_connectionString);

            var affectedRows = await sqlConnection.ExecuteAsync(SqlStatements.UpdateProduct,
                new
                {
                    Name = product.Name,
                    Description = product.Description,
                    Stock = product.Stock,
                    Category = product.Category,
                    Id = product.Id
                });

            return affectedRows > 0;
        }

        public async Task<bool> DeleteAsync(int id, bool status)
        {
            using var sqlConnection = new SqlConnection(_connectionString);

            var affectedRows = await sqlConnection.ExecuteAsync(SqlStatements.DeleteProduct,
                new
                {
                    newStatus = status,
                    Id = id
                });

            return affectedRows > 0;
        }

        public async Task<IList<Product>> Select()
        {
            using var sqlConnection = new SqlConnection(_connectionString);

            var productList = await sqlConnection.QueryAsync<Product>(SqlStatements.SelectProducts);

            return productList.ToList();
        }

        public async Task<Product> SlectById(int id)
        {
            using var sqlConnection = new SqlConnection(_connectionString);

            var product = await sqlConnection.QueryAsync<Product>(SqlStatements.SelectProductById, new { Id = id });

            return product.FirstOrDefault();
        }
    }
}
