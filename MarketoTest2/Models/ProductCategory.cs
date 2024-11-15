using MarketoTest2.Models;

public class ProductCategory
{
    public int ProductId { get; set; }  // Utländsk nyckel till produkt
    public required Product Product { get; set; }  // Navigationsproperty till produkt

    public int CategoryId { get; set; }  // Utländsk nyckel till kategori
    public required Category Category { get; set; }  // Navigationsproperty till kategori
}
