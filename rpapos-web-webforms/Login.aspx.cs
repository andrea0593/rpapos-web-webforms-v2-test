using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rpapos_web_webforms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var url = HttpContext.Current.Request.Url.Host.ToString().ToLower().Split('.');


            switch (url[0])
            {
                case "localhost":
                    {

                        Response.Cookies["UserSettings"]["server"] = "localhost";

                        Session["db"] = "localhost";


                    }
                    break;
                default:
                    {
                        //setiar imagen
                    }
                    break;

            }




        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {

            string connetionString = @"Data Source=KRUDOS-W10\SQLEXPRESS;Initial Catalog=POS;User ID=SA;Password=Chimlapu69";
            var connection = new SqlConnection(connetionString);
            var pUserName = TextBoxUsername.Text;
            var pPassword = TextBoxPassword.Text;
            try
            {
                connection.Open();

                var sql = "Select * From tbl_Usuario  WHERE (UserName = '" + pUserName + "' OR EMail = '" + pUserName + "') AND Clave = '" + pPassword + "';";
                var command = new SqlCommand(sql, connection);


                var dataReader = command.ExecuteReader();


                if (dataReader.Read())
                {
                    Session["user"] = pUserName;
                    Response.Redirect("Test.aspx");
                }
                else
                {
                    //   ClientScript
                 //  ScriptManager.RegisterStartupScript(this, GetType(), "", "toastr.info('Customer Added','Message')", true);
                  //    Page.ClientScript.RegisterStartupScript(this.GetType(),  "", "toastr.error('There was an error', 'Error')", true);
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