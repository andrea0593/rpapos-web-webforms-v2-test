using rpapos_web_webforms.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Linq;
using System.Web.UI.WebControls;

namespace rpapos_web_webforms
{
    public partial class MantenimientoUnidadMedida : Page
    {
        UnidadMedidaRepository repo;
        public List<UnidadMedida> data = new List<UnidadMedida>();


        protected void Page_Load(object sender, EventArgs e)
        {
            repo = new UnidadMedidaRepository(Session["ConnectionString"].ToString());
            CargarDatos();
        }

        public void CargarDatos()
        {
            data = repo.GetAll().ToList();
        }

        protected void buttonCreate_Click(object sender, EventArgs e)
        {
            var um = new UnidadMedida
            {
                Descripcion = textboxDescripcion.Text,
                Simbolo = textboxSimbolo.Text,
                Estado = 1,
                Fecha_Hora = DateTime.UtcNow,
                M_Fecha_Hora = null,
                M_UserName = null,
                Orden = 1,
                UserName = Session["Usuario"].ToString()
            };

            repo.Create(um);
            Limpiar();
            CargarDatos();
        }

        public void Limpiar() {
            textboxSimbolo.Text = string.Empty;
            textboxDescripcion.Text = string.Empty;
            textboxActualizarDescripcion.Text = string.Empty;
            textboxActualizarId.Text = string.Empty;
            textboxActualizarSimbolo.Text = string.Empty;
            textboxEliminarId.Text = string.Empty;
        }

        protected void buttonUpdate_Click(object sender, EventArgs e)
        {
            var unidadMedida = new UnidadMedida
            {
                Unidad_Medida = int.Parse(textboxActualizarId.Text),
                Descripcion = textboxActualizarDescripcion.Text,
                Simbolo = textboxActualizarSimbolo.Text,
                M_Fecha_Hora = DateTime.UtcNow,
                M_UserName = Session["Usuario"].ToString()
            };

            repo.Update(unidadMedida);
            Limpiar();
            CargarDatos();
        }

        protected void buttonDelete_Click(object sender, EventArgs e)
        {
            var id = int.Parse(textboxEliminarId.Text);
            var unidadAEliminar = data.Find(x => x.Unidad_Medida == id);
            unidadAEliminar.M_Fecha_Hora = DateTime.UtcNow;
            unidadAEliminar.M_UserName = Session["Usuario"].ToString();

            if (repo.Delete(unidadAEliminar))
            {
                Limpiar();
                CargarDatos();
            }
            else
            {

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "test", "alert('Error');", true);

            }
             
        }
    }
}