using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class cartype : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //loginid.Text = Session["admin"].ToString();
            //loginid.Text = 1.ToString();
            //tdate.Text = DateTime.Today.ToString("dd-MM-yyyy");
            showCarType();
            getCarCompanyDrop();
            btnupdatecartype.Visible = false;

        }
    }

    public void showCarType()
    {
        model m = new model();
        m.open();
        DataTable dt = m.multipleTableQuery("carcompany.carcompanyname,cartype.*", "carcompany INNER JOIN cartype ON carcompany.carcompanyid=cartype.carcompanyid", "cartype.isdelete='1'");
        cartypeRepeater.DataSource = dt;
        cartypeRepeater.DataBind();
        m.close();
    }

    private void cleartextbox()
    {
        cartype1.Text = "";
    }

    public void getCarCompanyDrop()
    {
        model m = new model();

        m.open();
        DataSet ds = new DataSet();
        ds = m.showdrop("*","carcompany","");
        carcompany.DataSource = ds.Tables[0];
        carcompany.DataTextField = ds.Tables[0].Columns["carcompanyname"].ColumnName.ToString();
        carcompany.DataValueField = ds.Tables[0].Columns["carcompanyid"].ColumnName.ToString();
        carcompany.DataBind();
        m.close();

        carcompany.Items.Insert(0, new ListItem("Select CarCompany", "0"));
    }

    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        m.insert("cartype", "cartype,carcompanyid,isdelete", "'" + cartype1.Text + "',"+ carcompany.SelectedValue +",1");
        m.close();
        cleartextbox();
        showCarType();
    }

    public void editcarType(Int32 id)
    {
        DataTable dt = new DataTable();
        model m = new model();
        m.open();
        dt = m.edit("cartype", "cartypeid=" + id);
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                cartype1.Text = dr["cartype"].ToString();
                carcompany.SelectedValue = dr["carcompanyid"].ToString();
            }
        }
        m.close();
        btnsubmitcartype.Visible = false;
        btnupdatecartype.Visible = true;
    }

    protected void repeat_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Int32 id = 0;
        switch (e.CommandName)
        {
            case ("edit"):
                Label1.Text = Convert.ToString(e.CommandArgument);
                id = Convert.ToInt32(e.CommandArgument);
                editcarType(id);
                Label1.Text = id.ToString();
                break;
            case ("delete"):
                id = Convert.ToInt32(e.CommandArgument);
                model m = new model();
                m.open();
                m.delete("cartype", "cartypeid=" + id);
                m.close();
                break;
        }
        showCarType();
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        m.update("cartype", "carcompanyid='" + carcompany.SelectedValue + "',cartype='" + cartype1.Text + "'", "cartypeid=" + Label1.Text);
        m.close();
        cleartextbox();
        showCarType();


        btnsubmitcartype.Visible = true;
        btnupdatecartype.Visible = false;
    }
}