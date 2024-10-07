using System.Reflection.Metadata.Ecma335;

namespace Gorkem_.Contracts.Idareci
{
    public class KopekIdareciResponse
    {
        public int IdareciId { get; set; }
        public string AdSoyad { get; set; }
        public string KopekAdi { get; set; }
        public string? KopekKuvveNumarasi { get; set; } 
        public string? KopekCipNumarasi { get; set; }   
    }
}
