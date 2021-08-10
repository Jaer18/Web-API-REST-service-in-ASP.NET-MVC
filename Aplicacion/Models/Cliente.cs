using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacion.Models
{
    public class Cliente
    {
        [Required(ErrorMessage = "Debe de ingresar un número de cédula")]
        [Display(Name = "Cédula")]
        [MaxLength(12, ErrorMessage = "Debe ingresar 12 caracteres")]
        [MinLength(12, ErrorMessage = "Debe ingresar 12 caracteres")]
        [RegularExpression("[0]{1}[0-9]{1}-[0-9]{4}-[0-9]{4}", ErrorMessage = "Formato incorrecto. El formato debe ser 0#-####-####")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Debe de ingresar un nombre")]
        [MinLength(10, ErrorMessage = "Debe ingresar al menos 10 caracteres")]
        [MaxLength(60, ErrorMessage = "No puede ingresar mas de 60 caracteres")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Formato incorrecto. Debe ser alfanumérico.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe de ingresar un número de teléfono")]
        [Display(Name = "Teléfono")]
        [MinLength(9, ErrorMessage = "Debe ingresar 9 caracteres")]
        [MaxLength(9, ErrorMessage = "Debe ingresar 9 caracteres")]
        [RegularExpression("[0-9]{4}-[0-9]{4}", ErrorMessage = "Formato incorrecto. El formato debe ser ####-####")]
        public string Telefono { get; set; }

        public bool Descuento { get; set; }

        [Required(ErrorMessage = "Debe de ingresar un monto de compras recientes")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "Debe ingresar un monto mayor o igual a 0")]
        [Display(Name = "Compras Recientes")]
        public decimal ComprasRecientes { get; set; }

        [Required(ErrorMessage = "Debe de ingresar un monto de compras en el último año")]
        [Range(typeof(decimal), "1", "79228162514264337593543950335", ErrorMessage = "Debe ingresar un monto mayor a 0")]
        [Display(Name = "Compras en el último año")]
        public decimal ComprasUltimoAno { get; set; }

        [Required(ErrorMessage = "Debe de ingresar un número de A/C comprados")]
        [Range(0, int.MaxValue, ErrorMessage = "Por favor ingrese un monto mayor o igual 0")]
        [Display(Name = "Cantidad de A/C comprados")]
        public int CantidadAcComprados { get; set; }
    }
}
