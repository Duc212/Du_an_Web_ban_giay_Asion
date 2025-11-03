namespace WebUI.Models;

/// <summary>
/// Response model chung cho các API trả về một đối tượng
/// </summary>
public class CommonResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
}

/// <summary>
/// Response model chung cho các API có phân trang
/// </summary>
public class CommonPagination<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<T> Data { get; set; } = new();
    public int TotalRecord { get; set; }
}

/// <summary>
/// Response model cho API Product Landing
/// </summary>
public class ProductApiResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<Product> Data { get; set; } = new();
    public int TotalRecord { get; set; }
}