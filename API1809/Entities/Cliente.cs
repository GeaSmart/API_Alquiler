using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1809.Entities
{
    public class Cliente
    {   
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }

        //propiedad de navegación
        public List<Alquiler> alquileres { get; set; }
    }
}
