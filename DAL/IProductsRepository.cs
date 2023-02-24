using WebApplication_CW_11_1.Models;

namespace WebApplication_CW_11_1.DAL
{
    public interface IProductsRepository
    {
        void Create(Product product);
        void Delete(int id);
        List<Product> GetAll();
        Product GetById(int id);
        void Update(Product product);
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void SellProduct( int id);
        

    }
}