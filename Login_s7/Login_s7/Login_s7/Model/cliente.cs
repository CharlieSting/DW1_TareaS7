using System;
using System.Collections.Generic;
using System.Text;

namespace Login_s7.Model
{
    public class cliente
    {
        public string fecha { get; set; }
        public int id_estado { get; set; }
        public int id_cliente { get; set; }

        public int id_prioridad { get; set; }

        public string asunto  { get; set; }
        public string descripcion_ticket { get; set; }


    }
}
