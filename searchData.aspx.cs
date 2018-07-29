using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class searchData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            contactNoDropDown();
            panelDisplayData.Visible = false;
            partspanel.Visible = false;
            String contactno = Request.QueryString["contact"];
            contactnodrop.Text = contactno;
            if (contactno != null)
            {
                refnoFill();
                panelDisplayData.Visible = true;
                partspanel.Visible = true;
                ServiceOderMasterFillData();
                PurchaseDetails();
            }

        }
    }
    public void contactNoDropDown()
    {
        model m = new model();
        m.open();
        DataSet ds = new DataSet();
        ds = m.showdrop("*", "carregi", "");
        contactnodrop.DataSource = ds.Tables[0];
        contactnodrop.DataTextField = ds.Tables[0].Columns["contact"].ColumnName.ToString();
        contactnodrop.DataValueField = ds.Tables[0].Columns["contact"].ColumnName.ToString();
        contactnodrop.DataBind();
        m.close();

        contactnodrop.Items.Insert(0, new ListItem("Select ContactNo", "0"));
    }
    protected void contactnodrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        refnoFill();
        panelDisplayData.Visible = true;
        partspanel.Visible = true;
        ServiceOderMasterFillData();
        PurchaseDetails();
    }
    public void refnoFill()
    {
        model m = new model();
        m.open();
        DataTable dt = new DataTable();
        dt = m.multipleTableQuery("ServiceOrderMaster.refno", "(ServiceOrderMaster INNER JOIN carregi ON ServiceOrderMaster.carid=carregi.carid)", "carregi.contact='" + contactnodrop.SelectedValue + "' and ServiceOrderMaster.isservicestart='yes'");
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                ordermasterrefno.Text = dr["refno"].ToString();

            }
        }
        DataTable dt1 = new DataTable();
        dt1 = m.multipleTableQuery("purchasemaster.refno", "(purchasemaster INNER JOIN carregi ON purchasemaster.carid=carregi.carid)", "carregi.contact='" + contactnodrop.SelectedValue + "' and purchasemaster.ispaymentdone='no'");
        if (dt1 != null)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                salesrefno.Text = dr["refno"].ToString();

            }
        }
        m.close();
    }
    public void ServiceOderMasterFillData()
    {
        model m = new model();
        m.open();
        DataTable dt = new DataTable();
        dt = m.multipleTableQuery("carregi.engineno,servicecategory.servicename,ServiceOrderMaster.refno,ServiceOrderMaintain.*", "((carregi INNER JOIN ServiceOrderMaster ON carregi.carid=ServiceOrderMaster.carid)INNER JOIN ServiceOrderMaintain ON ServiceOrderMaster.refno=ServiceOrderMaintain.refno)INNER JOIN servicecategory ON ServiceOrderMaintain.servicecategoryid=servicecategory.servicecategoryid", "carregi.contact='" + contactnodrop.SelectedValue + "' and ServiceOrderMaster.refno='" + ordermasterrefno.Text + "' and ServiceOrderMaster.isservicestart='yes' and (carregi.isdelete=1 and ServiceOrderMaster.isdelete=1 and ServiceOrderMaintain.isdelete=1 and servicecategory.isdelete=1)");
        displaydataRepeater.DataSource = dt;
        displaydataRepeater.DataBind();
        m.close();
    }

    public void PurchaseDetails()
    {
        model m = new model();
        m.open();
        DataTable dt = new DataTable();
        dt = m.multipleTableQuery("partstbl.partname,purchaseordermaintain.*", "(((purchasemaster INNER JOIN carregi ON purchasemaster.carid=carregi.carid)INNER JOIN purchaseordermaintain ON purchasemaster.purchasemasterid=purchaseordermaintain.purchasemasterid)INNER JOIN partstbl ON purchaseordermaintain.partid=partstbl.partid)", "carregi.contact='" + contactnodrop.SelectedValue + "' and purchasemaster.refno='" + salesrefno.Text + "' and purchasemaster.ispaymentdone='no' and (carregi.isdelete=1 and purchasemaster.isdelete=1 and purchaseordermaintain.isdelete=1 and partstbl.isdelete=1)");
        partsdisplayRepeater.DataSource = dt;
        partsdisplayRepeater.DataBind();
        m.close();
    }

    protected void displaydataRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Int32 id = 0, somid = 0, updated_price = 0, netamt = 0, totalnumofservice = 0, totalamount = 0;
        switch (e.CommandName)
        {

            case ("delete"):
                id = Convert.ToInt32(e.CommandArgument);
                model m = new model();
                m.open();


                SqlDataReader dr = m.multipleTableQueryDATAROW("ServiceOrderMaster.totalnumofservice,ServiceOrderMaster.totalamount,ServiceOrderMaintain.*", "ServiceOrderMaintain INNER JOIN ServiceOrderMaster ON ServiceOrderMaintain.serviceordermasterid=ServiceOrderMaster.serviceordermasterid", "ServiceOrderMaintain.serviceordermaintainid=" + id + " and ServiceOrderMaster.isservicestart='yes' and ServiceOrderMaintain.isdelete='1'");
                if (dr.HasRows)
                {
                    dr.Read();
                    somid = Convert.ToInt32(dr["serviceordermasterid"]);
                    totalnumofservice = Convert.ToInt32(dr["totalnumofservice"]);
                    totalamount = Convert.ToInt32(dr["totalamount"]);

                    netamt = Convert.ToInt32(dr["netamt"]);

                    updated_price = totalamount - netamt;
                    totalnumofservice = totalnumofservice - 1;

                }
                dr.Close();

                m.update("ServiceOrderMaster", "totalnumofservice=" + totalnumofservice + ",totalamount=" + updated_price, "serviceordermasterid=" + somid);

                m.delete("ServiceOrderMaintain", "serviceordermaintainid=" + id);

                m.close();
                // Label1.Text = m.delete("ServiceOrderMaintain", "serviceordermaintainid=" + id);
                break;
        }
        ServiceOderMasterFillData();
    }
    protected void partsdisplayRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Int32 id = 0, somid = 0, updated_price = 0, netamt = 0, totalnumofparts = 0, totalamount = 0;
        switch (e.CommandName)
        {

            case ("delete"):
                id = Convert.ToInt32(e.CommandArgument);
                model m = new model();
                m.open();

                SqlDataReader dr = m.multipleTableQueryDATAROW("purchasemaster.totalnoofparts,purchasemaster.totalamt,purchaseordermaintain.*", "purchaseordermaintain INNER JOIN purchasemaster ON purchaseordermaintain.purchasemasterid=purchasemaster.purchasemasterid", "purchaseordermaintain.purchaseordermaintainid=" + id + " and purchasemaster.ispaymentdone='no' and purchaseordermaintain.isdelete='1'");
                if (dr.HasRows)
                {
                    dr.Read();
                    somid = Convert.ToInt32(dr["purchasemasterid"]);
                    totalnumofparts = Convert.ToInt32(dr["totalnoofparts"]);
                    totalamount = Convert.ToInt32(dr["totalamt"]);

                    netamt = Convert.ToInt32(dr["totalqtyamt"]);

                    updated_price = totalamount - netamt;
                    totalnumofparts = totalnumofparts - 1;

                }
                dr.Close();

                m.update("purchasemaster", "totalnoofparts=" + totalnumofparts + ",totalamt=" + updated_price, "purchasemasterid=" + somid);

                m.delete("purchaseordermaintain", "purchaseordermaintainid=" + id);

                m.close();
                // Label1.Text = m.delete("ServiceOrderMaintain", "serviceordermaintainid=" + id);
                break;
        }
        PurchaseDetails();
    }
    protected void btnaddOrderMaster_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceOrderMaster.aspx?contact="+contactnodrop.SelectedValue);
    }
    protected void btnaddPurchaseMaster_Click(object sender, EventArgs e)
    {
        Response.Redirect("purchaseordermaster.aspx?contact=" + contactnodrop.SelectedValue);
    }
    protected void partsdisplayRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton btn = (LinkButton)e.Item.FindControl("btndelete");
        btn.Visible = false;

        model m = new model();
        m.open();
        SqlDataReader dr = m.admin("logintbl", "loginid=" + Session["admin"].ToString() + " and deptname = 'ADMIN'");
        if (dr.HasRows)
        {
            dr.Read();
            btn.Visible = true;
        }
        dr.Close();
        SqlDataReader dr1 = m.admin("logintbl", "loginid=" + Session["admin"].ToString() + " and deptname = 'MANAGER'");
        if (dr1.HasRows)
        {
            dr1.Read();
            btn.Visible = true;
        } dr1.Close();
        m.close(); 
    }
    protected void displaydataRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton btn = (LinkButton)e.Item.FindControl("btndelete");
        btn.Visible = false;

        model m = new model();
        m.open();
        SqlDataReader dr = m.admin("logintbl", "loginid=" + Session["admin"].ToString() + " and deptname = 'ADMIN'");
        if (dr.HasRows)
        {
            dr.Read();
            btn.Visible = true;
        }
        dr.Close();
        SqlDataReader dr1 = m.admin("logintbl", "loginid=" + Session["admin"].ToString() + " and deptname = 'MANAGER'");
        if (dr1.HasRows)
        {
            dr1.Read();
            btn.Visible = true;
        } dr1.Close();
        m.close(); 
    }
}