using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e) {
        string x;
        if (Session["perfil"] != null){
            x = Session["perfil"].ToString();
        }
        else {
            x="";
        }
        if (x != "MAS;")     {
            Response.Redirect("Login.aspx");
        }

    }
}