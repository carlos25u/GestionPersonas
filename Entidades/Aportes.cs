using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.Entidades
{
    public class Aportes
    {
        //AporteId,Fecha,PersonaId,Concepto, Monto
        [Key]
        public int AporteId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int PersonaId { get; set; }
        public String Concepto { get; set; }
        public float Monto { get; set; }

        [ForeignKey("PersonaId")]
        public virtual Personas Personas { get; set; }

        [ForeignKey("AporteId")]
        public List<AportesDetalle> AportesDetalle { get; set; } = new List<AportesDetalle>();
    }
}
