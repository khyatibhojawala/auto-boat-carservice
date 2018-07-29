using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            carregicount();
            serviceOrderMasterCount();
            purchaseCount();
            seenpanel.Visible = false;
            unseenpanel.Visible = true;
            duedateinquirypanel.Visible = false;
            inquiryUnseen();
           
        }
    }
    private void carregicount()
    {
        model m = new model();
        m.open();
        SqlDataReader dr = m.multipleTableQueryDATAROW("COUNT(carid) as carcount", "carregi", "carregi.isdelete=1");
        if (dr.HasRows)
        {
            dr.Read();
            Label1.Text = dr["carcount"].ToString();
        }
        dr.Close();
        m.close();
    }
    private void serviceOrderMasterCount()
    {
        model m = new model();
        m.open();
        SqlDataReader dr = m.multipleTableQueryDATAROW("COUNT(serviceordermasterid) as serviceOrderMastercount ", "ServiceOrderMaster", "ServiceOrderMaster.isdelete=1");
        if (dr.HasRows)
        {
            dr.Read();
            Label3.Text = dr["serviceOrderMastercount"].ToString();
        }
        dr.Close();
        m.close();
    }
    private void purchaseCount()
    {
        model m = new model();
        m.open();
        SqlDataReader dr = m.multipleTableQueryDATAROW("COUNT(purchasemasterid) as pid", "purchasemaster", " purchasemaster.isdelete=1");
        if (dr.HasRows)
        {
            dr.Read();
            Label2.Text = dr["pid"].ToString();
        }
        dr.Close();
        m.close();
    }
    public void inquiryUnseen()
    {
        model m = new model();
        m.open();
        DataTable dt = m.multipleTableQuery("carinquiry.*,carregi.contact", "(carinquiry INNER JOIN carregi ON carinquiry.carid=carregi.carid)", "carinquiry.isdone='0' and carinquiry.isdelete='1' and carregi.isdelete='1'");
        inquiryUnseenRepeater.DataSource = dt;
        inquiryUnseenRepeater.DataBind();
        m.close();
    }
    public void inquirySeen()
    {
        model m = new model();
        m.open();
        DataTable dt = m.multipleTableQuery("carinquiry.*,carregi.contact", "(carinquiry INNER JOIN carregi ON carinquiry.carid=carregi.carid)", "carinquiry.isdone='1' and carinquiry.isdelete='1' and carregi.isdelete='1'");
        seenRepeater.DataSource = dt;
        seenRepeater.DataBind();
        m.close();
    }
    protected void btnunseen_Click(object sender, EventArgs e)
    {
        seenpanel.Visible = false;
        duedateinquirypanel.Visible = false;
        unseenpanel.Visible = true;
        inquiryUnseen();
    }
    protected void btnseen_Click(object sender, EventArgs e)
    {
        unseenpanel.Visible = false;
        duedateinquirypanel.Visible = false;
        seenpanel.Visible = true;
        inquirySeen();
    }


    protected void chkchange(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        foreach (RepeaterItem i in inquiryUnseenRepeater.Items)
        {
            CheckBox cb = (CheckBox)i.FindControl("isseencheckedbox");
            if (cb.Checked)
            {
                //SqlDataReader dt = m.multipleTableQueryDATAROW("oredrno", "carinquiry");
                m.update("carinquiry", "isdone='1'", "orderno='" + cb.Text + "'");
            }

        }
        inquiryUnseen();

    }
    public void duedateinquiry()
    {
        DateTime todaydate=Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

        model m = new model();
        m.open();

        SqlDataReader sdr = m.multipleTableQueryDATAROW("carregi.*,ServiceOrderMaster.*", "ServiceOrderMaster INNER JOIN carregi ON ServiceOrderMaster.carid=carregi.carid", "endservicedate<'" + todaydate + "' and isservicestart='yes' and (ServiceOrderMaster.isdelete='1' and carregi.isdelete='1')");
        dueInquiry.DataSource = sdr;
          dueInquiry.DataBind();
        sdr.Close();

        m.close();
        //model m = new model();
        //m.open();
       // String dbdate = "0",tdbdate="0";
        //String todaydate = DateTime.Now.ToString("yyyy-MM-dd");
        //SqlDataReader dr = m.multipleTableQueryDATAROW("carinquiry.tdate as todate", "carinquiry", "isdone='0'");
        //DateTime d = Convert.ToDateTime(todaydate), d2 = Convert.ToDateTime(todaydate);
        //String dd="", dd2="";
        //int result=0;
        //if (dr.HasRows)
        //{
        //    dr.Read();
        //    dbdate = dr["todate"].ToString();
        //    tdbdate = dbdate.Substring(0,10);
        //    int intmonth = Convert.ToDateTime(tdbdate).Month;
        //    String newtdbdate1 = tdbdate.Substring(0, 3);
        //    String newtdbdate2 = tdbdate.Substring(6);
        //    tdbdate = String.Concat(String.Concat(newtdbdate1, String.Concat(0,intmonth)), newtdbdate2);
        //    d = Convert.ToDateTime(tdbdate);
        //    d2 = Convert.ToDateTime(todaydate);
        //    result = DateTime.Compare(d, d2);
        //    dd = d.ToString().Substring(0, 10);
        //    dd2 = d2.ToString().Substring(0, 10);
        //    dr.Close();
        //}
        //int intmonth = Convert.ToDateTime(todaydate).Month;
        //String newtdbdate1 = todaydate.Substring(0, 3);
        //String newtdbdate2 = todaydate.Substring(6);
        //todaydate = String.Concat(String.Concat(newtdbdate1, String.Concat(0, intmonth)), newtdbdate2);

           // DataTable dt = m.multipleTableQuery("carinquiry.carid,carinquiry.isdone", "carinquiry", "" + todaydate + ">tdate and isdone='0'");
        //DataTable dt = m.multipleTableQuery("carinquiry.carid,carinquiry.isdone", "carinquiry", "DateTime.Compare(" +Convert.ToDateTime(todaydate.ToString().Substring(0,10)) + ",Convert.ToDateTime(carinquiry.tdate))<0 and isdone='0'");
        //    dueInquiry.DataSource = dt;
          //  dueInquiry.DataBind();
        
       
        
       // m.close();
    }

    protected void btnduedateinquiry_Click(object sender, EventArgs e)
    {
        unseenpanel.Visible = false;
        seenpanel.Visible = false;
        duedateinquirypanel.Visible = true;
        duedateinquiry();
    }
}