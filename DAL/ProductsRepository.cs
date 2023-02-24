using WebApplication_CW_11_1.Models;
using System.Globalization;
namespace WebApplication_CW_11_1.DAL
{
    public static class Function
    {
        public static string DateTimePersian(this DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            return ($"{pc.GetYear(dt)}/{pc.GetMonth(dt)}/{pc.GetDayOfMonth(dt)}");
        }
    }
    public class ProductsRepository : IProductsRepository
    {
        private readonly IWebHostEnvironment _webHost;

        public ProductsRepository(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        public void Create(Product product)
        {
            product.EnterTime = DateTime.Now;
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

        public void SellProduct (int id)
        {
            var result=GetById(id);
            var path = Path.Combine(_webHost.WebRootPath, "History.csv");
            if (!File.Exists(path))
            {
                var temp=File.Create(path);
                temp.Close();
            }

            result.ExitTime=DateTime.Now;
           

            File.AppendAllText(path,$"{result.Id},{result.Name},{result.ExitTime.DateTimePersian()}\n");
        }

        
    }
}
