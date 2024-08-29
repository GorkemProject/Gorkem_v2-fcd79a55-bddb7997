﻿namespace Gorkem_.Contracts.UygulamaTablo
{
    public class KopekUpdateRequest
    {
     
        public string Name { get; set; }
        public int IrkRef { get; set; }
        public int BirimRef { get; set; }
        public int BransRef { get; set; }
        public int KopekTuruRef { get; set; }
        public int DurumRef { get; set; }
        public int KuvveNumarasi { get; set; }
        public int CipNumarasi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string YapilanIslem { get; set; }
        public string NihaiKanaat { get; set; }
        public string TeminSekli { get; set; }
    }
}
