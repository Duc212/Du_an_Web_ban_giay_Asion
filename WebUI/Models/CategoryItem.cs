namespace WebUI.Models
{
    public class CategoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
        public string Icon { get; set; } = "fas fa-tags";
    }
}