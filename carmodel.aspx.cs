using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class carmodel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //loginid.Text = Session["admin"].ToString();
            //loginid.Text = 1.ToString();
            //tdate.Text = DateTime.Today.ToString("dd-MM-yyyy");
            showCarModel();
            getCarCompanyDrop();
            btnupdatecarmodel.Visible = false;

        }
    }

    public void showCarModel()
    {
        model m = new model();
        m.open();
        DataTable dt = m.multipleTableQuery("carcompany.carcompanyname,cartype.cartype,carmodel.*", "(carcompany INNER JOIN cartype ON carcompany.carcompanyid=cartype.carcompanyid)INNER JOIN carmodel ON cartype.cartypeid=carmodel.cartypeid", "carmodel.isdelete='1'");
        carmodelRepeater.DataSource = dt;
        carmodelRepeater.DataBind();
        m.close();
    }

    private void cleartextbox()
    {
        carmodel1.Text = "";
    }

    public void getCarCompanyDrop()
    {
        model m = new model();

        m.open();
        DataSet ds = new DataSet();
        ds = m.showdrop("*", "carcompany", "");
        carcompany.DataSource = ds.Tables[0];
        carcompany.DataTextField = ds.Tables[0].Columns["carcompanyname"].ColumnName.ToString();
        carcompany.DataValueField = ds.Tables[0].Columns["carcompanyid"].ColumnName.ToString();
        carcompany.DataBind();
        m.close();

        carcompany.Items.Insert(0, new ListItem("Select CarCompany", "0"));
    }

    public void getCarTypeDrop()
    {
        model m = new model();

        m.open();
        DataSet ds = new DataSet();
        ds = m.showdrop("*", "cartype", "and carcompanyid="+carcompany.SelectedValue);
        cartype.DataSource = ds.Tables[0];
        cartype.DataTextField = ds.Tables[0].Columns["cartype"].ColumnName.ToString();
        cartype.DataValueField = ds.Tables[0].Columns["cartypeid"].ColumnName.ToString();
        cartype.DataBind();
        m.close();

        cartype.Items.Insert(0, new ListItem("Select CarType", "0"));
    }
    protected void carcompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        getCarTypeDrop();
    }

    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        m.insert("carmodel", "carmodelname,cartypeid,isdelete", "'" + carmodel1.Text + "'," + cartype.SelectedValue + ",1");
        m.close();
        cleartextbox();
        showCarModel();
    }

    public void editcarModel(Int32 id)
    {
        DataTable dt = new DataTable();
        model m = new model();
        m.open();
        dt = m.multipleTableQuery("cartype.carcompanyid,cartype.cartypeid,carmodel.*", "carmodel INNER JOIN cartype ON carmodel.cartypeid=cartype.cartypeid", "carmodel.isdelete='1' and carmodel.carmodelid=" + id);
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                carcompany.SelectedValue = dr["carcompanyid"].ToString();
                getCarTypeDrop();
                cartype.SelectedValue = dr["cartypeid"].ToString();
                carmodel1.Text = dr["carmodelname"].ToString();
            }
        }
        m.close();
        btnsubmitcarmodel.Visible = false;
        btnupdatecarmodel.Visible = true;
    }

    protected void repeat_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Int32 id = 0;
        switch (e.CommandName)
        {
            case ("edit"):
                Label1.Text = Convert.ToString(e.CommandArgument);
                id = Convert.ToInt32(e.CommandArgument);
                editcarModel(id);
                Label1.Text = id.ToString();
                break;
            case ("delete"):
                id = Convert.ToInt32(e.CommandArgument);
                model m = new model();
                m.open();
                m.delete("carmodel", "carmodelid=" + id);
                m.close();
                break;
        }
        showCarModel();
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        m.update("carmodel", "cartypeid='" + cartype.SelectedValue + "',carmodelname='" + carmodel1.Text + "'", "carmodelid=" + Label1.Text);
        m.close();
        cleartextbox();
        showCarModel();


        btnsubmitcarmodel.Visible = true;
        btnupdatecarmodel.Visible = false;
    }
}