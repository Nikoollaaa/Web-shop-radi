using Core.Abstractions.Services;
using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;

namespace WebShop.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productService;

        public ProductsController(IProductsService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public List<Proizvod> GetAllProducts()
        {
            List<Proizvod> proizvodi = _productService.GetAllProducts();

            return proizvodi;
        }

        [HttpPost("products")]
        public IActionResult Insert([FromBody] ProizvodViewModel productModel)
        {
            var p = new Proizvod
            {
                Cena = productModel.Cena,
                Ime = productModel.Ime,
                Kategorija = productModel.Kategorija,
                Opis = productModel.Opis
            };

            _productService.Insert(p);

            return Ok();
        }

        [HttpGet("products/search/{keyword}")]
        public List<Proizvod> SearchByKeyword(string keyword)
        {
            return _productService.SearchByKeyWord(keyword);
        }

        [HttpGet("products/{productId}")]
        public Proizvod? GetById(int productId)
        {
            return _productService.GetById(productId);
        }

        [HttpDelete("products/{productId}")]
        public bool DeleteById(int productId)
        {
            return _productService.Delete(productId);
        }

        [HttpPut("products")]
        public bool UpdateProducts(int productId, ProizvodViewModel product)
        {
            var p = new Proizvod()
            {
                Id = productId,
                Ime = product.Ime,
                Kategorija = product.Kategorija,
                Cena = product.Cena,
                Opis = product.Opis,
            };

            return _productService.Update(productId, p);
        }
    }
}