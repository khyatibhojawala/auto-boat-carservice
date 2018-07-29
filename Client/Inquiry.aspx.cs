using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Client_Inquiry : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-519SVNQ;Initial Catalog=carservice;Integrated Security=True");
    SqlDataReader dr;
    SqlCommand cmd;
    String servicecat;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from servicecategory", con);
            DataTable dt = new DataTable();

            da.Fill(dt);
            inqrepeater.DataSource = dt;
            inqrepeater.DataBind();

            GetOrdernoandRefno();
        }

        
     
    }

    protected void inquiryrequest_Click(object sender, EventArgs e)
    {
        string st = "hii";

        foreach (RepeaterItem i in inqrepeater.Items)
        {
            CheckBox cb = (CheckBox)i.FindControl("servicecategory");
            if (cb.Checked)
            {
                st = cb.Text.ToString() + ",";
            }
        }
       
    }


    protected void submit_Click(object sender, EventArgs e)
    {
        insertcarregi();

        insertinquiry();

        ClearServiceCheckCoxes();

        GetOrdernoandRefno();
        //Response.Redirect(Request.RawUrl);
    }


    //carregi insert
    public void insertcarregi()
    {
        model m = new model();
        m.open();

        string insurance = "false";

        if (carinsurance.Checked)
            insurance = "yes";
        else
            insurance = "no";

        SqlDataReader dr = m.ValidationEmailMobile("carregi", "ownername='" + ownername.Text + "' OR email='" + email.Text + "' OR contact='" + contact.Text + "'");


        if (dr.HasRows)
        {
            dr.Read();
            dr.Close();
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
            SqlDataReader drcontact = m.ValidationEmailMobile("carregi", "contact='" + contact.Text + "'");
            if (drcontact.HasRows)
            {
                drownername.Close();
                dremail.Close();
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
        }
        else
        {
            dr.Close();
            
            m.insert("carregi", "ownername,address,email,contact,carno,carcompany,carmodel,carinsurance,engineno,tdate,custid,loginid,isdelete", "'" + ownername.Text + "','" + address.Text + "','" + email.Text + "','" + contact.Text + "','" + carno.Text + "','" + carcompany.Text + "','" + carmodel.Text + "','" + insurance + "','" + engineno.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "',0,0,'1'");
            ClearTextBox();
        }

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
            orderno.Text = dr["orderno"].ToString();
            dr.Close();
        }
        else
        {
            orderno.Text = "0";
        }
        int ordno = Convert.ToInt32(orderno.Text) + 1;
        orderno.Text = ordno.ToString();

        //String todaydate = DateTime.Today.ToString("yyMM");

        String todaydate = DateTime.Now.ToString("yyMM");
        String refno = "R-" + todaydate + ordno;
        referenceno.Text = refno;

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
            m.insert("carinquiry", "carid,orderno,refrenceno,remark,servicecategory,isonline,isfollowup,isdone,isdelete", "'" + cid + "','" + orderno.Text + "','" + referenceno.Text + "','" + remark.Text + "','" + lblservicecat.Text + "','1','1','1','1'");
            //ClearServiceCheckCoxes();
        }

        m.close();
    }


    //To clear car registration all fields After submit
    private void ClearTextBox()
    {
        ownername.Text = "";
        address.Text = "";
        email.Text = "";
        contact.Text = "";
        carno.Text = "";
        carcompany.Text = "";
        carmodel.Text = "";
        carinsurance.Checked = false;
        engineno.Text = "";
    }

    //To clear Service Category Checkboxes After submit
    private void ClearServiceCheckCoxes()
    {
        foreach (RepeaterItem i in inqrepeater.Items)
        {
            CheckBox cb = (CheckBox)i.FindControl("servicecategory");
            if (cb.Checked)
            {
                cb.Checked = false;
            }

        }
        remark.Text = "";
    }
    String str;
    protected void chkchange(object sender, EventArgs e)
    {
        string str="";
        remark.Text = "";
        foreach (RepeaterItem aItem in inqrepeater.Items)
        {
            CheckBox chkItemId = (CheckBox)aItem.FindControl("servicecategory");
            if (chkItemId.Checked)
            {
                str="";
                str = chkItemId.Text+" , ";
                remark.Text = remark.Text + str;
            }
            
        }
        String wholestr = remark.Text;
        String substr = wholestr.Substring(0, Convert.ToInt32(wholestr.Length - 2));
        servicecat = substr + " :";
        remark.Text = servicecat;
        lblservicecat.Text = substr;
        
    }
    
}
