using Gorkem_.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;

namespace Gorkem_.Contracts.Kopek;

public class KopekGetirFilterResponse
{
    public int Id { get; set; }
    public string KopekAdi { get; set; } = string.Empty;
    public int IrkId { get; set; }
    public string? Irk { get; set; }
    public int BransId { get; set; }
    public string? Brans { get; set; }
    public string? KuvveNumarasi { get; set; }
    public string? CipNumarasi { get; set; }
    public int KadroIlId { get; set; }
    public string? KadroIl { get; set; }
    public DateTime DogumTarihi { get; set; }
    public string? YapilanIslem { get; set; }
    public string? NihaiKanaat { get; set; }
    public int KararId { get; set; }
    public string? Karar { get; set; }

    public DateTime T_Aktif { get; set; }
    public DateTime? T_Pasif { get; set; }
    public Enum_TeminSekli? EdinimSekli { get; set; }
}
