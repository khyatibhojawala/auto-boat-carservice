using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Contents.RemoveAll();
        }
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        try
        {
            model m = new model();
            Int32 l = 0;
            m.open();
            l = m.login("logintbl", username.Text, password.Text);
            if (l == 0)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Session["admin"] = l;
                Response.Redirect("Dashboard.aspx");

            }
           
        }
        catch(Exception exception) {
          
        }
    }
}