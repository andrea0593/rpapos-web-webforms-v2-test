using rpapos_web_webforms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rpapos_web_webforms.Mantenimientos
{
    public partial class MantenimientoBodega : System.Web.UI.Page
    {
        private BodegaRepository repository;
        private TipoBodegaRepository repositoryTipoBodega;
        public LocalizacionRepository repositoryLocalizacion;
        public List<Bodega> data = new List<Bodega>();
        public List<TipoBodega> dataTipoBodega = new List<TipoBodega>();
        public List<Localizacion> dataLocalizacion = new List<Localizacion>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ConnectionString"] == null)
            {
                Response.Redirect("/login.aspx");
                return;
            }
            repository = new BodegaRepository(Session["ConnectionString"].ToString());
            repositoryTipoBodega = new TipoBodegaRepository(Session["ConnectionString"].ToString());
            repositoryLocalizacion = new LocalizacionRepository(Session["ConnectionString"].ToString());
            CargarDatos();
        }

        public void CargarDatos()
        {
            data = repository.GetAll().ToList();
            dataTipoBodega = repositoryTipoBodega.GetAll().ToList();
            dataLocalizacion = repositoryLocalizacion.GetForeignRecords().ToList();
        }
    }
}