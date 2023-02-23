using WebApplication_CW_11_1.Models;

namespace WebApplication_CW_11_1.DAL
{
    public class ProductsRepository : IProductsRepository
    {


        public void Create(Product product)
        {
            DataStorage.Products.Add(product);
        }

        public Product GetById(int id)
        {
            return DataStorage.Products.FirstOrDefault(x => x.Id == id);
        }
        public void Delete(int id)
        {
            var newProduct = GetById(id);
            DataStorage.Products.Remove(newProduct);
        }

        public void Update(Product product)
        {
            var newProduct = GetById(product.Id);

            newProduct.Name = product.Name;
            newProduct.Brand = product.Brand;
            newProduct.Category = product.Category;
            newProduct.Color = product.Color;
            newProduct.Model = product.Model;

        }
        public List<Product> GetAll()
        {
            List<Product> Products = DataStorage.Products;
            return Products;
        }
        public List<Category> GetAllCategories()
        {
            return DataStorage.Categories;
        }
        public Category GetCategoryById(int id)
        {
            return DataStorage.Categories.FirstOrDefault(x => x.Id == id);
        }
        
    }
}
