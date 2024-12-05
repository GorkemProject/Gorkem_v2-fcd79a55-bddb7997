namespace Gorkem_.Contracts.KopekKurs
{
    public class KursGunlukRaporEkleRequest
    {
        public int Id { get; set; }
        public int KursId { get; set; }
        public DateTime T_DersTarihi { get; set; }
        public string? SinifAdi { get; set; }
        public List<int>? DerslerIds { get; set; }


    }
}
