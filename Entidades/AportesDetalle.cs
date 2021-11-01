using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.Entidades
{
    public class AportesDetalle
    {
        [Key]
        public int AportesDetalleId { get; set; }
        public int AporteId { get; set; }
        public int TipoAporteId { get; set; }

        [ForeignKey("PersonaId")]
        public virtual Personas Personas { get; set; }

        [ForeignKey("TipoAporteId")]
        public virtual TiposAportes TiposAportes { get; set; }

    }
}
