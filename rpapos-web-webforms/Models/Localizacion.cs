using rpapos_web_webforms.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace rpapos_web_webforms.Models
{
    public class Localizacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class LocalizacionRepository : RepoBase<Localizacion>
    {
        public LocalizacionRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Localizacion> GetForeignRecords()
        {
            var query = "Select Localizacion, Descripcion from tbl_Localizacion where Estado = 1;";
            using (var command = new SqlCommand(query))
            {
                return GetForeignRecords(command);
            }
        }

        public override Localizacion PopulateForeignRecord(SqlDataReader reader)
        {
            return new Localizacion
            {
                Id = Convert.ToInt32(reader["Localizacion"]),
                Descripcion = (string)reader["Descripcion"]
            };
        }

        public override Localizacion PopulateRecord(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}