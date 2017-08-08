using rpapos_web_webforms.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace rpapos_web_webforms.Models
{
    public class TipoBodegaModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class TipoBodegaRepository : RepoBase<TipoBodegaModel>
    {
        public TipoBodegaRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<TipoBodegaModel> GetAll()
        {
            var query = "Select * from tbl_Tipo_Bodega;";
            using (var command = new SqlCommand(query))
            {
                return GetRecords(command);
            }
        }

        public override TipoBodegaModel PopulateForeignRecord(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override TipoBodegaModel PopulateRecord(SqlDataReader reader)
        {
            return new TipoBodegaModel
            {
                Id = Convert.ToInt32(reader["Tipo_Bodega"]),
                Descripcion = (string)reader["Descripcion"]
            };
        }
    }
}