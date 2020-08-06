using System;
using System.Collections.Generic;
using System.Text;

namespace SURSYSTEM.Models
{
    public class PersonaModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string ApyNom => $"{Apellido} {Nombre}";
        public string Cargo { get; set; }
    }
}
