using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1809.Entities
{
    public class Maquinaria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_compra { get; set; }
        public string Marca { get; set; }
        public bool isDisponible { get; set; }
    }
}
