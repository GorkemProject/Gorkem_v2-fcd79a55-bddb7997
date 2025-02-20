﻿using System.Security.Permissions;

namespace Gorkem_.Contracts.KopekKurs
{
    public class KursunMufredatlariniGetirResponse
    {
        public int Id { get; set; }
        public string KursAdi { get; set; }
        public string? MufredatAdi { get; set; }

        public DateTime OlusturulmaTarihi { get; set; }
    }
}
