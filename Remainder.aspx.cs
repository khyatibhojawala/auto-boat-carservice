using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Remainder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            seenpanel.Visible = false;
            unseenpanel.Visible = true;
            inquiryUnseen();
        }
    }
    public void inquiryUnseen()
    {
        model m = new model();
        m.open();
        DataTable dt = m.multipleTableQuery("carinquiry.*,carregi.contact", "(carinquiry INNER JOIN carregi ON carinquiry.carid=carregi.carid)", "carinquiry.isdone='0' and carinquiry.isdelete='1'");
        inquiryUnseenRepeater.DataSource = dt;
        inquiryUnseenRepeater.DataBind();
        m.close();
    }
    public void inquirySeen()
    {
        model m = new model();
        m.open();
        DataTable dt = m.multipleTableQuery("carinquiry.*,carregi.contact", "(carinquiry INNER JOIN carregi ON carinquiry.carid=carregi.carid)", "carinquiry.isdone='1' and carinquiry.isdelete='1'");
        seenRepeater.DataSource = dt;
        seenRepeater.DataBind();
        m.close();
    }
    protected void btnunseen_Click(object sender, EventArgs e)
    {
        seenpanel.Visible = false;
        unseenpanel.Visible = true;
        inquiryUnseen();
    }
    protected void btnseen_Click(object sender, EventArgs e)
    {
        unseenpanel.Visible = false;
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
                   m.update("carinquiry", "isdone='1'", "orderno='"+cb.Text+"'");
               }

           }
           inquiryUnseen();
                
    }
}