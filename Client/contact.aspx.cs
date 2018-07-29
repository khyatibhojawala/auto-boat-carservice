using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Client_contact : System.Web.UI.Page
{

    string referencenum = "ref";
    int count = 0;
    static String servicecat;
    string loginidtext,refno;
    static int ordno = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            carno1.Text = "GJ";
            carno2.Text = "05";
            String x = DateTime.Today.ToString("dd-MM-yyyy");
            Convert.ToDateTime(x);
            GetOrdernoandRefno();
            getCarCompanyDrop();
            categorysowBIND();
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        insercarregi();
        insertinquiry();
        ClearTextBox();
    }
    private void ClearTextBox()
    {
        ownername.Text = "";
        address.Text = "";
        email.Text = "";
        contact.Text = "";
        carno3.Text = "";
        carno4.Text = "";
        carcompany.SelectedValue = "0";
        cartype.SelectedValue = "0";
        carmodel.SelectedValue = "0";
        carsubmodel.SelectedValue = "0";
        carinsurance.Checked = false;
        remark.Text = "";
        

        foreach (RepeaterItem i in inqrepeater.Items)
        {
            CheckBox cb = (CheckBox)i.FindControl("servicecategory");
            cb.Checked = false;
        }

    }
    public void GetOrdernoandRefno()
    {
        model m = new model();
        m.open();
        SqlDataReader dr = m.getLastRecord("orderno", "carinquiry", "orderno");
        if (dr.HasRows)
        {
            dr.Read();
            ordno = Convert.ToInt32(dr["orderno"]);
        }
        else
        {
            ordno = 0;
        }
        ordno = Convert.ToInt32(ordno) + 1;

        String todaydate = DateTime.Today.ToString("yyMM");

        todaydate = DateTime.Today.ToString("yyMM");
        refno = "R-" + todaydate + ordno;
       
        m.close();


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

        carcompany.Items.Insert(0, new ListItem("Select Company", "0"));
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

        carmodel.Items.Insert(0, new ListItem("Select model", "0"));
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

        carsubmodel.Items.Insert(0, new ListItem("Select SubModel", "0"));
    }
    public void categorysowBIND()
    {
        model m = new model();
        m.open();
        DataTable da = m.show("servicecategory");
        inqrepeater.DataSource = da;
        inqrepeater.DataBind();

        m.close();

    }
    protected void carcompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        getCarTypeDrop();
        carmodel.SelectedValue = "0";
        carsubmodel.SelectedValue = "0";
    }
    protected void cartype_SelectedIndexChanged(object sender, EventArgs e)
    {

        getCarModelDrop();

        carsubmodel.SelectedValue = "0";
    }
    protected void carmodel_SelectedIndexChanged(object sender, EventArgs e)
    {
        getCarSubModelDrop();
    }
    protected void chkchange(object sender, EventArgs e)
    {
        int counter = 0;

        //to fetch how many data is there in SERVICECATEGORY TABLE and store it in "counter" variable
        model m = new model();
        m.open();
        SqlDataReader dr = m.getLastRecordByCOUNT("servicecategoryid", "servicecategory");
        if (dr.HasRows)
        {
            dr.Read();
            counter = Convert.ToInt32(dr[0].ToString());
        }

        string str = "";
        remark.Text = "";
        foreach (RepeaterItem aItem in inqrepeater.Items)
        {
            CheckBox chkItemId = (CheckBox)aItem.FindControl("servicecategory");
            if (chkItemId.Checked)
            {
                str = "";
                str = chkItemId.Text + " , ";
                remark.Text = remark.Text + str;

                counter++;
            }
            else
            {
                counter--;
            }

        }

        if (counter == 0)
        {
            remark.Text = "";
        }
        else
        {
            String wholestr = remark.Text;
            String substr = wholestr.Substring(0, Convert.ToInt32(wholestr.Length - 2));
            servicecat = substr + " :";
            remark.Text = servicecat;
        }

    }

    protected void contactno_TextChanged(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        SqlDataReader drcontact = m.ValidationEmailMobile("carregi", "contact='" + contact.Text + "'");
        if (drcontact.HasRows)
        {
            drcontact.Read();
            labelcontact.Visible = true;
            labelcontact.Text = "Contact is already Exists";
            labelcontact.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            labelcontact.Text = "";
        }
        drcontact.Close();
        m.close();
    }
    
    public void insercarregi()
    {

        model m = new model();
        m.open();

        string insurance = "false";

        if (carinsurance.Checked)
            insurance = "yes";
        else
            insurance = "no";
        loginidtext = Session["admin"].ToString();

        String carno = carno1.Text + "-" + carno2.Text + " " + carno3.Text + " " + carno4.Text;
       
        m.insert("carregi", "ownername,address,email,contact,carno,carcompanyid,cartypeid,carmodelid,carsubmodelid,carinsurance,engineno,tdate,custid,loginid,isdelete", "'" + ownername.Text + "','" + address.Text + "','" + email.Text + "','" + contact.Text + "','" + carno + "','" + carcompany.SelectedValue + "','" + cartype.SelectedValue + "','" + carmodel.SelectedValue + "','" + carsubmodel.SelectedValue + "','" + insurance + "','"+engineno.Text+"','" + DateTime.Now.ToString("yyyy-MM-dd") + "',0,0,1");
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Your Record is Successfully Inserted .');", true);

        m.close();
    }
    public void insertinquiry()
    {
        model m = new model();
        m.open();
        int cid = 0;
        SqlDataReader dr = m.getLastRecord("carid", "carregi", "carid");
        if (dr.HasRows)
        {
            dr.Read();
            cid = Convert.ToInt32(dr["carid"].ToString());
            dr.Close();
        }
        else
        {
            cid = 0;
        }
        //Inquiry insert
        int counter = 0;
        foreach (RepeaterItem i in inqrepeater.Items)
        {
            CheckBox cb = (CheckBox)i.FindControl("servicecategory");
            if (cb.Checked)
            {
                counter++;
            }

        }

        if (counter != 0)
        {
            m.insert("carinquiry", "carid,orderno,refrenceno,remark,servicecategory,tdate,isonline,isfollowup,isdone,isdelete", "'" + cid + "','" + ordno + "','" + refno + "','" + remark.Text + "','" + servicecat + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','1',0,'0','1'");
        }
        m.close();
    }
    protected void carno3_TextChanged(object sender, EventArgs e)
    {
        if (carno3.Text.Length > 3)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "dis", "<script> $(document).ready(function () { $('#modal-default').modal('show');  }); </script>", false);
            carno3.Text = null;
        }
    }
    protected void carno4_TextChanged(object sender, EventArgs e)
    {
        String carnothreezero;
        if (carno4.Text.Length == 1)
        {
            carnothreezero = "000" + carno4.Text;
            carno4.Text = carnothreezero;
        }
        else if (carno4.Text.Length == 2)
        {
            carnothreezero = "00" + carno4.Text;
            carno4.Text = carnothreezero;
        }
        else if (carno4.Text.Length == 3)
        {
            carnothreezero = "0" + carno4.Text;
            carno4.Text = carnothreezero;
        }
    }
}