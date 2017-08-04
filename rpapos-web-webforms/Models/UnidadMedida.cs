using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
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
        public  DateTime? M_Fecha_Hora { get; set; }
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

        public  bool Create(UnidadMedida model )
        {
            string sql =

                @"
declare @vUnidad_Medida int = 0

select @vUnidad_Medidamax(unidad_medida)
from tbl_unidad_medida
set @vUnidad_Medida = isnull(@vUnidad_Medida,0) + 1

insert into tbl_unidad_medida
(unidad_medida)
values(@vUnidad_Medida)

select @vUnidad_Medida as Unidad_Medida;


";
            return true;

        }

        public  bool Update(UnidadMedida model )
        {
            string sql =

                @"

update tbl_unidad_medida
set descripcion = '" + model.Descripcion + @"'
    ,m_fecha_hora = getdate()
where unidad_medida = " + model.Unidad_Medida + @"
";

            return true;
        }

        public  bool Delete(UnidadMedida model )
        {

            string sql =

                @"

delete from tbl_unidad_medida
where unidad_medida = " + model.Unidad_Medida + @"
";

            return true;
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
            var n = new UnidadMedida();
    


            n.Unidad_Medida = Convert.ToInt32(reader["Unidad_Medida"]);
            n.Descripcion = (string)reader["Descripcion"];
            n.Simbolo = (string)reader["Simbolo"];
            n.Fecha_Hora = (DateTime)reader["Fecha_Hora"];
            n.UserName = (string)reader["UserName"];
            if (reader["M_Fecha_Hora"] is DateTime)
            {
                n.M_Fecha_Hora = (DateTime)reader["M_Fecha_Hora"];
            }
            if (reader["M_UserName"] is string)
            {
                n.M_UserName = (string)reader["M_UserName"];
            }
             
            n.Orden = Convert.ToInt32(reader["Orden"]);
            n.Estado = Convert.ToInt32(reader["Estado"]);
         
            return n;
        }

 

    }
}

