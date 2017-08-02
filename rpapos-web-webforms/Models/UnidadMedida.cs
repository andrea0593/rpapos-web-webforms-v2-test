using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rpapos_web_webforms.Models
{
    public class UnidadMedida
    {
        [Key, ScaffoldColumn(false)]
        public int Unidad_Medida { get; set; }  
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }
        public string Simbolo { get; set; }
        [ScaffoldColumn(false)]
        public DateTime Fecha_Hora { get; set; }
        [ScaffoldColumn(false)]
        public string UserName { get; set; }
        [ScaffoldColumn(false)]
        public DateTime M_Fecha_Hora { get; set; }
        [ScaffoldColumn(false)]
        public string M_UserName { get; set; }
        [ScaffoldColumn(false)]
        public int Orden { get; set; }
        [ScaffoldColumn(false)]
        public int Estado { get; set; }
    }
}