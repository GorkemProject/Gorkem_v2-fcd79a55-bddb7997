using System;

namespace Gorkem_.Contracts.Kopek;

public class KopekGetirFilterResponse
{
        public int Id { get; set; }
        public string? KopekAdi { get; set; }
        public int IrkId { get; set; }
        public string Irk { get; set;}
        public int BirimId { get; set; }
        public string Birim { get; set;}
        public int BransId { get; set; }
        public string Brans { get; set;}
        public int CinsId { get; set; }
        public string Cins { get; set;}
        public int KopekTuruId { get; set; }
        public string KopekTuru { get; set;}
        public int DurumId { get; set; }
        public int KuvveNumarasi { get; set; }
        public int CipNumarasi { get; set; }
        public bool Karar { get; set; }
        public DateTime T_Aktif { get; set; }
        public DateTime? T_Pasif { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string? YapilanIslem { get; set; }
        public string? NihaiKanaat { get; set; }
        public int TeminSekli { get; set; }
}
