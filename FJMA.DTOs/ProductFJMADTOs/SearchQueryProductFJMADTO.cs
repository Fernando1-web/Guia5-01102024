using System.ComponentModel.DataAnnotations;

namespace FJMA.DTOs.ProductFJMADTOs
{
    public class SearchQueryProductFJMADTO
    {
        [Display(Name = "Nombre")]
        public string? NombreFJMA_Like { get; set; }
        [Display(Name = "Pagina")]
        public int Skip { get; set; }
        [Display(Name = "CantReg x Pagina")]
        public int Take { get; set; }
        public byte SendRowCount { get; set; }
    }
}
