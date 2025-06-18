namespace Sekure.Models
{
    public class CalculationInfoWithPaginator
    {
        public CalculationInfo[] Items { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
