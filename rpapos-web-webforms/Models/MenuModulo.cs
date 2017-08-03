using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace rpapos_web_webforms.Models
{
    public class MenuModulo
    {

        public int Aplicacion { get; set; }
        public string Nombre { get; set; }
        public int Rol { get; set; }
        public List<MenuFormulario> formularios { get; set; }
      


    }

    public class MenuModuloRepo : DALRepository<MenuModulo>
    {
        private string c;
        public MenuModuloRepo(string connectionString) : base(connectionString)
        {
            c = connectionString;
        }

        public override bool Create(MenuModulo model)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(MenuModulo model)
        {
            throw new NotImplementedException();
        }

     

        public override bool Update(MenuModulo model)
        {
            throw new NotImplementedException();
        }

        public override MenuModulo PopulateRecord(SqlDataReader reader)
        {
            var result =  new MenuModulo
            {
                Aplicacion = int.Parse(reader["Aplicacion"].ToString()),
                Nombre = reader["Nombre"].ToString(),
                Rol = int.Parse(reader["Rol"].ToString())
            };
            
            
            var formularioRepo = new MenuFormularioRepo(c);

            result.formularios =  formularioRepo.GetAll(result.Aplicacion, result.Rol, 0).ToList();

            return result;

        }

        public IEnumerable<MenuModulo> GetAll(int Usuario)
        {

            using (var command = new SqlCommand(
                @"SELECT T1.Aplicacion
,T2.Nombre
	,T1.Rol
FROM tbl_Usuario_Rol AS T1
	INNER JOIN RPA_Catalogo.dbo.tbl_Aplicacion AS T2
		ON T1.Aplicacion = T2.Aplicacion
WHERE T1.Usuario = "+Usuario+";"
                ))
            {
                return GetRecords(command);
            }
        }


    }

}