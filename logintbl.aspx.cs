using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class logintbl : System.Web.UI.Page
{
    String loginidtext;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
           
            deptnamedrop();
            showCarregi();
            btnsubmit.Visible = true;
            btnupdate.Visible = false;
            password.Text = "autoboats123";
            passhint.Text = "auto123";
            
        }
    }
    
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        model m = new model();
        m.open();
        loginidtext = Session["admin"].ToString();
        SqlDataReader dr = m.ValidationEmailMobile("logintbl", "username='" + username.Text + "'");
        if (dr.HasRows)
        {
            dr.Read();
            labelusername.Visible = true;
            labelusername.Text = "Username is already Exists";
            labelusername.ForeColor = System.Drawing.Color.Red;
            dr.Close();
        }
        else if (Label1.Text.Equals("no"))
        {
            dr.Close();
            dropdeptname.Text = dropdeptname.SelectedValue;
            m.insert("logintbl", "name,surname,username,email,contact,deptname,password,passhint,DOB,entrydate,modifydate,isdelete,emploginid", "'" + name.Text + "','" + surname.Text + "','" + username.Text + "','" + email.Text + "','" + contact.Text + "','" + dropdeptname.SelectedItem + "','" + password.Text + "','" + passhint.Text + "','" + DOB.Text + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "',1," + loginidtext);
            cleartextbox();
        }
        showCarregi();
        m.close();
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        m.update("logintbl", "name='" + name.Text + "',surname='" + surname.Text + "',username='" + username.Text + "',contact='" + contact.Text + "',deptname='" + dropdeptname.SelectedItem + "',password='" + password.Text + "',passhint='" + passhint.Text + "',DOB='" + DOB.Text + "',modifydate='" + DateTime.Now.ToString() + "'", "loginid=" + Label2.Text);
        m.close();
        cleartextbox();
        showCarregi();
    }
    public void showCarregi()
    {
        model m = new model();
        m.open();
        DataTable dt = m.show("logintbl");
        LogintblRepeater.DataSource = dt;
        LogintblRepeater.DataBind();
        m.close();

    }
    protected void repeat_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Int32 id = 0;
        switch (e.CommandName)
        {
            case ("edit"):
                Label2.Text = Convert.ToString(e.CommandArgument);
                id = Convert.ToInt32(e.CommandArgument);
                editlogintbl(id);
                Label2.Text = id.ToString();
                break;
            case ("delete"):
                id = Convert.ToInt32(e.CommandArgument);
                model m = new model();
                m.open();
                m.delete("logintbl", "loginid=" + id);
                //Label2.Text = m.delete("carregi", "carid=" + id);
                m.close();
                break;
        }
        showCarregi();
    }
    public void editlogintbl(Int32 id)
    {
        DataTable dt = new DataTable();
        model m = new model();
        m.open();
        dt = m.edit("logintbl", "loginid=" + id);
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                name.Text = dr["name"].ToString();
                surname.Text = dr["surname"].ToString();
                username.Text = dr["username"].ToString();
                email.Text = dr["email"].ToString();
                contact.Text = dr["contact"].ToString();
                //dropdeptname.Text = dr["deptname"].ToString();
                password.Text = dr["password"].ToString();
                passhint.Text = dr["passhint"].ToString();
                DOB.Text = dr["DOB"].ToString();
                String drop = dr["deptname"].ToString();
                dropdeptname.ClearSelection();
                dropdeptname.Items.FindByText(drop).Selected = true;

            }
        }
        m.close();
        btnsubmit.Visible = false;
        btnupdate.Visible = true;
    }
    private void cleartextbox()
    {
        name.Text = "";
        surname.Text = "";
        username.Text = "";
        email.Text = "";
        contact.Text = "";
        //dropdeptname.Text = "";
        DOB.Text = "";
        labelusername.Text = "";
        dropdeptname.SelectedValue = 0.ToString();
        Label1.Text = "no";
    }

    public void deptnamedrop()
    {
        model m = new model();

        m.open();
        DataSet ds = new DataSet();
        ds = m.showdrop("*", "depttbl", "");
        dropdeptname.DataSource = ds.Tables[0];
        dropdeptname.DataTextField = ds.Tables[0].Columns["deptname"].ColumnName.ToString();
        dropdeptname.DataValueField = ds.Tables[0].Columns["deptid"].ColumnName.ToString();
        dropdeptname.DataBind();
        m.close();

        dropdeptname.Items.Insert(0, new ListItem("Select DeptName", "0"));

    }
    protected void LogintblRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton btn = (LinkButton)e.Item.FindControl("btndelete");
        btn.Visible = false;

        model m = new model();
        m.open();
        SqlDataReader dr = m.admin("logintbl", "loginid=" + Session["admin"].ToString() + " and deptname = 'ADMIN'");
        if (dr.HasRows)
        {
            dr.Read();
            btn.Visible = true;
        }
        dr.Close();
        SqlDataReader dr1 = m.admin("logintbl", "loginid=" + Session["admin"].ToString() + " and deptname = 'MANAGER'");
        if (dr1.HasRows)
        {
            dr1.Read();
            btn.Visible = true;
        } dr1.Close();
        m.close(); 
    }
}