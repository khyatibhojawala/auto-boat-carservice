using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class parts : System.Web.UI.Page
{
    String loginidtext;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showParts();
            btnupdate.Visible = false;
            byte[] buffer = new byte[5];
            Random r = new Random();
            r.NextBytes(buffer);
            partcode.Text = BitConverter.ToString(buffer);

            getCarCompanyDrop();
        }
       
    }

    public void showParts()
    {
        model m = new model();
        m.open();
        DataTable dt = m.multipleTableQuery("carcompany.carcompanyname,cartype.cartype,carmodel.carmodelname,carsubmodel.carsubmodelname,partstbl.*", "(((partstbl INNER JOIN carcompany ON partstbl.carcompanyid=carcompany.carcompanyid)INNER JOIN cartype ON partstbl.cartypeid=cartype.cartypeid)INNER JOIN carmodel ON partstbl.carmodelid=carmodel.carmodelid)INNER JOIN carsubmodel ON partstbl.carsubmodelid=carsubmodel.carsubmodelid", "partstbl.isdelete='1'");
        partRepeater.DataSource = dt;
        partRepeater.DataBind();
        m.close();

    }

    protected void btnsubmit_Click1(object sender, EventArgs e)
    {

        model m = new model();
        m.open();
        loginidtext = Session["admin"].ToString();
        m.insert("partstbl", "partname,carcompanyid,cartypeid,carmodelid,carsubmodelid,partprice,sgst,cgst,igst,remark,partcode,loginid,tdate,isdelete", "'" + partname.Text + "','" + carcompany.SelectedValue + "','" + cartype.SelectedValue + "','" + carmodel.SelectedValue + "','" + carsubmodel.SelectedValue + "','" + partprice.Text + "','" + sgst.Text + "','" + cgst.Text + "','" + igst.Text + "','" + remark.Text + "','" + partcode.Text + "','" + loginidtext + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "',1");
        m.close();
        cleartextbox();
        showParts();
    }
    private void cleartextbox()
    {
        partname.Text = "";
        partprice.Text = "";
        sgst.Text = "";
        cgst.Text = "";
        igst.Text = "";
        remark.Text = "";
        byte[] buffer = new byte[5];
        Random r = new Random();
        r.NextBytes(buffer);
        partcode.Text = BitConverter.ToString(buffer);
    }

    public void editParts(Int32 id)
    {
        DataTable dt = new DataTable();
        model m = new model();
        m.open();
        dt = m.edit("partstbl", "partid=" + id);
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                partname.Text = dr["partname"].ToString();
                carcompany.SelectedValue = dr["carcompanyid"].ToString();
                getCarTypeDrop();
                cartype.SelectedValue = dr["cartypeid"].ToString();
                getCarModelDrop();
                carmodel.SelectedValue = dr["carmodelid"].ToString();
                getCarSubModelDrop();
                carsubmodel.SelectedValue = dr["carsubmodelid"].ToString();
                partprice.Text = dr["partprice"].ToString();
                sgst.Text = dr["sgst"].ToString();
                cgst.Text = dr["cgst"].ToString();
                igst.Text = dr["igst"].ToString();
                remark.Text = dr["remark"].ToString();
                partcode.Text = dr["partcode"].ToString();

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
                editParts(id);
                Label1.Text = id.ToString();
                break;
            case ("delete"):
                id = Convert.ToInt32(e.CommandArgument);
                model m = new model();
                m.open();
                m.delete("partstbl", "partid=" + id);
                Label1.Text = m.delete("carregi", "carid=" + id);
                m.close();
                break;
        }
        showParts();
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {

        model m = new model();
        m.open();
        m.update("partstbl", "partname='" + partname.Text + "',carcompanyid='" + carcompany.SelectedValue + "',cartypeid='" + cartype.SelectedValue + "',carmodelid='" + carmodel.SelectedValue + "',carsubmodelid='" + carsubmodel.SelectedValue + "',partprice='" + partprice.Text + "',sgst='" + sgst.Text + "',cgst='" + cgst.Text + "',igst='" + igst.Text + "',remark='" + remark.Text + "',partcode='" + partcode.Text + "',loginid='" + loginidtext + "',tdate='" + DateTime.Now.ToString("yyyy-MM-dd") + "' ", "partid=" + Label1.Text);
        m.close();
        cleartextbox();
        showParts();
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

        carcompany.Items.Insert(0, new ListItem("Select carcompany", "0"));
    }
    protected void carcompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        getCarTypeDrop();
        carmodel.SelectedValue = "0";
        carsubmodel.SelectedValue = "0";
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

        cartype.Items.Insert(0, new ListItem("Select type", "0"));
    }
    protected void cartype_SelectedIndexChanged(object sender, EventArgs e)
    {
        getCarModelDrop();
        carsubmodel.SelectedValue = "0";
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

        carmodel.Items.Insert(0, new ListItem("Select carmodel", "0"));
    }
    protected void carmodel_SelectedIndexChanged(object sender, EventArgs e)
    {
        getCarSubModelDrop();
    }

    public void getCarSubModelDrop()
    {
        model m = new model();

        m.open();
        DataSet ds = new DataSet();
        ds = m.showdrop("*", "carsubmodel", " and carmodelid=" + carmodel.SelectedValue);
        carsubmodel.DataSource = ds.Tables[0];
        carsubmodel.DataTextField = ds.Tables[0].Columns["carsubmodelname"].ColumnName.ToString();
        carsubmodel.DataValueField = ds.Tables[0].Columns["carsubmodelid"].ColumnName.ToString();
        carsubmodel.DataBind();
        m.close();

        carsubmodel.Items.Insert(0, new ListItem("Select carsubmodel", "0"));
    }
    protected void cgst_TextChanged(object sender, EventArgs e)
    {
        int sgst_amt = Convert.ToInt32(sgst.Text);
        int cgst_amt = Convert.ToInt32(cgst.Text);

        igst.Text=(sgst_amt+cgst_amt).ToString();
    }
    protected void igst_TextChanged(object sender, EventArgs e)
    {
        int igst_amt=Convert.ToInt32(igst.Text);
        cgst.Text = (igst_amt / 2).ToString();
        sgst.Text = (igst_amt / 2).ToString();
    }
    protected void partRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton btn = (LinkButton)e.Item.FindControl("btndelete");
        btn.Visible = false;

        model m = new model();
        m.open();
        SqlDataReader dr = m.admin("logintbl", "loginid=" + Session["admin"].ToString() + " and deptname like 'ADMIN'");
        if (dr.HasRows)
        {
            dr.Read();
            btn.Visible = true;
        } dr.Close();

        m.close(); 
    }
}