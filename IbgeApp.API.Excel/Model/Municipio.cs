using System.ComponentModel.DataAnnotations;

namespace IbgeApp.API.Excel.Model
{
    public class Municipio
    {
        [Key]
        public int CodigoMunicipio { get; set; }
        public string? NomeMunicipio { get; set; }
        public int CodigoUF { get; set; }
    }
}
