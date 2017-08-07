using rpapos_web_webforms.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace rpapos_web_webforms.Models
{
    public class Bodega
    {
        public int Id { get; set; }
        //public int Empresa { get; set; } siempre es 1
        public string Nombre { get; set; }
        //public int Raiz siempre es el ID
        //public int Nivel siempre es 1
        //bodega_padre null
        //public DateTime FechaHora { get; set; } usar getdate()
        public string UserName { get; set; }
        //public DateTime MFechaHora { get; set; } usar getdate()
        public string MUserName { get; set; }
        public int TipoBodega { get; set; }
        public string TipoBodegaDescripcion { get; set; }
        public bool Trasegar { get; set; }
        public int Localizacion { get; set; }
        public string LocalizacionDescripcion { get; set; }
        public int Orden { get; set; }
        public bool Produccion { get; set; }
        public bool OpcionCompra { get; set; }
        public int Entidad { get; set; }
        public string Codigo { get; set; }
        public bool ERPSync { get; set; }
        public double DescuentoPorcentajeMaximo { get; set; }
        public int DispositivoIOGrupo { get; set; }
    }

    public class BodegaRepository : RepoBase<Bodega>
    {
        public BodegaRepository(string connectionString) : base(connectionString)
        {
        }

        public bool Create(Bodega model)
        {
            var query = $@"
declare @bodega int = 0

select @bodega = max(bodega)
from tbl_bodega
set @bodega = isnull(@bodega, 0) + 1

Insert Into tbl_Bodega
(Bodega, Empresa, Nombre, Raiz, Nivel, Bodega_Padre, Fecha_Hora, UserName, Tipo_Bodega, Trasegar, Localizacion, Orden, Produccion,
Opc_Compra, Entidad, Codigo, ERP_Sync, Descuento_Por_Maximo, Dispositivo_IO_Grupo)
values
(@bodega, 1, '{model.Nombre}', @bodega, 1, null, getdate(), '{model.UserName}', {model.TipoBodega}, {(model.Trasegar ? 1 : 0)}, {model.Localizacion}, {model.Orden}, {(model.Produccion ? 1 : 0)}, 
{(model.OpcionCompra ? 1 : 0)}, {model.Entidad}, '{model.Codigo}', {(model.ERPSync ? 1 : 0)}, {model.DescuentoPorcentajeMaximo}, '{model.DispositivoIOGrupo}')";

            using (var command = new SqlCommand(query))
            {
                return NonQuery(command);
            }
        }

        public bool Update(Bodega model)
        {
            var query = $@"
Update tbl_bodega
Set Nombre = '{model.Nombre}',
    M_Fecha_Hora = getdate(),
    M_UserName = '{model.MUserName}',
    Tipo_Bodega = {model.TipoBodega},
    Trasegar = {(model.Trasegar ? 1 : 0)},
    Localizacion = {model.Localizacion},
    Orden = {model.Orden},
    Produccion = {(model.Produccion ? 1 : 0)},
    Opc_Compra = {(model.OpcionCompra ? 1 : 0)},
    Entidad = {model.Entidad},
    Descuento_Por_Maximo = {model.DescuentoPorcentajeMaximo},
    Dispositivo_IO_Grupo = {model.DispositivoIOGrupo},
    Codigo = '{model.Codigo}',
    ERP_Sync = {(model.ERPSync ? 1 : 0)}
";

            using (var command = new SqlCommand(query))
            {
                return NonQuery(command);
            }
        }

        public bool Delete(Bodega model)
        {
            return true;
        }

        public IEnumerable<Bodega> GetAll()
        {
            var query = @"
Select b.Bodega, b.Nombre, b.Fecha_Hora, b.UserName, b.M_Fecha_Hora, b.M_UserName, tb.Tipo_Bodega, tb.Descripcion as 'Tipo_Bodega_Descripcion', 
b.Trasegar, b.Localizacion, l.Descripcion as 'Localizacion_Descripcion', b.Orden, b.Produccion, b.Opc_Compra, b.Entidad, b.Codigo, b.ERP_Sync, b.Descuento_Por_Maximo, b.Dispositivo_IO_Grupo
From tbl_Bodega b
Inner Join tbl_Tipo_Bodega tb
on b.Tipo_Bodega = tb.Tipo_Bodega
Inner Join tbl_Localizacion l
on b.Localizacion = l.Localizacion;";
            using (var command = new SqlCommand(query))
            {
                return GetRecords(command);
            }
        }

        public override Bodega PopulateRecord(SqlDataReader reader)
        {
            var model = new Bodega
            {
                Id = Convert.ToInt32(reader["Bodega"]),
                Nombre = (string)reader["Nombre"],
                UserName = (string)reader["UserName"],
                TipoBodega = Convert.ToInt32(reader["Tipo_Bodega"]),
                TipoBodegaDescripcion = (string)reader["Tipo_Bodega_Descripcion"],
                Trasegar = Convert.ToInt32(reader["Trasegar"]) == 1 ? true : false,
                Localizacion = Convert.ToInt32(reader["Localizacion"]),
                LocalizacionDescripcion = (string)reader["Localizacion_Descripcion"],
                Orden = Convert.ToInt32(reader["Orden"]),
                Produccion = Convert.ToInt32(reader["Produccion"]) == 1 ? true : false,
                OpcionCompra = Convert.ToInt32(reader["Opc_Compra"]) == 1 ? true : false,
                Entidad = Convert.ToInt32(reader["Entidad"]),
                DispositivoIOGrupo = Convert.ToInt32(reader["Dispositivo_IO_Grupo"])
            };

            if(reader["Descuento_Por_Maximo"] is string)
            {
                model.DescuentoPorcentajeMaximo = Convert.ToDouble(reader["Descuento_Por_Maximo"]);
            }

            if (reader["M_UserName"] is string)
            {
                model.MUserName = (string)reader["M_UserName"];
            }

            if(reader["Codigo"] is string)
            {
                model.Codigo = (string)reader["Codigo"];
            }

            if(reader["ERP_Sync"] is string)
            {
                model.ERPSync = Convert.ToInt32(reader["ERP_Sync"]) == 1;
            }
            

            return model;
        }

        public override Bodega PopulateForeignRecord(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}