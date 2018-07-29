using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class bill : System.Web.UI.Page
{
    int Service_subtotal = 0;
    int Parts_subtotal = 0;
    static int subtotal = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String contactno=Request.QueryString["contact"];
            carownercontactno.Text = contactno;
            
            if (contactno != null)
            {
                ServiceOrderMaintainDetail();
                PartsDetails();
                
            }
            DeatilsOfCarOwner();
            extraDeatilsOfPurchase();
            subtotal = Service_subtotal + Parts_subtotal;
            stotal.Text = subtotal.ToString();
            discount.Text = "0";
            disamt.Text = subtotal.ToString();
            Label4.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            //isstartservice_gets_off();
        } 
    }
    public void DeatilsOfCarOwner()
    {
        model m = new model();
        m.open();
        DataTable dt1 = m.edit("carregi", "contact='" + carownercontactno.Text + "'");
        CarOwnerDeatilsRepeater.DataSource = dt1;
        CarOwnerDeatilsRepeater.DataBind();
        m.close();
    }
    public void extraDeatilsOfPurchase()
    {
        model m = new model();
        m.open();
        DataTable extraDetails = m.multipleTableQuery("MAX(purchasemaster.refno) as prno", "((carregi INNER JOIN purchasemaster ON carregi.carid=purchasemaster.carid)INNER JOIN purchaseordermaintain ON purchasemaster.refno=purchaseordermaintain.refno)INNER JOIN partstbl ON purchaseordermaintain.partid=partstbl.partid", "carregi.contact='" + carownercontactno.Text + "' and purchasemaster.ispaymentdone='no' and (carregi.isdelete='1' and purchasemaster.isdelete='1' and purchaseordermaintain.isdelete='1' and partstbl.isdelete='1')");
        ordernorepeterbind.DataSource = extraDetails;
        ordernorepeterbind.DataBind();
        m.close();
    }
    public void ServiceOrderMaintainDetail()
    {
        model m = new model();
        m.open();
        DataTable dt = m.multipleTableQuery("carregi.carid,ServiceOrderMaster.refno,servicecategory.servicename,ServiceOrderMaintain.*", "((carregi INNER JOIN ServiceOrderMaster ON carregi.carid=ServiceOrderMaster.carid)INNER JOIN ServiceOrderMaintain ON ServiceOrderMaster.refno=ServiceOrderMaintain.refno)INNER JOIN servicecategory ON ServiceOrderMaintain.servicecategoryid=servicecategory.servicecategoryid", "carregi.contact='" + carownercontactno.Text + "' and ServiceOrderMaster.isservicestart='yes' and (carregi.isdelete=1 and ServiceOrderMaster.isdelete=1 and ServiceOrderMaintain.isdelete=1 and servicecategory.isdelete=1)");
        billdetails.DataSource = dt;
        billdetails.DataBind();
        foreach (DataRow d in dt.Rows)
        {
            Service_subtotal += Convert.ToInt32(d["netamt"]);
        }

        DataTable dtsrno = m.multipleTableQuery("MAX(ServiceOrderMaster.refno) as srno", "((carregi INNER JOIN ServiceOrderMaster ON carregi.carid=ServiceOrderMaster.carid)INNER JOIN ServiceOrderMaintain ON ServiceOrderMaster.refno=ServiceOrderMaintain.refno)INNER JOIN servicecategory ON ServiceOrderMaintain.servicecategoryid=servicecategory.servicecategoryid", "carregi.contact='" + carownercontactno.Text + "' and ServiceOrderMaster.isservicestart='yes' and (carregi.isdelete=1 and ServiceOrderMaster.isdelete=1 and ServiceOrderMaintain.isdelete=1 and servicecategory.isdelete=1)");
        serviceorderno.DataSource = dtsrno;
        serviceorderno.DataBind();
        
        m.close();
    }
    public void PartsDetails()
    {
        model m = new model();
        m.open();
        DataTable dt = m.multipleTableQuery("carregi.carid,purchasemaster.refno,partstbl.partname,purchaseordermaintain.*", "((carregi INNER JOIN purchasemaster ON carregi.carid=purchasemaster.carid)INNER JOIN purchaseordermaintain ON purchasemaster.refno=purchaseordermaintain.refno)INNER JOIN partstbl ON purchaseordermaintain.partid=partstbl.partid", "carregi.contact='" + carownercontactno.Text + "' and purchasemaster.ispaymentdone='no' and (carregi.isdelete=1 and purchasemaster.isdelete=1 and purchaseordermaintain.isdelete=1 and partstbl.isdelete=1)");
        partsrepeater.DataSource = dt;
        partsrepeater.DataBind();
        foreach(DataRow d in dt.Rows)
        {
            Parts_subtotal += Convert.ToInt32(d["totalqtyamt"]);
        }

        m.close();
    }
    protected void carownercontactno_TextChanged(object sender, EventArgs e)
    {
        DeatilsOfCarOwner();
        extraDeatilsOfPurchase();
        ServiceOrderMaintainDetail();
        PartsDetails();
        subtotal = Service_subtotal + Parts_subtotal;
        stotal.Text = subtotal.ToString();
        discount.Text = "0";
        disamt.Text = subtotal.ToString();
    }
   
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        int dis = Convert.ToInt32(discount.Text);
        int dis_price = (subtotal * dis) / 100;
        disamt.Text = (subtotal - dis_price).ToString();
    }
    protected void editbill_Click(object sender, EventArgs e)
    {
        Response.Redirect("searchData.aspx?contact="+carownercontactno.Text);
    }

    public void paypal() { 
         //Here store that person name who are going to make transaction
        model m = new model();
        m.open();
        SqlDataReader dr = m.admin("logintbl", "loginid=" + Session["admin"].ToString());
        string email = "";
        string uname = "";
        string dept = "";
        if (dr.HasRows)
        {
            if (dr.Read())
            {
                email = dr["email"].ToString();
                 uname = dr["username"].ToString();
                dept = dr["deptname"].ToString();
            }
        }
            // make query string to store logged in user information in sql server table         
          
          
            //Pay pal process Refer for what are the variable are need to send http://www.paypalobjects.com/IntegrationCenter/ic_std-variable-ref-buy-now.html

            string redirectUrl = "";

            //Mention URL to redirect content to paypal site

            redirectUrl += "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" + ConfigurationManager.AppSettings["paypalemail"].ToString();
            //First name I assign static based on login details assign this value
            redirectUrl += "&first_name="+uname;
            //Product Name
            redirectUrl += "&item_name=service and parts" ;
            //Product Amount
            redirectUrl += "&amount=" + disamt.Text;
            //Business contact paypal EmailID
            redirectUrl += "&business=" + email;
            //Shipping charges if any, or available or using shopping cart system
            redirectUrl += "&shipping=0";
            //Handling charges if any, or available or using shopping cart system
            redirectUrl += "&handling=0";
            //Tax charges if any, or available or using shopping cart system
            redirectUrl += "&tax=0";
            //Quantiy of product, Here statically added quantity 1
            redirectUrl += "&quantity=1";
            //If transactioin has been successfully performed, redirect SuccessURL page- this page will be designed by developer
            redirectUrl += "&return=" + ConfigurationManager.AppSettings["SuccessURL"].ToString();
            //If transactioin has been failed, redirect FailedURL page- this page will be designed by developer
            redirectUrl += "&cancel_return=" + ConfigurationManager.AppSettings["FailedURL"].ToString();
            Response.Redirect(redirectUrl);
            m.close();
        }



    public void isstartservice_gets_off_SOM()
    {
        int smid = 0;
        model m = new model();
        m.open();
        DataTable dt = m.multipleTableQuery("ServiceOrderMaster.serviceordermasterid", "((carregi INNER JOIN ServiceOrderMaster ON carregi.carid=ServiceOrderMaster.carid)INNER JOIN ServiceOrderMaintain ON ServiceOrderMaster.refno=ServiceOrderMaintain.refno)INNER JOIN servicecategory ON ServiceOrderMaintain.servicecategoryid=servicecategory.servicecategoryid", "carregi.contact='" + carownercontactno.Text + "' and ServiceOrderMaster.isservicestart='yes' and (carregi.isdelete=1 and ServiceOrderMaster.isdelete=1 and ServiceOrderMaintain.isdelete=1 and servicecategory.isdelete=1)");
        foreach (DataRow d in dt.Rows)
        {
            smid = Convert.ToInt32(d["serviceordermasterid"]);
        }
        m.update("ServiceOrderMaster", "isservicestart='no'", "serviceordermasterid=" + smid);
    }
    public void ispaymentdone_becomes_on_PM()
    {
        int pmid = 0;
        model m = new model();
        m.open();
        DataTable dt = m.multipleTableQuery("purchasemaster.purchasemasterid", "(((carregi INNER JOIN purchasemaster ON carregi.carid=purchasemaster.carid)INNER JOIN purchaseordermaintain ON purchasemaster.refno=purchaseordermaintain.refno)INNER JOIN partstbl ON purchaseordermaintain.partid=partstbl.partid)", "carregi.contact='" + carownercontactno.Text + "' and purchasemaster.ispaymentdone='no' and (carregi.isdelete='1' and purchasemaster.isdelete='1' and purchaseordermaintain.isdelete='1' and partstbl.isdelete='1')");
        foreach (DataRow d in dt.Rows)
        {
            pmid = Convert.ToInt32(d["purchasemasterid"]);
        }
        m.update("purchasemaster", "ispaymentdone='yes'", "purchasemasterid=" + pmid);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        paypal();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        isstartservice_gets_off_SOM();
        ispaymentdone_becomes_on_PM();
        ScriptManager.RegisterStartupScript(Page, GetType(), "dis", "<script> hey();</script>", false);
    }
}