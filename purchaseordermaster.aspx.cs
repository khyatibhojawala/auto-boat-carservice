using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class purchaseordermaster : System.Web.UI.Page
{
    String servicecat, loginidtext;
    static int cid = 0,ordno = 0, refno = 0, price = 0, cgst = 0, sgst = 0, igst = 0, partid = 0, taxamt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Salesmandrop();
            PartsDrop();
            GetOrdernoandRefno();
            String contactno = Request.QueryString["contact"];
            contact.Text = contactno;
            if (contactno != null)
            {
                showdataFromMobile();
                setPOM_ifMobileIsAvailable();
                showPurchaseMasterDetail();
            }
        }

    }
    protected void contact_TextChanged(object sender, EventArgs e)
    {
        showdataFromMobile();
        setPOM_ifMobileIsAvailable();
        showPurchaseMasterDetail();
    }

    public void showdataFromMobile()
    {
        model m = new model();
        m.open();
        DataTable dt = m.edit("carregi", "contact='" + contact.Text + "'");
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                contact.Text = dr["contact"].ToString();
                ownername.Text = dr["ownername"].ToString();
                address.Text = dr["address"].ToString();
                email.Text = dr["email"].ToString();
                getCarCompanyDrop();
                carcompany.SelectedValue = dr["carcompanyid"].ToString();
                getCarTypeDrop();
                cartype.SelectedValue = dr["cartypeid"].ToString();
                getCarModelDrop();
                carmodel.SelectedValue = dr["carmodelid"].ToString();
                getCarSubModelDrop();
                carsubmodel.SelectedValue = dr["carsubmodelid"].ToString();
                carno.Text = dr["carno"].ToString();
                if (dr["carinsurance"].ToString().Equals("yes"))
                {
                    carinsurance.Checked = true;

                }
                else
                {
                    carinsurance.Checked = false;
                }
                engineno.Text = dr["engineno"].ToString();
                cid = Convert.ToInt32(dr["carid"].ToString());
            }
        }
        m.close();
    }

    public void setPOM_ifMobileIsAvailable()
    {
        model m = new model();
        m.open();

       // SqlDataReader drSOMset = m.multipleTableQueryDATAROW("ServiceOrderMaster.serviceordermasterid,purchasemaster.orderno,purchasemaster.refno", "(ServiceOrderMaster INNER JOIN carregi ON carregi.carid=ServiceOrderMaster.carid)INNER JOIN purchasemaster ON ServiceOrderMaster.serviceordermasterid=purchasemaster.somid", "carregi.contact='50' and (carregi.isdelete='1' and ServiceOrderMaster.isdelete='1' and purchasemaster.isdelete='1')");
        SqlDataReader drSOMset = m.getDataofServiceOnCheckboxSelection("purchasemasterid,orderno,refno", "purchasemaster", "carid='" + cid + "' and ispaymentdone='no'");
        if (drSOMset.HasRows)
        {
            drSOMset.Read();
            ordno = Convert.ToInt32(drSOMset["orderno"]);
            refrenceno.Text = drSOMset["refno"].ToString();
            drSOMset.Close();
        }
        m.close();
    }

    public void showPurchaseMasterDetail()
    {
        //int ordernogenerate = 0;
        model m = new model();
        m.open();

        DataTable da = m.multipleTableQuery("purchaseordermaintain.*,purchasemaster.remark,partstbl.partname,carregi.contact,carregi.engineno", "(((purchasemaster INNER JOIN purchaseordermaintain ON purchasemaster.purchasemasterid=purchaseordermaintain.purchasemasterid)INNER JOIN partstbl ON purchaseordermaintain.partid=partstbl.partid)INNER JOIN carregi ON purchasemaster.carid=carregi.carid)", "purchaseordermaintain.refno = '" + refrenceno.Text + "' and purchasemaster.ispaymentdone='no' and (purchasemaster.isdelete='1' and purchaseordermaintain.isdelete='1' and partstbl.isdelete='1' and carregi.isdelete='1')");
        POMRepeaterMaintain.DataSource = da;
        POMRepeaterMaintain.DataBind();

        m.close();

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        insertPOM();
        insertPOM_maintain();
        showPurchaseMasterDetail();
        cleartext();
        
    }

    public void insertPOM()
    {
        int somid = 0;
        model m = new model();
        m.open();
        loginidtext = Session["admin"].ToString();

        SqlDataReader dr = m.multipleTableQueryDATAROW("ServiceOrderMaster.serviceordermasterid,carregi.carid as crid", "ServiceOrderMaster INNER JOIN carregi ON carregi.carid=ServiceOrderMaster.carid", "carregi.contact='" + contact.Text + "' and (carregi.isdelete='1' and ServiceOrderMaster.isdelete='1')");
        if (dr.HasRows)
        {
            dr.Read();
            somid = Convert.ToInt32(dr["serviceordermasterid"]);
            cid = Convert.ToInt32(dr["crid"]);
            dr.Close();
        }
        else
        {
            somid = 0;
        }
        dr.Close();


        SqlDataReader dr1 = m.multipleTableQueryDATAROW("purchasemasterid,totalnoofparts,totalamt,remark", "purchasemaster", "refno='" + refrenceno.Text + "' and ispaymentdone='no' and isdelete='1'");
        if (dr1.HasRows)
        {
            int totalpart = 0, amt = 0;
            String rmk = "";
            dr1.Read();
            totalpart = Convert.ToInt32(dr1["totalnoofparts"]) + 1;
            amt = Convert.ToInt32(dr1["totalamt"]) + Convert.ToInt32(totalamount.Text);
            rmk = dr1["remark"].ToString();
            rmk =String.Concat(rmk.Substring(0,rmk.Length - 2),", "+remark.Text);
            dr1.Close();
            m.update("purchasemaster", "totalnoofparts=" + totalpart + ",totalamt=" + amt + ",remark='" + rmk + "'", "refno='" + refrenceno.Text + "'");
            
        }
        else
        {
            dr1.Close();
            m.insert("purchasemaster", "somid,orderno,refno,totalnoofparts,totalamt,remark,tdate,loginid,salesmanid,carid,ispaymentdone,isdelete", "'" + somid + "','" + ordno + "','" + refrenceno.Text + "',1,'" + totalamount.Text + "','" + remark.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + loginidtext + "','" + salesmanname.SelectedValue + "',"+ cid +",'no',1");
        }
        dr1.Close();
        m.close();
    }

    public void insertPOM_maintain()
    {
        //partition (insertion in POM Maintain-tbl)
        model m = new model();
        m.open();

        int POMid = 0;
        int odno = 0,reno = 0;
        SqlDataReader drSOM = m.getDataofServiceOnCheckboxSelection("purchasemasterid,orderno", "purchasemaster", "refno='" + refrenceno.Text + "' and purchasemaster.ispaymentdone='no'");
        if (drSOM.HasRows)
        {
            drSOM.Read();
            POMid = Convert.ToInt32(drSOM["purchasemasterid"]);
            odno = Convert.ToInt32(drSOM["orderno"]);
        }
        drSOM.Close();

        m.insert("purchaseordermaintain", "purchasemasterid,orderno,refno,partid,price,sgst,cgst,igst,taxamt,netamt,qty,totalqtyamt,discount,isdelete", POMid + "," + odno + ",'" + refrenceno.Text + "'," + partid + "," + price + "," + sgst + "," + cgst + "," + igst + "," + taxamt + ",'" + partprice.Text + "'," + quantity.Text + "," + totalamount.Text + ",5,1");

        //foreach (RepeaterItem aItem in repeaterPOM.Items)
        //{
        //    int partid = 0, price = 0, igst = 0, cgst = 0, sgst = 0, taxamt = 0, netamt = 0;
        //    CheckBox chkItemId = (CheckBox)aItem.FindControl("partname");
        //    if (chkItemId.Checked)
        //    {
        //        if (gsttype.SelectedValue == "igst")
        //        {
        //            SqlDataReader drtext = m.getDataofServiceOnCheckboxSelection("partid,partprice," + gsttype.SelectedValue, "partstbl", "partname='" + chkItemId.Text + "'");
        //            if (drtext.HasRows)
        //            {
        //                drtext.Read();
        //                partid = Convert.ToInt32(drtext["partid"]);
        //                price = Convert.ToInt32(drtext["partprice"]);
        //                igst = Convert.ToInt32(drtext["igst"]);
        //                taxamt = price * igst / 100;
        //                netamt = price + taxamt;

        //            }
        //            drtext.Close();
        //        }

        //        else if (gsttype.SelectedValue == "cgst,sgst")
        //        {
        //            SqlDataReader drtext = m.getDataofServiceOnCheckboxSelection("partid,partprice," + gsttype.SelectedValue, "partstbl", "partname='" + chkItemId.Text + "'");
        //            if (drtext.HasRows)
        //            {
        //                drtext.Read();
        //                partid = Convert.ToInt32(drtext["partid"]);
        //                price = Convert.ToInt32(drtext["partprice"]);
        //                cgst = Convert.ToInt32(drtext["cgst"]);
        //                sgst = Convert.ToInt32(drtext["sgst"]);
        //                int cgstprice = price * cgst / 100;
        //                int sgstprice = price * sgst / 100;
        //                taxamt = cgstprice + sgstprice;
        //                netamt = price + taxamt;

        //            }
        //            drtext.Close();
        //        }

        //        m.insert("purchaseordermaintain", "purchasemasterid,orderno,refno,partid,price,sgst,cgst,igst,taxamt,netamt,discount,isdelete", POMid + "," + ordno + ",'" + refrenceno.Text + "'," + partid + "," + price + "," + sgst + "," + cgst + "," + igst + "," + taxamt + "," + netamt + ",5,1");

        //    }

        //}
        m.close();
        //!! End of Partition (insertion in SOM Maintain-tbl)
    }

    protected void repeat_ItemCommand(object source, RepeaterCommandEventArgs e)
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

                m.update("purchasemaster", "totalnoofparts=" + totalnumofparts + ",totalamt=" + updated_price, "purchasemaster.ispaymentdone='no' and purchasemasterid=" + somid);

                m.delete("purchaseordermaintain", "purchaseordermaintainid=" + id);

                m.close();
                // Label1.Text = m.delete("ServiceOrderMaintain", "serviceordermaintainid=" + id);
                break;
        }
        showPurchaseMasterDetail();
    }

    public void PartsDrop()
    {
        model m = new model();

        m.open();
        DataSet ds = new DataSet();
        ds = m.showdrop("*", "partstbl", "");
        parts.DataSource = ds.Tables[0];
        parts.DataTextField = ds.Tables[0].Columns["partname"].ColumnName.ToString();
        parts.DataValueField = ds.Tables[0].Columns["partid"].ColumnName.ToString();
        parts.DataBind();
        m.close();

        parts.Items.Insert(0, new ListItem("Select Part", "0"));

    }

    public void Salesmandrop()
    {
        model m = new model();

        m.open();
        DataSet ds = new DataSet();
        ds = m.showdrop("*", "salesmantbl", "");
        salesmanname.DataSource = ds.Tables[0];
        salesmanname.DataTextField = ds.Tables[0].Columns["salesmanname"].ColumnName.ToString();
        salesmanname.DataValueField = ds.Tables[0].Columns["salesmanid"].ColumnName.ToString();
        salesmanname.DataBind();
        m.close();

        salesmanname.Items.Insert(0, new ListItem("Select Salesman", "0"));

    }
    
    public void GetOrdernoandRefno()
    {
        model m = new model();
        m.open();
        SqlDataReader dr = m.getLastRecord("orderno", "purchasemaster", "orderno");
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
    //public void PurchaseOrdermasterCheckedBoxRepeaterBind()
    //{
    //    model m = new model();
    //    m.open();
    //    DataTable da = m.show("partstbl");
    //    repeaterPOM.DataSource = da;
    //    repeaterPOM.DataBind();
    //    m.close();

    //}

    protected void changecheckedbox(object sender, EventArgs e)
    {
        int totalamountofparts = 0;
    //    int counter = 0;

    //    //to fetch how many data is there in SERVICECATEGORY TABLE and store it in "counter" variable
        model m = new model();
        m.open();
    //    SqlDataReader dr = m.getLastRecordByCOUNT("partid", "partstbl");
    //    if (dr.HasRows)
    //    {
    //        dr.Read();
    //        counter = Convert.ToInt32(dr[0].ToString());
    //        dr.Close();
    //    }


    //    //process of on checked change event according to Total Records in SERVICECATEGORY TABLE
    //    int service_count = 0;
    //    string str = "";
    //    remark.Text = "";
    //    foreach (RepeaterItem aItem in repeaterPOM.Items)
    //    {
    //        CheckBox chkItemId = (CheckBox)aItem.FindControl("partname");
    //        if (chkItemId.Checked)
    //        {
    //            str = "";
    //            str = chkItemId.Text + " , ";
    //            remark.Text = remark.Text + str;

    //            service_count++;
    //            counter++;


                if (gsttype.SelectedValue == "igst")
                {
                    SqlDataReader drtext = m.getDataofServiceOnCheckboxSelection("partprice," + gsttype.SelectedValue, "partstbl", "partid='" + parts.SelectedValue + "'");
                    if (drtext.HasRows)
                    {
                        drtext.Read();
                        int price = Convert.ToInt32(drtext["partprice"].ToString());
                        int igst = Convert.ToInt32(drtext["igst"].ToString());
                        int igstprice = price * igst / 100;
                        int finalprice = price + igstprice;
                        totalamountofparts += finalprice;
                        drtext.Close();
                    }
                }
                else if (gsttype.SelectedValue == "cgst,sgst")
                {
                    SqlDataReader drtext = m.getDataofServiceOnCheckboxSelection("partprice," + gsttype.SelectedValue, "partstbl", "partid='" + parts.SelectedValue + "'");
                    if (drtext.HasRows)
                    {
                        drtext.Read();
                        int price = Convert.ToInt32(drtext["partprice"].ToString());
                        int cgst = Convert.ToInt32(drtext["cgst"].ToString());
                        int sgst = Convert.ToInt32(drtext["sgst"].ToString());
                        int cgstprice = price * cgst / 100;
                        int sgstprice = price * sgst / 100;
                        int finalprice = price + cgstprice + sgstprice;
                        totalamountofparts += finalprice;
                        drtext.Close();
                    }
                }
    //        }
    //        else
    //        {
    //            counter--;
    //        }

    //    }

    //    if (counter == 0)
    //    {
    //        remark.Text = "";
    //        totalnumofparts.Text = 0.ToString();
    //        totalamount.Text = 0.ToString();
    //    }
    //    else
    //    {
    //        String wholestr = remark.Text;
    //        String substr = wholestr.Substring(0, Convert.ToInt32(wholestr.Length - 2));
    //        servicecat = substr + " :";
    //        remark.Text = servicecat;

    //        totalnumofparts.Text = service_count.ToString();
    //        totalamount.Text = totalamountofservices.ToString();
    //    }

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
        ds = m.showdrop("*", "cartype", " and carcompanyid=" + carcompany.SelectedValue);
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
    private void cleartext()
    {
        totalamount.Text = "";
        remark.Text = "";
        quantity.Text = "";
        partprice.Text = "";
        parts.SelectedValue = 0.ToString();
    }

    protected void POMRepeaterMaintain_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
        }
        dr.Close();
        SqlDataReader dr1 = m.admin("logintbl", "loginid=" + Session["admin"].ToString() + " and deptname like 'manager'");
        if (dr1.HasRows)
        {
            dr1.Read();
            btn.Visible = true;
        } dr1.Close();
        m.close(); 
    }
    protected void printbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("bill.aspx?contact=" + contact.Text);
    }
    protected void parts_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        //to fetch how many data is there in PARTS TABLE and store it in "counter" variable
        model m = new model();
        m.open();

        if (gsttype.SelectedValue == "igst")
        {
            SqlDataReader drtext = m.getDataofServiceOnCheckboxSelection("partid,partname,partprice," + gsttype.SelectedValue, "partstbl", "partid='" + parts.SelectedValue + "'");
            if (drtext.HasRows)
            {
                drtext.Read();
                partid = Convert.ToInt32(drtext["partid"]);
                remark.Text = String.Concat(drtext["partname"].ToString()," :");
                price = Convert.ToInt32(drtext["partprice"].ToString());
                igst = Convert.ToInt32(drtext["igst"].ToString());
                int igstprice = price * igst / 100;
                taxamt = igstprice;
                int finalprice = price + igstprice;
                partprice.Text = finalprice.ToString();
                drtext.Close();
            }
        }
        else if (gsttype.SelectedValue == "cgst,sgst")
        {
            SqlDataReader drtext = m.getDataofServiceOnCheckboxSelection("partid,partname,partprice," + gsttype.SelectedValue, "partstbl", "partid='" + parts.SelectedValue + "'");
            if (drtext.HasRows)
            {
                drtext.Read();
                partid = Convert.ToInt32(drtext["partid"]);
                remark.Text = String.Concat(drtext["partname"].ToString(), " :");
                price = Convert.ToInt32(drtext["partprice"].ToString());
                cgst = Convert.ToInt32(drtext["cgst"].ToString());
                sgst = Convert.ToInt32(drtext["sgst"].ToString());
                int cgstprice = price * cgst / 100;
                int sgstprice = price * sgst / 100;
                taxamt = cgstprice + sgstprice;
                int finalprice = price + cgstprice + sgstprice;
                partprice.Text = finalprice.ToString();
                drtext.Close();
            }
        }

        m.close();
    }
    protected void quantity_TextChanged(object sender, EventArgs e)
    {
        totalamount.Text = (Convert.ToInt32(partprice.Text) * Convert.ToInt32(quantity.Text)).ToString();

    }
}