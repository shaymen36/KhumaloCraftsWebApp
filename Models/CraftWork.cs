namespace KhumaloCraftsWebApp.Models
{
    public class CraftWork
    {   public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string CurrencyCode { get; set; }
        public string ImagePath { get; set; }
    }
}
