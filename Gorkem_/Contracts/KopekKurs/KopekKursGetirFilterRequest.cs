using Application.Common.FilterExtensions;

namespace Gorkem_.Contracts.KopekKurs
{
    public class KopekKursGetirFilterRequest
    {

        public List<List<FilterModel>> Filters { get; set; } = new();
        public int PageNumber { get; set; } = 1;
        public string SortedColumn { get; set; }
        public string SortDirection { get; set; }
    }
}
