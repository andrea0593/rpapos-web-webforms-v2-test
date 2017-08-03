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
            cargarDatos();

          //  ScriptManager.RegisterStartupScript(this, typeof(Page), "test", "$('#gridViewUnidadMedida').DataTable(); ", true);

        }

        public void cargarDatos()
        {
            UnidadMedidaRepository repo = new UnidadMedidaRepository(Session["ConnectionString"].ToString());
            gridViewUnidadMedida.DataSource = repo.GetAll();
            gridViewUnidadMedida.DataBind();
            gridViewUnidadMedida.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void buttonCreate_Click(object sender, EventArgs e)
        {
            UnidadMedida newUM = new UnidadMedida
            {
                Descripcion = textboxDescripcion.Text,
                Simbolo = textboxSimbolo.Text
            };
            Data.Instance.UnidadesDeMedida.Add(newUM);
            limpiar();
            cargarDatos();
        }

        public void limpiar() {
            textboxSimbolo.Text = string.Empty;
            textboxDescripcion.Text = string.Empty;
        }
    }
}