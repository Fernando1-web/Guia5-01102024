using System.ComponentModel.DataAnnotations;

namespace FJMA.DTOs.ProductFJMADTOs
{
    public class SearchResultProductFJMADTO
    {
        public int CountRow { get; set; }
        public List<ProductFJMA> Data { get; set; }
        public class ProductFJMA
        {
            public int Id { get; set; }

            [Display(Name = "Nombre")]
            public string NombreFJMA { get; set; }

            [Display(Name = "Descripcion")]
            public string DescripcionFJMA { get; set; }

            [Display(Name = "Precio")]
            public decimal PrecioFJMA { get; set; }
        }
    }
}
