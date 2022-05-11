using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrincipalTechProject.Domain.Entities;
using PrincipalTechProject.Domain.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace PrincipalTechProject.Api.Controllers
{
    [ApiController]
    [Route("/V1/Product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertProduct(Product product)
        {
            try
            {
                var response = await _productService.InsertProduct(product);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            try
            {
                var response = await _productService.UpdateProduct(product);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var response = await _productService.DeleteProduct(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("select")]
        public async Task<IActionResult> SelectProducts()
        {
            try
            {
                var response = await _productService.GetProducts();
                return Ok(response);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("{id}/select")]
        public async Task<IActionResult> SelectById(int id)
        {
            try
            {
                var response = await _productService.GetProductById(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
