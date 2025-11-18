namespace AdminWeb.Models
{
    public class CategoryExtended
    {
        public int CategoryID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Icon { get; set; } = string.Empty;
        public int TotalProduct { get; set; }
    }
}
