public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }  // Exempel: "New", "Popular", "Featured"
    public string? Description { get; set; } // Kan lägga till en beskrivning om nödvändigt

    public virtual required ICollection<ProductCategory> ProductCategories { get; set; }
}
