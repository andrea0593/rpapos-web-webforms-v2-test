﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rpapos_web_webforms
{
    public partial class Core : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["db"] == null)
            {

                Response.Redirect("Login.aspx");
            }
            else {
                LiteralUserName.Text   = Session["user"].ToString();
            }

        }
    }
}