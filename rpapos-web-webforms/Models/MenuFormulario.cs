﻿using rpapos_web_webforms.Models.Repo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace rpapos_web_webforms.Models
{
    public class MenuFormulario
    {

        public int Rol_Formulario { get; set; }
        public int Aplicacion { get; set; }
        public int Rol { get; set; }
        public int Rol_Formulario_Padre { get; set; }
        public string Nombre { get; set; }
        public int Formulario { get; set; }
        public string Formulario_Nombre { get; set; }
        public string Formulario_URL { get; set; }


        public List<MenuFormulario> formularios { get; set; }


    }


    public class MenuFormularioRepo : RepoBase<MenuFormulario>
    {
        private string c;
        public MenuFormularioRepo(string connectionString) : base(connectionString)
        {
            c = connectionString;
        }
 


        public override MenuFormulario PopulateRecord(SqlDataReader reader)
        {
            var result = new MenuFormulario
            {
                Rol_Formulario = int.Parse(reader["Rol_Formulario"].ToString()),
                Aplicacion = int.Parse(reader["Aplicacion"].ToString()),
                Rol = int.Parse(reader["Rol"].ToString()),
                Rol_Formulario_Padre = int.Parse(reader["Rol_Formulario_Padre"].ToString()),
                Nombre = reader["Nombre"].ToString(),
                Formulario = int.Parse(reader["Formulario"].ToString()),
                Formulario_Nombre = reader["Formulario_Nombre"].ToString(),
                Formulario_URL = reader["Formulario_URL"].ToString(),
            };

            if (result.Formulario_Nombre.Equals("0")) {


                var formularioRepo = new MenuFormularioRepo(c);

                result.formularios = formularioRepo.GetAll(result.Aplicacion, result.Rol, result.Rol_Formulario).ToList();


            }


            return result;

        }

        public IEnumerable<MenuFormulario> GetAll(int Aplicacion , int Rol ,int Rol_Formulario_Padre)
        {

            using (var command = new SqlCommand(
                @"
SELECT T1.Rol_Formulario  , T1.Aplicacion , T1.Rol
	,ISNULL(T1.Rol_Formulario_Padre,0) AS Rol_Formulario_Padre
	,T1.Nombre
	,ISNULL(T1.Formulario,0) AS Formulario
	,ISNULL(T2.Nombre,0) AS Formulario_Nombre
	,ISNULL(T2.URL,0) AS Formulario_URL
FROM RPA_Catalogo.dbo.tbl_Rol_Formulario AS T1
	LEFT OUTER JOIN RPA_Catalogo.dbo.tbl_Formulario AS T2
		ON T1.Formulario = T2.Formulario AND T2.URL IS NOT NULL
WHERE T1.Aplicacion = " + Aplicacion+
" AND T1.Rol = "+Rol+" AND ISNULL(T1.Rol_Formulario_Padre,0) = "+Rol_Formulario_Padre+ 
@" ORDER BY CASE 

        WHEN T1.Formulario IS NULL

        THEN 0

        ELSE 1

        END
    , CASE T2.Nombre

        WHEN 'Mantenimiento' THEN 1

        WHEN 'Proceso' THEN 2

        WHEN 'Reporte' THEN 3

        WHEN 'Configuración' THEN 4

        WHEN 'Catalogos' THEN 5

        WHEN 'Tipos' THEN 6

        WHEN 'Cuentas' THEN 7

        ELSE 8

        END
    , ISNULL(T2.Nombre, ''); "
                ))
            {
                return GetRecords(command);
            }
        }

        public override MenuFormulario PopulateForeignRecord(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }

}