using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace rpapos_web_webforms.Models
{
    public class ClaseProducto
    {
        
        public int Clase_Producto { get; set; }
        public int ClaseProductoPadre { get; set; }
        public string Descripcion { get; set; }
        public int Empresa { get; set; }
        public int Raiz { get; set; }
        public int Nivel { get; set; }
        public DateTime FechaHora { get; set; }
        public string Username { get; set; }
        public DateTime M_FechaHora { get; set; }
        public string M_Username { get; set; }
        public int Estado { get; set; }
        public int Cuenta { get; set; }
        public float PorcentajeDepreciacion { get; set; }
        public int ObjVertical { get; set; }
        public int ObjHorizontal { get; set; }
        public string ObjFondo { get; set; }
        public int Pagina { get; set; }
        public int Orden { get; set; }
        public string ColorDisponible { get; set; }
        public string ColorAbierto { get; set; }
        public string ObjDisponible { get; set; }
        public string ObjAbierto { get; set; }
        public int ObjHeight { get; set; }
        public int ObjWidth { get; set; }
        public int ObjTop { get; set; }
        public int ObjLeft { get; set; }
        public bool Componente { get; set; }
        public float UtilidadPor { get; set; }
        public float UtilidadVal { get; set; }
        public int ObjSecuencia { get; set; }
        public float DescuentoPorMaximo { get; set; }
        public float DescuentoValMaximo { get; set; }
        public int Clasificacion { get; set; }
        public string Codigo { get; set; }
    }
}