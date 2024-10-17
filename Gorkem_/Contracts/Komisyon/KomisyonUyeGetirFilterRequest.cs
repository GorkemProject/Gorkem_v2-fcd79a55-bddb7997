using Application.Common.FilterExtensions;

namespace Gorkem_.Contracts.Komisyon
{
    public class KomisyonUyeGetirFilterRequest
    {
        public List<List<FilterModel>> Filters { get; set; } = new();
        public int PageNumber { get; set; } = 1;
        public string SortedColumn { get; set; }
        public string SortDirection { get; set; }

    }
}
