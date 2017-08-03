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

        public override bool Create(UnidadMedida model)
        {
            using (var command = new SqlCommand("delete From tbl_Unidad_Medida where Unidad_Medida = " + model.Unidad_Medida + ";"))
            {
                return NonQuery(command);
            }

        }

        public override bool Update(UnidadMedida model)
        {
            using (var command = new SqlCommand("delete From tbl_Unidad_Medida where Unidad_Medida = " + model.Unidad_Medida + ";"))
            {
                return NonQuery(command);
            }

        }

        public override bool Delete(UnidadMedida model)
        {
            var command = new SqlCommand();
            command.CommandText = "PA_tbl_Unidad_Medida";
            command.CommandType =  CommandType.StoredProcedure ;
            command.Parameters.Add(new SqlParameter("@TAccion", SqlDbType.TinyInt ));
            /*
        daUnidad_Medida.SelectCommand.Parameters.Add(New SqlParameter("@TOpcion", SqlDbType.TinyInt))

        daUnidad_Medida.SelectCommand.Parameters.Add(New SqlParameter("@pUnidad_Medida", SqlDbType.tinyint))
        daUnidad_Medida.SelectCommand.Parameters.Add(New SqlParameter("@pDescripcion", SqlDbType.varchar, 100))
        daUnidad_Medida.SelectCommand.Parameters.Add(New SqlParameter("@pSimbolo", SqlDbType.varchar, 10))
        daUnidad_Medida.SelectCommand.Parameters.Add(New SqlParameter("@pFecha_Hora", SqlDbType.datetime))
        daUnidad_Medida.SelectCommand.Parameters.Add(New SqlParameter("@pUserName", SqlDbType.varchar, 30))
        daUnidad_Medida.SelectCommand.Parameters.Add(New SqlParameter("@pM_Fecha_Hora", SqlDbType.datetime))
        daUnidad_Medida.SelectCommand.Parameters.Add(New SqlParameter("@pM_UserName", SqlDbType.varchar, 30))
        daUnidad_Medida.SelectCommand.Parameters.Add(New SqlParameter("@pOrden", SqlDbType.tinyint))
        daUnidad_Medida.SelectCommand.Parameters.Add(New SqlParameter("@pEstado", SqlDbType.tinyint))

        daUnidad_Medida.SelectCommand.Parameters("@pUnidad_Medida").Direction = ParameterDirection.InputOutput

        daUnidad_Medida.SelectCommand.Parameters.Add("@vReturnValue", SqlDbType.Int)
        daUnidad_Medida.SelectCommand.Parameters("@vReturnValue").Direction = ParameterDirection.ReturnValue

        daUnidad_Medida.SelectCommand.Parameters("@TAccion").Value = pTAccion
        daUnidad_Medida.SelectCommand.Parameters("@TOpcion").Value = pTOpcion
        daUnidad_Medida.SelectCommand.Parameters("@pUnidad_Medida").Value = vUnidad_Medida
        daUnidad_Medida.SelectCommand.Parameters("@pDescripcion").Value = vDescripcion
        daUnidad_Medida.SelectCommand.Parameters("@pSimbolo").Value = vSimbolo
        daUnidad_Medida.SelectCommand.Parameters("@pFecha_Hora").Value = vFecha_Hora
        daUnidad_Medida.SelectCommand.Parameters("@pUserName").Value = vUserName
        daUnidad_Medida.SelectCommand.Parameters("@pM_Fecha_Hora").Value = vM_Fecha_Hora
        daUnidad_Medida.SelectCommand.Parameters("@pM_UserName").Value = vM_UserName
        daUnidad_Medida.SelectCommand.Parameters("@pOrden").Value = vOrden
        daUnidad_Medida.SelectCommand.Parameters("@pEstado").Value = vEstado

        daUnidad_Medida.Fill(dsUnidad_Medida, "PA_tbl_Unidad_Medida")
             */

            return true;


        }

        public IEnumerable<UnidadMedida> GetAll()
        {

            using (var command = new SqlCommand("Select * From tbl_Unidad_Medida;"))
            {
                return GetRecords(command);
            }
        }

     


        public override UnidadMedida PopulateRecord(SqlDataReader reader)
        {
            return new UnidadMedida
            {
                Unidad_Medida = int.Parse(reader["Unidad_Medida"].ToString()),
                Descripcion = reader["Descripcion"].ToString(),
                Simbolo = reader["Simbolo"].ToString()
            };
        }

      
    }
}

