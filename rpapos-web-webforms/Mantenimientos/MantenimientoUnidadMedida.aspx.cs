using rpapos_web_webforms.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Linq;
using System.Web.UI.WebControls;

namespace rpapos_web_webforms.Mantenimientos
{
    public partial class MantenimientoUnidadMedida : Page
    {
        UnidadMedidaRepository repo;
        public List<UnidadMedida> data = new List<UnidadMedida>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ConnectionString"] == null)
            {
                Response.Redirect("/login.aspx");
                return;
            }
            repo = new UnidadMedidaRepository(Session["ConnectionString"].ToString());
            CargarDatos();
        }

        public void CargarDatos()
        {
            data = repo.GetAll().ToList();
        }

        protected void buttonCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textboxDescripcion.Text) || string.IsNullOrWhiteSpace(textboxDescripcion.Text) || string.IsNullOrEmpty(textboxSimbolo.Text) || string.IsNullOrWhiteSpace(textboxSimbolo.Text))
                return;
            var um = new UnidadMedida
            {
                Descripcion = textboxDescripcion.Text,
                Simbolo = textboxSimbolo.Text,
                Estado = 1,
                M_UserName = null,
                Orden = 1,
                UserName = Session["UserName"].ToString()
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
            defaultTextbox.Text = string.Empty;
        }

        protected void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textboxActualizarId.Text) || string.IsNullOrWhiteSpace(textboxActualizarId.Text) || string.IsNullOrEmpty(textboxActualizarDescripcion.Text) || string.IsNullOrWhiteSpace(textboxActualizarDescripcion.Text) || string.IsNullOrEmpty(textboxActualizarSimbolo.Text) || string.IsNullOrWhiteSpace(textboxActualizarSimbolo.Text))
                return;
            var unidadMedida = new UnidadMedida
            {
                Unidad_Medida = int.Parse(textboxActualizarId.Text),
                Descripcion = textboxActualizarDescripcion.Text,
                Simbolo = textboxActualizarSimbolo.Text,
                M_UserName = Session["UserName"].ToString()
            };

            repo.Update(unidadMedida);
            Limpiar();
            CargarDatos();
        }

        protected void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textboxEliminarId.Text) || string.IsNullOrWhiteSpace(textboxEliminarId.Text))
                return;
            var id = int.Parse(textboxEliminarId.Text);
            var unidadAEliminar = data.Find(x => x.Unidad_Medida == id);
            unidadAEliminar.M_UserName = Session["UserName"].ToString();

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

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            switch(defaultTextbox.Text)
            {
                case "create":
                    buttonCreate_Click(sender, e);
                    break;
                case "update":
                    buttonUpdate_Click(sender, e);
                    break;
                case "delete":
                    buttonDelete_Click(sender, e);
                    break;
                default:
                    return;
            }
        }
    }
}