using rpapos_web_webforms.Models;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rpapos_web_webforms
{
    public partial class MantenimientoUnidadMedida : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gridViewUnidadMedida.EnableDynamicData(typeof(UnidadMedida));
            CargarDatos();

          //  ScriptManager.RegisterStartupScript(this, typeof(Page), "test", "$('#gridViewUnidadMedida').DataTable(); ", true);

        }

        public void CargarDatos()
        {
            var repo = new UnidadMedidaRepository(Session["ConnectionString"].ToString());
            gridViewUnidadMedida.DataSource = repo.GetAll();
            gridViewUnidadMedida.DataBind();
            gridViewUnidadMedida.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void buttonCreate_Click(object sender, EventArgs e)
        {
            var temp = new UnidadMedida
            {
                Descripcion = textboxDescripcion.Text,
                Simbolo = textboxSimbolo.Text,
                Estado = 1,
                Fecha_Hora = DateTime.UtcNow,
                M_Fecha_Hora = null,
                UserName = Session["Usuario"].ToString(),
                M_UserName = null,
                Orden = 0 //TODO: get last order
            };

            var repo = new UnidadMedidaRepository(Session["ConnectionString"].ToString());
            repo.Create(temp);

            Limpiar();
            CargarDatos();
        }

        public void Limpiar() {
            textboxSimbolo.Text = string.Empty;
            textboxDescripcion.Text = string.Empty;
        }
    }
}