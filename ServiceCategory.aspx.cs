using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ServiceCategory : System.Web.UI.Page
{
    String loginidtext;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            
            showServicecategory();
            btnupdate.Visible = false;
        }
    }

    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        model m = new model();
        m.open();
        loginidtext = Session["admin"].ToString();
        m.insert("servicecategory", "servicename,tdate,loginid,price,sgst,cgst,igst,isdelete", "'" + servicename.Text + "','" + DateTime.Now.ToString(@"yyyy-MM-dd") + "','" + loginidtext + "','" + price.Text + "','" + sgst.Text + "','" + cgst.Text + "','" + igst.Text + "',1");
        m.close();
        cleartextbox();
        showServicecategory();
    }
   private void cleartextbox(){
       servicename.Text = "";
       price.Text = "";
       sgst.Text = "";
       cgst.Text = "";
       igst.Text = "";

   }
   public void editServiceCategory(Int32 id)
   {
       DataTable dt = new DataTable();
       model m = new model();
       m.open();
       dt = m.edit("servicecategory", "servicecategoryid=" + id);
       if (dt != null)
       {
           foreach (DataRow dr in dt.Rows)
           {
               servicename.Text = dr["servicename"].ToString();
               price.Text = dr["price"].ToString();
               sgst.Text = dr["sgst"].ToString();
               cgst.Text = dr["cgst"].ToString();
               igst.Text = dr["igst"].ToString();
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
               editServiceCategory(id);
               Label1.Text = id.ToString();
               break;
           case ("delete"):
               id = Convert.ToInt32(e.CommandArgument);
               model m = new model();
               m.open();
               m.delete("servicecategory", "servicecategoryid=" + id);
               //Label2.Text = m.delete("carregi", "carid=" + id);
               m.close();
               break;
       }
       showServicecategory();

   }
   public void showServicecategory()
   {
       model m = new model();
       m.open();
       DataTable dt = m.show("servicecategory");
       servicecategoryRepeater.DataSource = dt;
       servicecategoryRepeater.DataBind();
       m.close();

   }
   protected void btnupdate_Click(object sender, EventArgs e)
   {
       model m = new model();
       m.open();
       m.update("servicecategory","servicename='"+servicename.Text+"',price='"+price.Text+"',sgst='"+sgst.Text+"',cgst='"+cgst.Text+"',igst='"+igst.Text+"' ","servicecategoryid="+Label1.Text);
       m.close();
       cleartextbox();
       showServicecategory();   
   }

   protected void cgst_TextChanged(object sender, EventArgs e)
   {
       int sgst_amt = Convert.ToInt32(sgst.Text);
       int cgst_amt = Convert.ToInt32(cgst.Text);
       igst.Text = (sgst_amt + cgst_amt).ToString();
   }
   protected void igst_TextChanged(object sender, EventArgs e)
   {
       int igst_amt = Convert.ToInt32(igst.Text);
       cgst.Text = (igst_amt / 2).ToString();
       sgst.Text = (igst_amt / 2).ToString();
   }
   protected void servicecategoryRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
   {
       LinkButton btn = (LinkButton)e.Item.FindControl("btndelete");
       btn.Visible = false;

       model m = new model();
       m.open();
       SqlDataReader dr = m.admin("logintbl", "loginid=" + Session["admin"].ToString() + " and deptname like 'admin'");
       if (dr.HasRows)
       {
           dr.Read();
           btn.Visible = true;
       } dr.Close();

       m.close(); 
   }
}