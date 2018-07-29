using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class carsub_odel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //loginid.Text = Session["admin"].ToString();
            //loginid.Text = 1.ToString();
            //tdate.Text = DateTime.Today.ToString("dd-MM-yyyy");
            showCarSubModel();
            getCarCompanyDrop();
            btnupdatecarsubmodel.Visible = false;
        }
    }

    public void showCarSubModel()
    {
        model m = new model();
        m.open();
        DataTable dt = m.multipleTableQuery("carcompany.carcompanyname,cartype.cartype,carmodel.carmodelname,carsubmodel.*", "((carcompany INNER JOIN cartype ON carcompany.carcompanyid=cartype.carcompanyid)INNER JOIN carmodel ON cartype.cartypeid=carmodel.cartypeid)INNER JOIN carsubmodel ON carmodel.carmodelid=carsubmodel.carmodelid", "carsubmodel.isdelete='1'");
        carsubmodelRepeater.DataSource = dt;
        carsubmodelRepeater.DataBind();
        m.close();
    }

    private void cleartextbox()
    {
        carsubmodel.Text = "";
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
        ds = m.showdrop("*", "cartype", "and carcompanyid=" + carcompany.SelectedValue);
        cartype.DataSource = ds.Tables[0];
        cartype.DataTextField = ds.Tables[0].Columns["cartype"].ColumnName.ToString();
        cartype.DataValueField = ds.Tables[0].Columns["cartypeid"].ColumnName.ToString();
        cartype.DataBind();
        m.close();

        cartype.Items.Insert(0, new ListItem("Select CarType", "0"));
    }

    public void getCarModelDrop()
    {
        model m = new model();

        m.open();
        DataSet ds = new DataSet();
        ds = m.showdrop("*", "carmodel", " and cartypeid=" + cartype.SelectedValue);
        carmodel.DataSource = ds.Tables[0];
        carmodel.DataTextField = ds.Tables[0].Columns["carmodelname"].ColumnName.ToString();
        carmodel.DataValueField = ds.Tables[0].Columns["carmodelid"].ColumnName.ToString();
        carmodel.DataBind();
        m.close();

        carmodel.Items.Insert(0, new ListItem("Select CarModel", "0"));
    }
    protected void carcompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        getCarTypeDrop();
        //carmodel.SelectedValue = "0";
    }
    protected void cartype_SelectedIndexChanged(object sender, EventArgs e)
    {
        getCarModelDrop();
    }

    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        m.insert("carsubmodel", "carsubmodelname,carmodelid,isdelete", "'" + carsubmodel.Text + "'," + carmodel.SelectedValue + ",1");
        m.close();
        cleartextbox();
        showCarSubModel();

        carcompany.SelectedValue = 0.ToString();
        cartype.SelectedValue = 0.ToString();
        carmodel.SelectedValue = 0.ToString();
    }

    public void editcarSubModel(Int32 id)
    {
        DataTable dt = new DataTable();
        model m = new model();
        m.open();
        dt = m.multipleTableQuery("cartype.carcompanyid,cartype.cartypeid,carmodel.carmodelid,carsubmodel.carsubmodelname", "(carmodel INNER JOIN cartype ON carmodel.cartypeid=cartype.cartypeid)INNER JOIN carsubmodel ON carmodel.carmodelid=carsubmodel.carmodelid", "carsubmodel.isdelete='1' and carsubmodel.carsubmodelid=" + id);
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                carcompany.SelectedValue = dr["carcompanyid"].ToString();
                getCarTypeDrop();
                cartype.SelectedValue = dr["cartypeid"].ToString();
                getCarModelDrop();
                carmodel.SelectedValue = dr["carmodelid"].ToString();
                carsubmodel.Text = dr["carsubmodelname"].ToString();
            }
        }
        m.close();
        btnsubmitcarsubmodel.Visible = false;
        btnupdatecarsubmodel.Visible = true;
    }

    protected void repeat_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Int32 id = 0;
        switch (e.CommandName)
        {
            case ("edit"):
                Label1.Text = Convert.ToString(e.CommandArgument);
                id = Convert.ToInt32(e.CommandArgument);
                editcarSubModel(id);
                Label1.Text = id.ToString();
                break;
            case ("delete"):
                id = Convert.ToInt32(e.CommandArgument);
                model m = new model();
                m.open();
                m.delete("carsubmodel", "carsubmodelid=" + id);
                m.close();
                showCarSubModel();
                break;
        }
        
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        m.update("carsubmodel", "carmodelid='" + carmodel.SelectedValue + "',carsubmodelname='" + carsubmodel.Text + "'", "carsubmodelid=" + Label1.Text);
        m.close();
        cleartextbox();
        showCarSubModel();

        carcompany.SelectedValue = 0.ToString();
        cartype.SelectedValue = 0.ToString();
        carmodel.SelectedValue = 0.ToString();

        btnsubmitcarsubmodel.Visible = true;
        btnupdatecarsubmodel.Visible = false;
    }
}