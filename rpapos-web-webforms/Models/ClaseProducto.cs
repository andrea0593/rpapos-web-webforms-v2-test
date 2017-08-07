using rpapos_web_webforms.Models.Repo;
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
        public int? ClaseProductoPadre { get; set; }
        public string Descripcion { get; set; }
        public int Empresa { get; set; }
        public int Raiz { get; set; }
        public int Nivel { get; set; }
        public string UserName { get; set; }
        public string M_UserName { get; set; }
        public int Estado { get; set; }
        public int? Clasificacion { get; set; }
        public string Codigo { get; set; }
    }

    public class ClaseProductoRepository : RepoBase<ClaseProducto>
    {
        public ClaseProductoRepository(string connectionString) : base(connectionString)
        {
        }

        public bool Create(ClaseProducto model)
        {
            var query = string.Format(@"
declare @claseProducto int = 0

select @claseProducto = max(Clase_Producto)
from tbl_Clase_Producto
set @claseProducto = isnull(@claseProducto, 0) + 1

insert into tbl_clase_producto
(clase_producto, descripcion, clasificacion, codigo, username, raiz, nivel, clase_producto_padre, fecha_hora, estado, empresa, utilidad_por, utilidad_val, obj_secuencia)
values
(@claseProducto, '{0}', {1}, '{2}', '{3}', {4}, {5}, {6}, getdate(), 1, 1, 0, 0, 1)

select @claseProducto as Unidad_Medida;
", model.Descripcion, model.Clasificacion != null ? string.Format("'{0}'", model.Clasificacion) : null, model.Codigo, model.UserName, model.Raiz, model.Nivel, model.ClaseProductoPadre ?? null);

            using (var command = new SqlCommand(query))
            {
                return NonQuery(command);
            }

        }

        public bool Update(ClaseProducto model)
        {
            string query = string.Format(@"
update tbl_clase_producto
set descripcion = '{0}',
    clasificacion = {1},
    codigo = '{2}',
    raiz = {3},
    nivel = {4},
    clase_producto_padre = {5},
    m_username = '{6}',
    m_fecha_hora = getdate()
where clase_producto = {7}
", model.Descripcion, model.Clasificacion != null ? string.Format("'{0}'", model.Clasificacion) : null, model.Codigo, model.Raiz, model.Nivel, model.ClaseProductoPadre, model.M_UserName, model.Clase_Producto);

            using (var command = new SqlCommand(query))
            {
                return NonQuery(command);
            }
        }

        public bool Delete(ClaseProducto model)
        {

            string query = string.Format(@"
update tbl_clase_producto
set Estado = 2,
    m_username = '{1}',
    m_fecha_hora = getdate()
where unidad_medida = {0}
", model.Clase_Producto, model.M_UserName);

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
                Clase_Producto = Convert.ToInt32(reader["Clase_Producto"]),
                ClaseProductoPadre = reader["Clase_Producto_Padre"] is string ? Convert.ToInt32(reader["Clase_Producto_Padre"]) : (int?)null,
                Descripcion = (string)reader["Descripcion"],
                Empresa = Convert.ToInt32(reader["Empresa"]),
                Raiz = Convert.ToInt32(reader["Raiz"]),
                UserName = (string)reader["UserName"],
                Estado = Convert.ToInt32(reader["Estado"]),
                Clasificacion = reader["Clasificacion"] is string ? Convert.ToInt32(reader["Clasificacion"]) : (int?) null,
                Codigo = (string)reader["Codigo"]
            };
            if (reader["M_UserName"] is string)
            {
                modelo.M_UserName = (string)reader["M_UserName"];
            }

            return modelo;
        }
    }
}