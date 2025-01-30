namespace Gorkem_.Contracts.Dashboard
{
    public class YasVeCinsiyeteGoreKopekSayisiGetirResponse
    {

        public string YasGrubu { get; set; } // Örneğin: "0-1", "1-3", "3-5", "5+"
        public int ErkekSayisi { get; set; }
        public int DisiSayisi { get; set; }
    }
}
