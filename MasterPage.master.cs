using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         
            if (Session["admin"] != null)
            {
                //Label1.Text = (Session["admin"]).ToString();
                model m = new model();
                m.open();
                SqlDataReader dr = m.admin("logintbl", "loginid=" + Session["admin"].ToString());
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        loginusername.Text = dr["email"].ToString();
                        loginname.Text = dr["username"].ToString();
                        deptname.Text = dr["deptname"].ToString();
                    }
                }
            }
            //else if (Session["admin"] != null)
            //{
            //    model m = new model();
            //    DataTable dt = m.edit("care=regi", "loginid=" + Session["admin"].ToString());

      //    m.close();

      //}
            else
            {
                Response.Redirect("login.aspx");
            }
        }

    }

    protected void bntnprofile_Click(object sender, EventArgs e)
    {
        Response.Redirect("editemp.aspx");
    }
    protected void btnlogout_Click1(object sender, EventArgs e)
    {
        Session.Contents.RemoveAll();
        Response.Redirect("login.aspx");
    }
}
