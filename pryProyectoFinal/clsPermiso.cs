using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryProyectoFinal
{
    public class clsPermiso
    {
        public int IdPermiso { get; set; }
        public string Detalle { get; set; }
        public string Solicitante { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Prioridad { get; set; }
        public string Justificacion { get; set; }
    }
}
