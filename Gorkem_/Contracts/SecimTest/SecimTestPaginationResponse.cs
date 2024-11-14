namespace Gorkem_.Contracts.SecimTest
{
    public class SecimTestPaginationResponse
    {
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<SecimTestResponse> SecimTestler { get; set; }
    }
}
