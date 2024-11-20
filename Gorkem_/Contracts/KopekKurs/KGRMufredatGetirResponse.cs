using System.Reflection.Metadata.Ecma335;
using Gorkem_.Context.Entities;

namespace Gorkem_.Contracts.KopekKurs
{
    public class KGRMufredatGetirResponse
    {
        public int Id { get; set; }
        public string? Mufredat { get; set; }
        public int MufredatId { get; set; }
    }
}
