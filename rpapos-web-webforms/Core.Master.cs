﻿using rpapos_web_webforms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rpapos_web_webforms
{
   
    public partial class Core : System.Web.UI.MasterPage
    {
        public List<MenuModulo> modulos;
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (Session["ConnectionString"] == null)
            {

                Response.Redirect("/Login");
            }
            else {
                if (Session["Menu"] == null)
                {
                    var moduloRepo = new MenuModuloRepo(Session["ConnectionString"].ToString());
                    modulos = moduloRepo.GetAll(int.Parse(Session["Usuario"].ToString())).ToList();
                    Session["Menu"] = modulos;
                }
                else {
                    modulos = (List<MenuModulo>) Session["Menu"];
                }

                Console.WriteLine();

            }

        }







        }
}