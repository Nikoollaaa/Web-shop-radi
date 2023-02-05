using Core.Domain;

namespace Core.Abstractions.Repositories
{
    public interface IProductRepository
    {
        List<Proizvod> GetAllProducts();
        void Insert(Proizvod product);
        bool Delete(int productId);
        Proizvod? GetById(int productId);
        List<Proizvod> SearchByKeyWord(string keyoword);
        bool Update(int productId,Proizvod product);
    }
}