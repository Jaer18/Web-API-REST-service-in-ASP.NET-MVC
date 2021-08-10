using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clientes.Models
{
    public class Cliente
    {
        [Key]
        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public bool Descuento { get; set; }

        public decimal ComprasRecientes { get; set; }

        public decimal ComprasUltimoAno { get; set; }

        public int CantidadAcComprados { get; set; }
    }
}
