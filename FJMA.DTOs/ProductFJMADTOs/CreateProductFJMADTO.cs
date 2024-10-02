using System.ComponentModel.DataAnnotations;

namespace FJMA.DTOs.ProductFJMADTOs
{
    public class CreateProductFJMADTO
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de 50 caracteres")]
        public string NombreFJMA { get; set; }

        [Display(Name = "Descripcion")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de 50 caracteres")]
        public string? DescripcionFJMA { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal PrecioFJMA { get; set; }
    }
}
