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
        private BodegaRepository bodegaRepository;
        private TipoBodegaRepository tipoBodegaRepository;
        private LocalizacionRepository localizacionRepository;
        private DispositivoIOGrupoRepository dispositivoIOGrupoRepository; 

        public List<Bodega> data = new List<Bodega>();
        public List<TipoBodegaModel> dataTipoBodega = new List<TipoBodegaModel>();
        public List<LocalizacionModel> dataLocalizacion = new List<LocalizacionModel>();
        public List<DispositivoIOGrupoModel> dataDispositivoIOGrupo = new List<DispositivoIOGrupoModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ConnectionString"] == null)
            {
                Response.Redirect("/login.aspx");
                return;
            }
            bodegaRepository = new BodegaRepository(Session["ConnectionString"].ToString());
            tipoBodegaRepository = new TipoBodegaRepository(Session["ConnectionString"].ToString());
            localizacionRepository = new LocalizacionRepository(Session["ConnectionString"].ToString());
            dispositivoIOGrupoRepository = new DispositivoIOGrupoRepository(Session["ConnectionString"].ToString());
            CargarDatos();
        }

        public void CargarDatos()
        {
            data = bodegaRepository.GetAll().ToList();
            dataTipoBodega = tipoBodegaRepository.GetAll().ToList();
            dataLocalizacion = localizacionRepository.GetForeignRecords().ToList();
            dataDispositivoIOGrupo = dispositivoIOGrupoRepository.GetAll().ToList();
        }

        protected void buttonCreate_Click(object sender, EventArgs e)
        {
            var bodega = new Bodega
            {
                Nombre = textboxNombre.Text,
                UserName = Session["UserName"].ToString(),
                TipoBodega = Convert.ToInt32(textboxTipoBodega.Text),
                Trasegar = checkboxTrasegar.Checked,
                Localizacion = Convert.ToInt32(textboxLocalizacion.Text),
                Codigo = textboxCodigo.Text,
                DescuentoPorcentajeMaximo = Convert.ToDouble(textboxDescuentoMaximo.Text) / 100,
                DispositivoIOGrupo = Convert.ToInt32(textboxGrupoDispositivos.Text),
                Orden = Convert.ToInt32(textboxOrden.Text),
                Produccion = checkboxProduccion.Checked,
                OpcionCompra = checkboxOpcionCompra.Checked,
                ERPSync = checkboxErpSync.Checked,

            };
            bodegaRepository.Create(bodega);
            Limpiar();
            CargarDatos();
        }

        public void Limpiar() {
            textboxNombre.Text = string.Empty;
            textboxTipoBodega.Text = string.Empty;
            textboxLocalizacion.Text = string.Empty;
            textboxCodigo.Text = string.Empty;
            textboxDescuentoMaximo.Text = string.Empty;
            textboxGrupoDispositivos.Text = string.Empty;
            textboxOrden.Text = string.Empty;
            checkboxTrasegar.Checked = false;
            checkboxProduccion.Checked = false;
            checkboxOpcionCompra.Checked = false;
            checkboxErpSync.Checked = false;
        }

        protected void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textboxActualizarId.Text) || string.IsNullOrWhiteSpace(textboxActualizarId.Text) ||
               string.IsNullOrEmpty(textboxActualizarNombre.Text) || string.IsNullOrWhiteSpace(textboxActualizarNombre.Text) ||
               string.IsNullOrEmpty(textboxActualizarTipoBodega.Text) || string.IsNullOrWhiteSpace(textboxActualizarTipoBodega.Text) ||
               string.IsNullOrEmpty(textboxActualizarLocalizacion.Text) || string.IsNullOrWhiteSpace(textboxActualizarLocalizacion.Text) ||
               string.IsNullOrEmpty(textboxActualizarCodigo.Text) || string.IsNullOrWhiteSpace(textboxActualizarCodigo.Text) ||
               string.IsNullOrEmpty(textboxActualizarDescuentoMaximo.Text) || string.IsNullOrWhiteSpace(textboxActualizarDescuentoMaximo.Text) ||
               string.IsNullOrEmpty(textboxActualizarGrupoDispositivos.Text) || string.IsNullOrWhiteSpace(textboxActualizarGrupoDispositivos.Text) ||
               string.IsNullOrEmpty(textboxActualizarOrden.Text) || string.IsNullOrWhiteSpace(textboxActualizarOrden.Text)
               )
            {
                return;
            }

            var bodega = new Bodega
            {
                Id = int.Parse(textboxActualizarId.Text),
                Nombre = textboxActualizarNombre.Text,
                //M_UserName = Session["UserName"].ToString(),
                TipoBodega = int.Parse(textboxActualizarTipoBodega.Text),
                Trasegar = checkboxActualizarTrasegar.Checked,
                Localizacion = int.Parse(textboxActualizarLocalizacion.Text),
                Orden = int.Parse(textboxActualizarOrden.Text),
                Produccion = checkboxActualizarProduccion.Checked,
                OpcionCompra = checkboxActualizarOpcionCompra.Checked,
                Codigo = textboxActualizarCodigo.Text,
                ERPSync = checkboxActualizarErpSync.Checked,
                DescuentoPorcentajeMaximo = int.Parse(textboxActualizarDescuentoMaximo.Text),
                DispositivoIOGrupo = int.Parse(textboxActualizarGrupoDispositivos.Text)
            };

            bodegaRepository.Update(bodega);
            Limpiar();
            CargarDatos();
        }
    }
}