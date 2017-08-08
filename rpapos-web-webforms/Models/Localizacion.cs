using rpapos_web_webforms.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace rpapos_web_webforms.Models
{
    public class LocalizacionModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class LocalizacionRepository : RepoBase<LocalizacionModel>
    {
        public LocalizacionRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<LocalizacionModel> GetForeignRecords()
        {
            var query = "Select Localizacion, Descripcion from tbl_Localizacion where Estado = 1;";
            using (var command = new SqlCommand(query))
            {
                return GetForeignRecords(command);
            }
        }

        public override LocalizacionModel PopulateForeignRecord(SqlDataReader reader)
        {
            return new LocalizacionModel
            {
                Id = Convert.ToInt32(reader["Localizacion"]),
                Descripcion = (string)reader["Descripcion"]
            };
        }

        public override LocalizacionModel PopulateRecord(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}