using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class dept : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        SqlDataReader dr = m.admin("logintbl", "loginid=" + Session["admin"].ToString() + " and ((deptname = 'MANAGER') or (deptname = 'SALESMAN') or (deptname = 'MARKETING'))");
        if (dr.HasRows)
        {
            Response.Redirect("login.aspx");
        }
        showDept();
        btnupdate.Visible = false;
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        m.insert("depttbl","deptname,isdelete","'"+deptname.Text.ToUpper()+"',1");
        cleartextbox();
        showDept();
        m.close();

    }
    private void cleartextbox()
    {
        deptname.Text = "";
    }
    public void showDept()
    {
        model m = new model();
        m.open();
        DataTable dt = m.show("depttbl");
        CarRegiRepeater.DataSource = dt;
        CarRegiRepeater.DataBind();
        m.close();

    }
    public void editdept(Int32 id)
    {
        DataTable dt = new DataTable();
        model m = new model();
        m.open();
        dt = m.edit("depttbl", "deptid=" + id);
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                deptname.Text = dr["deptname"].ToString();
                
            }
        }
        m.close();
        btnsubmit.Visible = false;
        btnupdate.Visible = true;
    }
    protected void repeat_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Int32 id = 0;
        switch (e.CommandName)
        {
            case ("edit"):
                Label1.Text = Convert.ToString(e.CommandArgument);
                id = Convert.ToInt32(e.CommandArgument);
                editdept(id);
                Label1.Text = id.ToString();
                break;
            case ("delete"):
                id = Convert.ToInt32(e.CommandArgument);
                model m = new model();
                m.open();
                m.delete("depttbl", "deptid=" + id);
                m.close();
                break;

        }
        showDept();
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        model m = new model();
        m.open();

        m.update("depttbl","deptname='"+deptname.Text+"'","deptid="+Label1.Text);

        m.close();
        cleartextbox();
        showDept();
    }
}