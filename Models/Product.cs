namespace WebApplication_CW_11_1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public Brand Brand { get; set; }
        public string Color { get; set; }
        public Category Category { get; set; }

        public DateTime ExitTime { get; set; }
        public DateTime EnterTime { get; set; }

    }

    public enum Brand
    {
        Sumsung =1,
        Lenovo = 2, 
        Asus = 3, 
        Huawei =4
    }
}
    