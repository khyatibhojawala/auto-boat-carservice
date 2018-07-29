using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class editemp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageLoadDataFillOfLoger();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        m.update("logintbl", "name='"+name.Text+"',surname='"+surname.Text+"',password='"+password.Text+"',passhint='"+passhint.Text+"'", "loginid='"+Label2.Text+"'");
        ScriptManager.RegisterStartupScript(Page, GetType(), "dis", "<script> $(document).ready(function () { $('#updatedisplay').modal('show');  }); </script>", false);
        PageLoadDataFillOfLoger();
        m.close();
    }
    protected void passhint_TextChanged(object sender, EventArgs e)
    {
        if (password.Text.Length < 5 || passhint.Text.Length < 5)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "dis", "<script> $(document).ready(function () { $('#passlength').modal('show');  }); </script>", false);
            password.Text = null;
            passhint.Text = null;
        }
        else
        {
            String passwordchecked = password.Text.Substring(0, 5);
            String passhintchecked = passhint.Text.Substring(0, 5);
            if (password.Text == passhint.Text || passwordchecked == passhintchecked)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "dis", "<script> $(document).ready(function () { $('#modal-default').modal('show');  }); </script>", false);
                password.Text = null;
                passhint.Text = null;
            }
        }
        
        
    }
    private void cleartextbox()
    { 
        
    }
    public void PageLoadDataFillOfLoger()
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
                    name.Text = dr["name"].ToString();
                    surname.Text = dr["surname"].ToString();
                    username.Text = dr["username"].ToString();
                    email.Text = dr["email"].ToString();
                    contact.Text = dr["contact"].ToString();
                    DOB.Text = dr["DOB"].ToString();
                    dropdeptname.Text = dr["deptname"].ToString();
                    password.Text = dr["password"].ToString();
                    passhint.Text = dr["passhint"].ToString();
                    Label2.Text = dr["loginid"].ToString();

                }
            }
        }
    }
}