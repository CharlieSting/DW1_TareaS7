using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Login_s7.Model
{
    public class Registro
    {
        public string num_identidad { get; set; }
        public string nombre_cliente { get; set; }
        public string correo_cliente { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int id_departamento { get; set; }
        public string pass { get; set; }
        public int active { get; set; } 
       
        public int id_rol { get; set; } 
    }
}
