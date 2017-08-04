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


    public class ClaseProductoRepository : DALRepository<ClaseProducto>
    {
        public ClaseProductoRepository(string connectionString) : base(connectionString)
        {
        }

        public bool Create(ClaseProducto model)
        {
            var query = string.Format(@"
declare @vUnidad_Medida int = 0

select @vUnidad_Medida = max(unidad_medida)
from tbl_unidad_medida
set @vUnidad_Medida = isnull(@vUnidad_Medida,0) + 1

insert into tbl_unidad_medida
(unidad_medida, descripcion, simbolo, fecha_hora, username, orden, estado)
values(@vUnidad_Medida, '{0}', '{1}', getdate(), '{2}', {3}, {4})

select @vUnidad_Medida as Unidad_Medida;
", model.Descripcion, model.Simbolo, model.UserName, model.Orden, model.Estado);

            using (var command = new SqlCommand(query))
            {
                return NonQuery(command);
            }

        }

        public bool Update(ClaseProducto model)
        {
            string query = string.Format(@"
update tbl_unidad_medida
set descripcion = '{0}',
    simbolo = '{1}',
    m_username = '{2}',
    m_fecha_hora = getdate()
where unidad_medida = {3}
", model.Descripcion, model.Simbolo, model.M_UserName, model.Unidad_Medida);

            using (var command = new SqlCommand(query))
            {
                return NonQuery(command);
            }
        }

        public bool Delete(ClaseProducto model)
        {

            string query = string.Format(@"
update tbl_unidad_medida
set Estado = 2,
    m_username = '{1}',
    m_fecha_hora = getdate()
where unidad_medida = {0}
", model.Unidad_Medida, model.M_UserName);

            using (var command = new SqlCommand(query))
            {
                return NonQuery(command);
            }
        }




        public IEnumerable<ClaseProducto> GetAll()
        {

            using (var command = new SqlCommand("Select * From tbl_Unidad_Medida where estado = 1;"))
            {
                return GetRecords(command);
            }
        }




        public override ClaseProducto PopulateRecord(SqlDataReader reader)
        {
            var modelo = new ClaseProducto()
            {
                Unidad_Medida = Convert.ToInt32(reader["Unidad_Medida"]),
                Descripcion = (string)reader["Descripcion"],
                Simbolo = (string)reader["Simbolo"],
                Fecha_Hora = (DateTime)reader["Fecha_Hora"],
                UserName = (string)reader["UserName"],
                Orden = Convert.ToInt32(reader["Orden"]),
                Estado = Convert.ToInt32(reader["Estado"])
            };
            if (reader["M_Fecha_Hora"] is DateTime)
            {
                modelo.M_Fecha_Hora = (DateTime)reader["M_Fecha_Hora"];
            }
            if (reader["M_UserName"] is string)
            {
                modelo.M_UserName = (string)reader["M_UserName"];
            }

            return modelo;
        }



    }
}