using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        [Display(Name ="Nombre Producto")]
        [StringLength(100, ErrorMessage ="El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string nombre { get; set; }
        [Required]
        [Display (Name = "Descripcion Producto")]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string descripcion { get; set; }
        [Required]
        [Display (Name = "Precio Producto")]
        public decimal? precio { get; set; }

    }

    public class EditProductViewModel
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Nombre Producto")]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Descripcion Producto")]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string descripcion { get; set; }
        [Required]
        [Display(Name = "Precio Producto")]
        public decimal? precio { get; set; }

    }

    public class DeleteProductViewModel
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Nombre Producto")]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Descripcion Producto")]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string descripcion { get; set; }
        [Required]
        [Display(Name = "Precio Producto")]
        public decimal? precio { get; set; }

    }
}