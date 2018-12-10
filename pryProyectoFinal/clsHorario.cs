using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryProyectoFinal
{
    public class clsHorario
    {
        public int IdHorario { get; set; }
        public string Nombre { get; set; }
        public string TipoHorario { get; set; }
        public DateTime FechaTemporada { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
    }
}
