using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace rpapos_web_webforms
{
    public class DAL
    {
        public static string connectionStringFromSubdomain(string subdomain) {
            string result = "";

            if (subdomain.ToLower().Equals("localhost")) {
                result = ConfigurationManager.ConnectionStrings["POSConnectionString"].ToString();
                return result;
            }
            try
            {

                var connectionString = ConfigurationManager.ConnectionStrings["RPA_iDB"].ToString();

                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand sqlComm = new SqlCommand("PA_Conexion_DB_1", conn);

                    sqlComm.Parameters.AddWithValue("@pSub_Dominio", subdomain);


                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }
                if (ds.Tables.Count > 0) {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        var row = ds.Tables[0].Rows[0];
                        result = "data source=" + row["Servidor"].ToString() + ";initial catalog=" +
                            row["Base_Datos"].ToString() + ";" +
                    "user id=" + row["Login_Usuario"].ToString() + ";password=" +
                   row["Login_Clave"].ToString() + ";Connection Timeout=10000";
                    }
                }
            }
            catch (Exception exception) {
                Console.WriteLine(exception.Message);
            }


            return result;
        }


        public static Image clientLogo(string connectionString, int width)
        {
            Image result = null;

            try
            {
                if (connectionString.Length > 0)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        var sql = string.Format("SELECT Archivo , Tipo FROM tbl_Objeto_Archivo where Objeto_Archivo = 1");

                        var command = new SqlCommand(sql, conn);


                        var dataReader = command.ExecuteReader();


                        if (dataReader.Read())
                        {
                            var tipo = dataReader["Tipo"];
                            byte[] raw = (byte[])dataReader["Archivo"];
                            if (raw != null)
                            {

                                MemoryStream memstr = new MemoryStream(raw);
                                result = Image.FromStream(memstr);
                                
                                    result = DAL.resizeImage(result, width, width);
                              
                            }


                        }


                    }
                }
            }
            catch (Exception exception)
            {


            }

            return result;

        }

        public static string ImagetoBase(Image image)
        {
            var base64String = "";

            if (image != null)
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, ImageFormat.Png);
                    byte[] imageBytes = m.ToArray();
                    base64String = "data:image/png;base64," + Convert.ToBase64String(imageBytes);


                }
            }
            return base64String;
        }

        public static Image resizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);

            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);

            return new_image;
        }

    }


}