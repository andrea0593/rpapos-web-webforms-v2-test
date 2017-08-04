using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

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
        public DateTime? M_Fecha_Hora { get; set; }
        [ScaffoldColumn(false)]
        public string M_UserName { get; set; }
        [ScaffoldColumn(false)]
        public int Orden { get; set; }
        [ScaffoldColumn(false)]
        public int Estado { get; set; }
    }


    public class UnidadMedidaRepository : DALRepository<UnidadMedida>
    {
        public UnidadMedidaRepository(string connectionString) : base(connectionString)
        {
        }

        public bool Create(UnidadMedida model)
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

        public bool Update(UnidadMedida model)
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

        public bool Delete(UnidadMedida model)
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




        public IEnumerable<UnidadMedida> GetAll()
        {

            using (var command = new SqlCommand("Select * From tbl_Unidad_Medida where estado = 1;"))
            {
                return GetRecords(command);
            }
        }




        public override UnidadMedida PopulateRecord(SqlDataReader reader)
        {
            var modelo = new UnidadMedida()
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

