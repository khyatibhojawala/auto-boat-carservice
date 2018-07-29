using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class carinquiryview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showInquirydata();
        }
    }
    protected void repeat_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Int32 id = 0;
        switch (e.CommandName)
        {
            case ("delete"):
                id = Convert.ToInt32(e.CommandArgument);
                model m = new model();
                m.open();
                m.delete("depttbl", "deptid=" + id);
                m.close();
                break;
        }
        showInquirydata();
    }

    private void showInquirydata()
    {
        model m = new model();
        m.open();
        DataTable dt = m.show("carinquiry");
        CarRegiRepeater.DataSource = dt;
        CarRegiRepeater.DataBind();
        m.close();
    }
    protected void CarRegiRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton btn = (LinkButton)e.Item.FindControl("btndelete");
        btn.Visible = false;

        model m = new model();
        m.open();
        SqlDataReader dr = m.admin("logintbl", "loginid=" + Session["admin"].ToString() + " and deptname like 'admin'");
        if (dr.HasRows)
        {
            dr.Read();
            btn.Visible = true;
        }
        dr.Close();
        SqlDataReader dr1 = m.admin("logintbl", "loginid=" + Session["admin"].ToString() + " and deptname like 'manager'");
        if (dr1.HasRows)
        {
            dr1.Read();
            btn.Visible = true;
        } dr1.Close();
        m.close(); 
    }
}