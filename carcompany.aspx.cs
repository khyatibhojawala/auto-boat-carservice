using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class carcompany : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //loginid.Text = Session["admin"].ToString();
            //loginid.Text = 1.ToString();
            //tdate.Text = DateTime.Today.ToString("dd-MM-yyyy");
            showCarcompany();
            btnupdatecarcompany.Visible = false;

        }
    }

    public void showCarcompany()
    {
        model m = new model();
        m.open();
        DataTable dt = m.show("carcompany");
        carcompanyRepeater.DataSource = dt;
        carcompanyRepeater.DataBind();
        m.close();

    }

    private void cleartextbox()
    {
        carcompanyname.Text = "";
    }

    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        m.insert("carcompany", "carcompanyname,isdelete", "'" + carcompanyname.Text + "',1");
        m.close();
        cleartextbox();
        showCarcompany();
    }

    public void editcarCompany(Int32 id)
    {
        DataTable dt = new DataTable();
        model m = new model();
        m.open();
        dt = m.edit("carcompany", "carcompanyid=" + id);
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                carcompanyname.Text = dr["carcompanyname"].ToString();
            }
        }
        m.close();
        btnsubmitcarcompany.Visible = false;
        btnupdatecarcompany.Visible = true;
    }

    protected void repeat_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Int32 id = 0;
        switch (e.CommandName)
        {
            case ("edit"):
                Label1.Text = Convert.ToString(e.CommandArgument);
                id = Convert.ToInt32(e.CommandArgument);
                editcarCompany(id);
                Label1.Text = id.ToString();
                break;
            case ("delete"):
                id = Convert.ToInt32(e.CommandArgument);
                model m = new model();
                m.open();
                m.delete("carcompany", "carcompanyid=" + id);
                m.close();
                break;
        }
        showCarcompany();
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        m.update("carcompany", "carcompanyname='" + carcompanyname.Text + "'", "carcompanyid=" + Label1.Text);
        m.close();
        cleartextbox();
        showCarcompany();
        btnsubmitcarcompany.Visible = true;
        btnupdatecarcompany.Visible = false;
    }
}