namespace DAL.Entities
{
    public class CommonResponse<T>
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }

    public class CommonPagination<T>
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public List<T> Data { get; set; } = new List<T>();
        public int TotalRecords { get; set; } = 0;
    }
}
