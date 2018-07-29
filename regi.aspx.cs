using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class regi : System.Web.UI.Page
{

    string referencenum = "ref";
    int count = 0;
    static String servicecat;
    string loginidtext;
    static int ordno = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            carno1.Text = "GJ";
            carno2.Text = "05";
            String x = DateTime.Today.ToString("dd-MM-yyyy");
            Convert.ToDateTime(x);
            showCarregi();
            btnupdate.Visible = false;
            GetOrdernoandRefno();
            getCarCompanyDrop();
            categorysowBIND();
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        insertcarregi();
        insertinquiry();
        showCarregi();
        ClearTextBox();
        GetOrdernoandRefno();
        
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        model m = new model();
        m.open();

        string updateinsurance = "false";

        if (carinsurance.Checked)
            updateinsurance = "yes";
        else
            updateinsurance = "no";
        String carno = carno1.Text + "-" + carno2.Text + " " + carno3.Text + " " + carno4.Text;
        m.update("carregi", "ownername='" + ownername.Text + "',address='" + address.Text + "',email='" + email.Text + "',contact='" + contact.Text + "',carno='" + carno + "',carcompanyid='" + carcompany.SelectedValue + "',cartypeid='" + cartype.SelectedValue + "',carmodelid='" + carmodel.SelectedValue + "',carsubmodelid='" + carsubmodel.SelectedValue + "',carinsurance='" + updateinsurance + "',engineno='" + engineno.Text + "' ", "carid=" + Label2.Text);

        m.close();
        ClearTextBox();
        showCarregi();

    }

    protected void repeat_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Int32 id = 0;
        switch (e.CommandName)
        {
            case ("edit"):
                Label2.Text = Convert.ToString(e.CommandArgument);
                id = Convert.ToInt32(e.CommandArgument);
                editcarregi(id);
                Label2.Text = id.ToString();
                break;
            case ("delete"):
                id = Convert.ToInt32(e.CommandArgument);
                model m = new model();
                m.open();
                m.delete("carregi", "carid=" + id);
                //Label2.Text = m.delete("carregi", "carid=" + id);
                m.close();
                break;

        }
        showCarregi();
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
    protected void carno3_TextChanged(object sender, EventArgs e)
    {
        if (carno3.Text.Length > 3)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "dis", "<script> $(document).ready(function () { $('#modal-default').modal('show');  }); </script>", false);
            carno3.Text = null;
        }
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
    protected void ownername_TextChanged(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        SqlDataReader drownername = m.ValidationEmailMobile("carregi", "ownername='" + ownername.Text + "'");
        if (drownername.HasRows)
        {

            drownername.Read();
            labelownername.Visible = true;
            labelownername.Text = "Owner is already Exists";
            labelownername.ForeColor = System.Drawing.Color.Red;

        }
        else
        {
            labelownername.Text = "";
        }

        drownername.Close();
        m.close();
    }
    protected void email_TextChanged(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        SqlDataReader dremail = m.ValidationEmailMobile("carregi", "email='" + email.Text + "'");
        if (dremail.HasRows)
        {
            dremail.Read();
            labelemail.Visible = true;
            labelemail.Text = "Email is already Exists";
            labelemail.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            labelemail.Text = "";
        }
        dremail.Close();
        m.close();
    }
    protected void contact_TextChanged(object sender, EventArgs e)
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
    public void categorysowBIND()
    {
        model m = new model();
        m.open();
        DataTable da = m.show("servicecategory");
        inqrepeater.DataSource = da;
        inqrepeater.DataBind();

        m.close();

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
        String refno = "R-" + todaydate + ordno;
        refrenceno.Text = refno;

        m.close();


    }

    public void insertcarregi()
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
        labelemail.Visible = true;
        labelemail.Text = "Email avilable";
        labelemail.ForeColor = System.Drawing.Color.Green;
        m.insert("carregi", "ownername,address,email,contact,carno,carcompanyid,cartypeid,carmodelid,carsubmodelid,carinsurance,engineno,tdate,loginid,isdelete", "'" + ownername.Text + "','" + address.Text + "','" + email.Text + "','" + contact.Text + "','" + carno + "','" + carcompany.SelectedValue + "','" + cartype.SelectedValue + "','" + carmodel.SelectedValue + "','" + carsubmodel.SelectedValue + "','" + insurance + "','" + engineno.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "' ," + loginidtext + ",1");

        ScriptManager.RegisterStartupScript(Page, GetType(), "dis", "<script> $(document).ready(function () { $('#recordinserted').modal('show');  }); </script>", false);
        m.close();

        btnsubmit.Visible = true;
        btnupdate.Visible = false;
    }

    public void insertinquiry()
    {
        model m = new model();
        m.open();
        string isfollowup1 = "0";

        if (isfollowup.Checked)
            isfollowup1 = "1";
        else
            isfollowup1 = "0";
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
            m.insert("carinquiry", "carid,orderno,refrenceno,remark,servicecategory,tdate,isonline,isfollowup,isdone,isdelete", "'" + cid + "','" + ordno + "','" + refrenceno.Text + "','" + remark.Text + "','" + servicecat + "','"+DateTime.Now.ToString("yyyy-MM-dd")+"','0'," + isfollowup1 + ",'0','1'");
            //ClearServiceCheckCoxes();
        }
        //cleartextbox();
        m.close();
    }

    public void editcarregi(Int32 id)
    {
        DataTable dt = new DataTable();
        model m = new model();
        m.open();
        dt = m.edit("carregi", "carid=" + id);
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                ownername.Text = dr["ownername"].ToString();
                address.Text = dr["address"].ToString();
                contact.Text = dr["contact"].ToString();
                email.Text = dr["email"].ToString();
                carcompany.SelectedValue = dr["carcompanyid"].ToString();
                getCarTypeDrop();
                cartype.SelectedValue = dr["cartypeid"].ToString();
                getCarModelDrop();
                carmodel.SelectedValue = dr["carmodelid"].ToString();
                getCarSubModelDrop();
                carsubmodel.SelectedValue = dr["carsubmodelid"].ToString();
                String carno1text = dr["carno"].ToString();
                String cno1text = carno1text.Substring(0, 2);
                carno1.Text = cno1text;

                String carno2text = dr["carno"].ToString();
                String cno2text = carno2text.Substring(3, 2);
                carno2.Text = cno2text;

                String cno3text = "", carno4text, cno4text = "";
                String carno3text = dr["carno"].ToString();
                carno4text = dr["carno"].ToString();

                if (carno3text.Length == 13)
                {
                    cno3text = carno3text.Substring(6, 2);
                    cno4text = carno4text.Substring(8);
                }
                else if (carno3text.Length == 14)
                {
                    cno3text = carno3text.Substring(6, 3);
                    cno4text = carno4text.Substring(9);
                }

                carno3.Text = cno3text;
                carno4.Text = cno4text;

                if (dr["carinsurance"].ToString().Equals("yes"))
                {
                    carinsurance.Checked = true;

                }
                else
                {
                    carinsurance.Checked = false;
                }
                engineno.Text = dr["engineno"].ToString();
            }
        }
        m.close();
        btnsubmit.Visible = false;
        btnupdate.Visible = true;
    }
    
    public void showCarregi()
    {
        model m = new model();
        m.open();
        DataTable dt = m.multipleTableQuery("carcompany.carcompanyname,cartype.cartype,carmodel.carmodelname,carsubmodel.carsubmodelname,carregi.*", "(((carregi INNER JOIN carcompany ON carregi.carcompanyid=carcompany.carcompanyid)INNER JOIN cartype ON carregi.cartypeid=cartype.cartypeid)INNER JOIN carmodel ON carregi.carmodelid=carmodel.carmodelid)INNER JOIN carsubmodel ON carregi.carsubmodelid=carsubmodel.carsubmodelid", "carregi.isdelete='1'");
        CarRegiRepeater.DataSource = dt;
        CarRegiRepeater.DataBind();
        m.close();
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
        engineno.Text = "";
        remark.Text = "";
        isfollowup.Checked = false;

        foreach (RepeaterItem i in inqrepeater.Items)
        {
            CheckBox cb = (CheckBox)i.FindControl("servicecategory");
            cb.Checked = false;
        }

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
    
}
