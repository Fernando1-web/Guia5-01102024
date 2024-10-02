using System.ComponentModel.DataAnnotations;

namespace FJMA.DTOs.ProductFJMADTOs
{
    public class GetIdResultProductFJMADTO
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string NombreFJMA { get; set; }

        [Display(Name = "Descripcion")]
        public string? DescripcionFJMA { get; set; }

        [Display(Name = "Precio")]
        public decimal PrecioFJMA { get; set; }
    }
}