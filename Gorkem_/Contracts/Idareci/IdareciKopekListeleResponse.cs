namespace Gorkem_.Contracts.Idareci
{
    public class IdareciKopekListeleResponse
    {
        public int KopekId { get; set; }
        public int IdareciId { get; set; }
        public bool Aktifmi { get; set; }
        public DateTime T_Aktif { get; set; }
        public DateTime T_Pasif { get; set; }
    }
}
