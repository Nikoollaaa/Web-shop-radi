using Core.Abstractions.Repositories;
using Core.Abstractions.Services;
using Core.Domain;

namespace Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductRepository _repository;

        public ProductsService(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public bool Delete(int productId)
        {
            return _repository.Delete(productId);
        }

        public List<Proizvod> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        public Proizvod? GetById(int productId)
        {
            return _repository.GetById(productId);
        }

        public void Insert(Proizvod product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _repository.Insert(product);
        }

        public List<Proizvod> SearchByKeyWord(string keyoword)
        {
            return _repository.SearchByKeyWord(keyoword);
        }

        public bool Update(int productId, Proizvod product)
        {
            return _repository.Update(productId, product);
        }
    }
}