using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJMA.DTOs.ProductFJMADTOs
{
    public class EditProductFJMADTO
    {
        public EditProductFJMADTO(GetIdResultProductFJMADTO get)
        {
            Id = get.Id;
            NombreFJMA = get.NombreFJMA;
            DescripcionFJMA = get.DescripcionFJMA;
            PrecioFJMA = get.PrecioFJMA;
        }

        public EditProductFJMADTO()
        {
        }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Id { get; set; }

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
