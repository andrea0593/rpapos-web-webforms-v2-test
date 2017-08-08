using rpapos_web_webforms.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace rpapos_web_webforms.Models
{
    public class DispositivoIOGrupoModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class DispositivoIOGrupoRepository : RepoBase<DispositivoIOGrupoModel>
    {
        public DispositivoIOGrupoRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<DispositivoIOGrupoModel> GetAll()
        {
            var query = "Select * from tbl_Dispositivo_IO_Grupo;";
            using (var command = new SqlCommand(query))
            {
                return GetRecords(command);
            }
        }

        public override DispositivoIOGrupoModel PopulateForeignRecord(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override DispositivoIOGrupoModel PopulateRecord(SqlDataReader reader)
        {
            return new DispositivoIOGrupoModel
            {
                Id = Convert.ToInt32(reader["Dispositivo_IO_Grupo"]),
                Descripcion = (string)reader["Nombre"]
            };
        }
    }
}