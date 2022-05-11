using Microsoft.Extensions.Logging;
using PrincipalTechProject.Domain.Entities;
using PrincipalTechProject.Domain.Repositories;
using PrincipalTechProject.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrincipalTechProject.Domain.Repository
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var deleteSuccsess = await _productRepository.DeleteAsync(id, false);
            return deleteSuccsess;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _productRepository.SlectById(id);
            return product;
        }

        public async Task<IList<Product>> GetProducts()
        {
            var productList = await _productRepository.Select();
            return productList;
        }

        public async Task<bool> InsertProduct(Product product)
        {
            var getProduct = await _productRepository.SlectById(product.Id);
            if (getProduct != null)
            {
                throw new Exception("the product already exists.");
            }

            var response = await _productRepository.InsertAsync(product);
            return response;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var getProduct = await _productRepository.SlectById(product.Id);
            if (getProduct == null)
            {
                throw new Exception("the product doesn't exists.");
            }

            var response = await _productRepository.UpdateAsync(product);
            return response;
        }
    }
}
