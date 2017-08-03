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

            return StorageProcedure(1, 1, model);

        }

        public  bool Update(UnidadMedida model )
        {

            return StorageProcedure(2, 1, model);

        }

        public  bool Delete(UnidadMedida model )
        {
          


            return StorageProcedure(3,1,model);


        }



        public  bool StorageProcedure(  int pTAccion , int pTOpcion , UnidadMedida modelo )
        {
            var command = new SqlCommand();
            command.CommandText = "PA_tbl_Unidad_Medida";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@TAccion", SqlDbType.TinyInt));
            command.Parameters.Add(new SqlParameter("@TOpcion", SqlDbType.TinyInt));

            command.Parameters.Add(new SqlParameter("@pUnidad_Medida", SqlDbType.TinyInt));
            command.Parameters.Add(new SqlParameter("@pDescripcion", SqlDbType.VarChar, 100));
            command.Parameters.Add(new SqlParameter("@pSimbolo", SqlDbType.VarChar, 10));
            command.Parameters.Add(new SqlParameter("@pFecha_Hora", SqlDbType.DateTime));
            command.Parameters.Add(new SqlParameter("@pUserName", SqlDbType.VarChar, 30));
            command.Parameters.Add(new SqlParameter("@pM_Fecha_Hora", SqlDbType.DateTime));
            command.Parameters.Add(new SqlParameter("@pM_UserName", SqlDbType.VarChar, 30));
            command.Parameters.Add(new SqlParameter("@pOrden", SqlDbType.TinyInt));
            command.Parameters.Add(new SqlParameter("@pEstado", SqlDbType.TinyInt));

            command.Parameters["@pUnidad_Medida"].Direction = ParameterDirection.InputOutput;


            command.Parameters.Add(new SqlParameter("@vReturnValue", SqlDbType.Int));
            command.Parameters["@vReturnValue"].Direction = ParameterDirection.ReturnValue;

            command.Parameters["@TAccion"].Value = pTAccion;
            command.Parameters["@TOpcion"].Value = pTOpcion;

            command.Parameters["@pUnidad_Medida"].Value = modelo.Unidad_Medida;
            command.Parameters["@pDescripcion"].Value = modelo.Descripcion;
            command.Parameters["@pSimbolo"].Value = modelo.Simbolo;
          //  command.Parameters["@pFecha_Hora"].Value = modelo.Fecha_Hora.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            command.Parameters["@pUserName"].Value = modelo.UserName;
        //    command.Parameters["@pM_Fecha_Hora"].Value = modelo.M_Fecha_Hora?.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            command.Parameters["@pM_UserName"].Value = modelo.M_UserName;
            command.Parameters["@pOrden"].Value = modelo.Orden;
            command.Parameters["@pEstado"].Value = modelo.Estado;


            DataSet data = new DataSet();



            command.Connection = connection;
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter(command);
           
            da.Fill(data, "PA_tbl_Unidad_Medida");
             

            bool r = false;

            if (data.Tables.Count > 0) {
                if (data.Tables[0].Rows.Count > 0)
                {
                    r = true;
                }
            }

            connection.Close();
            return r;


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

