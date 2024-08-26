namespace Gorkem_.Context
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Aktifmi { get; set; }
        public DateTime T_Aktif { get; set; }
        public DateTime? T_Pasif { get; set; }
    }
}
