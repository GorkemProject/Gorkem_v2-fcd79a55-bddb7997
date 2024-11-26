using Microsoft.AspNetCore.Authentication;

namespace Gorkem_.Contracts.KopekKurs
{
    public class HaftalikRaporGozlemResponse
    {
        public int KursiyerId { get; set; }
        public string? Kursiyer { get; set; }
        public int GozlemId { get; set; }
        public string? GozlemAdi { get; set; }
        public int KopekId { get; set; }
        public string KopekAdi { get; set; }

    }
}
