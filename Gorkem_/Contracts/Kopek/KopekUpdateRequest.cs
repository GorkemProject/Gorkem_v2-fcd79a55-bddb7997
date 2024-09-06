namespace Gorkem_.Contracts.Kopek
{
    public class KopekUpdateRequest
    {
     
        public string Name { get; set; }
        public int IrkId { get; set; }
        public int BirimId { get; set; }
        public int BransId { get; set; }
        public int CinsRef { get; set; }
        public int KopekTuruId { get; set; }
        public int DurumId { get; set; }
        public int KuvveNumarasi { get; set; }
        public int CipNumarasi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string YapilanIslem { get; set; }
        public string NihaiKanaat { get; set; }
        public string TeminSekli { get; set; }
    }
}
