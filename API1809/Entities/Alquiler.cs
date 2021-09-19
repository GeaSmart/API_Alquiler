using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API1809.Entities
{
    public class Alquiler
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }

        //propiedad de navegación
        public Cliente cliente { get; set; }
    }
}
