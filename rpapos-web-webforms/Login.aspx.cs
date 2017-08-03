using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rpapos_web_webforms
{
    public partial class Login : System.Web.UI.Page
    {
        private string subDomain;
        protected void Page_Load(object sender, EventArgs e)
        {


            var domain = HttpContext.Current.Request.Url.Host.ToString().ToLower();
            if (domain.Contains("-test")) {
            domain =     domain.Replace("-test", "");
            }
            var url = domain.Split('.');

#if DEBUG
            domain = domain + " DEBUG";
#endif



            LabelDomain.Text = domain;
            var connectionString = "";
            if (url.Count() > 0)
            {
               subDomain = url[0];
 
                connectionString = DAL.connectionStringFromSubdomain(subDomain);
            
                Session["SubDomain"] = subDomain;
                var logo = DAL.ImagetoBase(DAL.clientLogo(connectionString, 250));
                Session["Logo"] = logo;
                Session["LogoSmall"] = DAL.ImagetoBase(DAL.clientLogo(connectionString, 48)); 

                imgEmpresa.ImageUrl =logo;
            }

 

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {

            var connectionString = DAL.connectionStringFromSubdomain(subDomain);


            var connection = new SqlConnection(connectionString);
            var pUserName = TextBoxUsername.Text;
            var pPassword = TextBoxPassword.Text;
            try
            {
                connection.Open();

                var sql = "select * , t2.Descripcion as Estacion_Trabajo_Descripcion from tbl_usuario as t1"+
                    " inner join tbl_Estacion_Trabajo as t2 on t1.Estacion_Trabajo =t2.Estacion_Trabajo "+
                    " WHERE (t1.UserName = '" + pUserName + "' OR t1.EMail = '" + pUserName + 
                    "') AND t1.Clave = '" + pPassword + "';";
                var command = new SqlCommand(sql, connection);


                var dataReader = command.ExecuteReader();


                if (dataReader.Read())
                {
                    Session["UserName"] = dataReader["UserName"];
                    Session["EMail"] = dataReader["EMail"];
                    Session["Nombres"] = dataReader["Nombres"];
                    Session["Usuario"] = dataReader["Usuario"];

                    Session["Estacion_Trabajo"] = dataReader["Estacion_Trabajo"];
                    Session["Estacion_Trabajo_Descripcion"] = dataReader["Estacion_Trabajo_Descripcion"];

                    Session["ConnectionString"] = connectionString;
                    Response.Redirect("Test.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "test", "alert('Usuario o password invalido');",true);

                    //  ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", $"toastr.error('There was an error', 'Error')", true);

                    // ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "myScriptName" , $"alert('caca')", true);
                    //   ClientScript
                    //  ScriptManager.RegisterStartupScript(this, GetType(), "", "toastr.info('Customer Added','Message')", true);
                    // Page.ClientScript.RegisterStartupScript(this.GetType(),  "", "toastr.error('There was an error', 'Error')", true);
                }




            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally {

                connection.Close();
            }


             
        }
    }
}