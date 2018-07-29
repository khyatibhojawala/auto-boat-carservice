using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class workerstbl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            model m = new model();
            m.open();
            SqlDataReader dr = m.admin("logintbl", "loginid=" + Session["admin"].ToString() + " and ((deptname like 'manager') or (deptname like 'employee'))");
            if (dr.HasRows)
            {
                Response.Redirect("login.aspx");
            }
            dr.Close();
            //deptnamedrop();
            showsalesmanName();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        m.insert("salesmantbl", "salesmanname,salesdeptname,isdelete", "'" + salesmanname.Text + "','" + dropdeptname.SelectedValue + "',1");
        cleartextbox();
        m.close();
        showsalesmanName();
    }
    private void cleartextbox()
    {
        salesmanname.Text = "";
    }
    protected void CarRegiRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Int32 id = 0;
        switch (e.CommandName)
        {
            case ("delete"):
                id = Convert.ToInt32(e.CommandArgument);
                model m = new model();
                m.open();
                m.delete("salesmantbl", "salesmanid=" + id);
                m.close();
                break;
        }
        showsalesmanName();
    }
    public void showsalesmanName()
    {
        model m = new model();
        m.open();
        DataTable dt = m.multipleTableQuery("salesmantbl.*", "salesmantbl", "salesmantbl.isdelete='1'");
        CarRegiRepeater.DataSource = dt;
        CarRegiRepeater.DataBind();
        m.close();

    }
    //public void deptnamedrop()
    //{
    //    model m = new model();

    //    m.open();
    //    DataSet ds = new DataSet();
    //    ds = m.showdrop("*","depttbl","");
    //    dropdeptname.DataSource = ds.Tables[0];
    //    dropdeptname.DataTextField = ds.Tables[0].Columns["deptname"].ColumnName.ToString();
    //    dropdeptname.DataValueField = ds.Tables[0].Columns["deptid"].ColumnName.ToString();
    //    dropdeptname.DataBind();
    //    m.close();

    //}
}