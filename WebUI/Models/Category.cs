namespace WebUI.Models;

public class Category
{
    public int CategoryID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public int Count { get; set; }
}
public class GetListBrand
{
    public int brandID { get; set; }
    public string name { get; set; } = string.Empty;
}