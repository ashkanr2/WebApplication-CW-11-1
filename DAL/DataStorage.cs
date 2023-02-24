using WebApplication_CW_11_1.Models;

namespace WebApplication_CW_11_1.DAL
{
    public static class DataStorage
    {
        public static List<Product> Products = new();
        public static  List<Category> Categories = new();

         static DataStorage()
         {
             Category category1 = new Category()
             {
                 Id = 1,
                 Type = "mobile"
             };
             Category category2 = new Category()
             {
                 Id = 2,
                 Type = "laptop"
             };
             Categories.Add(category1);
             Categories.Add(category2);

             Products.Add(new Product()
             {
                Id = 1,
                Name = "galaxy s22",
                Model = "s22",
                Brand = Brand.Sumsung,
                Color = "red",
                Category = category1,
                EnterTime = DateTime.Now
                
             });
             Products.Add(new Product()
             {
                 Id = 2,
                 Name =" xx",
                 Model = "xyx",
                 Brand = Brand.Lenovo,
                 Color = "blue",
                 Category = category2,
                 EnterTime = DateTime.Now
             });
             Products.Add(new Product()
             {
                 Id = 3,
                 Name = " A12",
                 Model = "sss",
                 Brand = Brand.Asus,
                 Color = "red",
                 Category = category1,
                 EnterTime = DateTime.Now
             });
             Products.Add(new Product()
             {
                 Id = 4,
                 Name = "z4",
                 Model = "s plus",
                 Brand = Brand.Huawei,
                 Color = "yellow",
                 Category = category2,
                 EnterTime = DateTime.Now
             });
        }


    }
}
