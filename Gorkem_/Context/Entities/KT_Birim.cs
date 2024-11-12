namespace Gorkem_.Context.Entities
{
    public class KT_Birim 
    {
        public int? Id { get; set; }
        public long? TabloID { get; set; }
        public string? Adi { get; set; }
        public string? UzunAdi { get; set; }
        public bool? Aktif { get; set; }
        public long? UstBirimID { get; set; }
        public string? UstBirimAdi { get; set; }
        public string? UstBirimUzunAdi { get; set; }
        public byte? BirimTuruID { get; set; }
        public string? BirimTuruAdi { get; set; }
        public byte? EGMBirimTuruID { get; set; }
        public string? EGMBirimTuruAdi { get; set; }
        public byte? BirimBransID { get; set; }
        public string? BirimBransAdi { get; set; }
        public long? IlID { get; set; }
        public string? IlAdi { get; set; }
        public string? IlUzunAdi { get; set; }
        public long? IlceID { get; set; }
        public string? IlceAdi { get; set; }
        public string? IlceUzunAdi { get; set; }
        public long? KadroID { get; set; }
        public string? KadroAdi { get; set; }
        public string? KadroUzunAdi { get; set; }
        public long? SubeID { get; set; }
        public string? SubeAdi { get; set; }
        public string? SubeUzunAdi { get; set; }
        public string? YazismaKodu { get; set; }
        public string? AktifYazismaKodu { get; set; }
        public byte? IlPlakaNo { get; set; }
        public bool?  BuyukSehirmi { get; set; }
    }
}
