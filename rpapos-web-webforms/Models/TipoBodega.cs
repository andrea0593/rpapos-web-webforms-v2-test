using rpapos_web_webforms.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace rpapos_web_webforms.Models
{
    public class TipoBodega
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class TipoBodegaRepository : RepoBase<TipoBodega>
    {
        public TipoBodegaRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<TipoBodega> GetAll()
        {
            var query = "Select * from tbl_Tipo_Bodega;";
            using (var command = new SqlCommand(query))
            {
                return GetRecords(command);
            }
        }

        public override TipoBodega PopulateForeignRecord(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override TipoBodega PopulateRecord(SqlDataReader reader)
        {
            return new TipoBodega
            {
                Id = Convert.ToInt32(reader["Tipo_Bodega"]),
                Descripcion = (string)reader["Descripcion"]
            };
        }
    }
}