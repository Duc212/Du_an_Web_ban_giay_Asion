namespace DAL.Entities
{
    public class CommonResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }

    public class CommonPagination<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; } = new List<T>();
        public int TotalRecords { get; set; }
    }
}
