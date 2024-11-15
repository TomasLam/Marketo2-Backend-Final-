namespace MarketoTest2.Models
{
    public class HomeViewModel
    {
        public required List<Product> NewProducts { get; set; }
        public required List<Product> PopularProducts { get; set; }
        public required List<Product> FeaturedProducts { get; set; }
    }
}
