using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
public partial class ServiceOrderMaster : System.Web.UI.Page
{
    public static int a;
    static int ordno = 0;
    String servicecat, loginidtext;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            carno1.Text = "GJ";
            carno2.Text = "05";
            startservicedate.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            Salesmandrop();
            carinquiryid.Text = 0.ToString();
            GetOrdernoandRefno();
            OrdermasterCheckedBoxRepeaterBind();
            getCarCompanyDrop();

            isservicestart.Checked = true;
            String contactno = Request.QueryString["contact"];
            contact.Text = contactno;
            if (contactno != null)
            {
                showdataFromMobile();
                setSOM_ifMobileIsAvailable();
                OrdermasterDisplayMaintainRepeaterBind();
                alreadyExistServiceDisable();
            }
            
        }
    }

    public void OrdermasterCheckedBoxRepeaterBind()
    {
        model m = new model();
        m.open();
        DataTable da = m.show("servicecategory");
        repeaterSOM.DataSource = da;
        repeaterSOM.DataBind();
        m.close();

    }

    protected void repeat_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Int32 id = 0, somid = 0, updated_price = 0, netamt = 0, totalnumofservice = 0, totalamount = 0;
        switch (e.CommandName)
        {

            case ("delete"):
                id = Convert.ToInt32(e.CommandArgument);
                model m = new model();
                m.open();


                SqlDataReader dr = m.multipleTableQueryDATAROW("ServiceOrderMaster.totalnumofservice,ServiceOrderMaster.totalamount,ServiceOrderMaintain.*", "ServiceOrderMaintain INNER JOIN ServiceOrderMaster ON ServiceOrderMaintain.serviceordermasterid=ServiceOrderMaster.serviceordermasterid", "ServiceOrderMaintain.serviceordermaintainid=" + id + " and ServiceOrderMaintain.isdelete='1'");
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
        OrdermasterDisplayMaintainRepeaterBind();
    }

    public void editParts(Int32 id)
    {
        DataTable dt = new DataTable();
        model m = new model();
        m.open();
        dt = m.edit("partstbl", "partid=" + id);
        //if (dt != null)
        //{
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        partname.Text = dr["partname"].ToString();
        //        carcompany.Text = dr["carcompany"].ToString();
        //        cartype.Text = dr["cartype"].ToString();
        //        carmodel.Text = dr["carmodel"].ToString();
        //        carsubmodel.Text = dr["carsubmodel"].ToString();
        //        partprice.Text = dr["partprice"].ToString();
        //        sgst.Text = dr["sgst"].ToString();
        //        cgst.Text = dr["cgst"].ToString();
        //        igst.Text = dr["igst"].ToString();
        //        remark.Text = dr["remark"].ToString();
        //        partcode.Text = dr["partcode"].ToString();
        //        loginid.Text = dr["loginid"].ToString();
        //        tdate.Text = dr["tdate"].ToString();

        //    }
        //}
        m.close();
        btnsubmit.Visible = false;
        //btnupdate.Visible = true;
    }

    public void GetOrdernoandRefno()
    {
        model m = new model();
        m.open();
        SqlDataReader dr = m.getLastRecord("orderno", "ServiceOrderMaster", "orderno");
        if (dr.HasRows)
        {
            dr.Read();
            ordno = Convert.ToInt32(dr["orderno"]);
            dr.Close();
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

    public void showdataFromMobile()
    {
        model m = new model();
        m.open();
        a = 0;
        SqlDataReader dr = m.admin("carregi", "contact='" + contact.Text + "'");
        if (dr.HasRows)
        {
            dr.Read();
            a = 1;
            contact.Text = dr["contact"].ToString();
            ownername.Text = dr["ownername"].ToString();
            address.Text = dr["address"].ToString();
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

            DataTable dt1 = m.edit("carinquiry", "carid='" + dr["carid"] + "'");
            if (dt1 != null)
            {
                foreach (DataRow dr1 in dt1.Rows)
                {
                    carinquiryid.Text = dr1["carinquiryid"].ToString();
                }
            }

        }
        else
        {
            ClearTextbox_carregi();
        }
        dr.Close();

        m.close();
    }

    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        
        loginidtext = Session["admin"].ToString();
        if (a == 1)
        {
            insertSOM();
            insertSOMmaintain();
            //cleartextbox();
            //Response.Redirect(Request.RawUrl);
            
        }
        else if (a == 0)
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
                String carno = carno1.Text + "-" + carno2.Text + " " + carno3.Text + " " + carno4.Text;
                dr.Close();
                labelemail.Visible = true;
                labelemail.Text = "Email avilable";
                labelemail.ForeColor = System.Drawing.Color.Green;
                m.insert("carregi", "ownername,address,email,contact,carno,carcompanyid,cartypeid,carmodelid,carsubmodelid,carinsurance,engineno,tdate,loginid,isdelete", "'" + ownername.Text + "','" + address.Text + "','" + email.Text + "','" + contact.Text + "','" + carno + "','" + carcompany.SelectedValue + "','" + cartype.SelectedValue + "','" + carmodel.SelectedValue + "','" + carsubmodel.SelectedValue + "','" + insurance + "','" + engineno.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + loginidtext + ",1");
            }
            
            m.close();

            insertSOM();
            insertSOMmaintain();
        }
        OrdermasterDisplayMaintainRepeaterBind();
        ClearTextBox();
    }

    public void insertSOM()
    {
        model m = new model();
        m.open();
        string servicestart = "false";

        if (isservicestart.Checked)
            servicestart = "yes";
        else
            servicestart = "no";
        salesmanname.Text = salesmanname.SelectedValue;

        SqlDataReader drSOMset = m.multipleTableQueryDATAROW("ServiceOrderMaster.*", "(ServiceOrderMaster INNER JOIN carregi ON carregi.carid=ServiceOrderMaster.carid)", "carregi.contact='" + contact.Text + "' and ServiceOrderMaster.isservicestart='yes' and (carregi.isdelete='1' and ServiceOrderMaster.isdelete='1')");
        if (drSOMset.HasRows)
        {
            int somid=0, totalservice = 0, totalamt = 0;
            String rmk = "";
            drSOMset.Read();
            somid = Convert.ToInt32(drSOMset["serviceordermasterid"]);
            totalservice = Convert.ToInt32(drSOMset["totalnumofservice"]) + Convert.ToInt32(totalnumofservice.Text);
            totalamt = Convert.ToInt32(drSOMset["totalamount"]) + Convert.ToInt32(totalamount.Text);
            rmk =String.Concat(drSOMset["remark"].ToString(),remark.Text.ToString());

            drSOMset.Close();
            m.update("ServiceOrderMaster", "totalnumofservice=" + totalservice + ",totalamount=" + totalamt + ",remark='" + rmk +"'", "serviceordermasterid=" + somid);

           
        }
        else
        {
            drSOMset.Close();
            int cid = 0;    
            SqlDataReader drr = m.ValidationEmailMobile("carregi", "contact='" + contact.Text + "'");
             if (drr.HasRows)
            {
                drr.Read();
                cid = Convert.ToInt32(drr["carid"].ToString());
                drr.Close();
            }
            else
            {
                cid = 0;
                //GetOrdernoandRefno();
            }
            int carinqid = Convert.ToInt32(carinquiryid.Text);
            m.insert("ServiceOrderMaster", "orderno,refno,carinquiryid,totalnumofservice,totalamount,remark,tdate,isservicestart,startservicedate,endservicedate,loginid,salesmanid,carid,isdelete", "" + ordno + ",'" + refrenceno.Text + "'," + carinqid + "," + totalnumofservice.Text + "," + totalamount.Text + ",'" + remark.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + servicestart + "','" + startservicedate.Text + "','" + endservicedate.Text + "'," + loginidtext + "," + salesmanname.Text + "," + cid + ",1");

        }
        
        m.close();
    }

    public void insertSOMmaintain()
    {
        //partition (insertion in SOM Maintain-tbl)
        model m = new model();
        m.open();

        int SOMid = 0;
        int odno = 0;
        int refno = 0;
        SqlDataReader drSOM = m.multipleTableQueryDATAROW("ServiceOrderMaster.serviceordermasterid,ServiceOrderMaster.orderno,ServiceOrderMaster.refno", "(ServiceOrderMaster INNER JOIN carregi ON carregi.carid=ServiceOrderMaster.carid)", "carregi.contact='" + contact.Text + "' and ServiceOrderMaster.isservicestart='yes' and (carregi.isdelete='1' and ServiceOrderMaster.isdelete='1')");
        if (drSOM.HasRows)
        {
            drSOM.Read();
            SOMid = Convert.ToInt32(drSOM["serviceordermasterid"]);
            odno = Convert.ToInt32(drSOM["orderno"]);
            drSOM.Close();
        }

        foreach (RepeaterItem aItem in repeaterSOM.Items)
        {
            int servicecategoryid = 0, price = 0, igst = 0, cgst = 0, sgst = 0, taxamt = 0, netamt = 0;
            CheckBox chkItemId = (CheckBox)aItem.FindControl("servicecategory");
            if (chkItemId.Checked)
            {
                if (gsttype.SelectedValue == "igst")
                {
                    SqlDataReader drtext = m.getDataofServiceOnCheckboxSelection("servicecategoryid,price," + gsttype.SelectedValue, "servicecategory", "servicename='" + chkItemId.Text + "'");
                    if (drtext.HasRows)
                    {
                        drtext.Read();
                        servicecategoryid = Convert.ToInt32(drtext["servicecategoryid"]);
                        price = Convert.ToInt32(drtext["price"]);
                        igst = Convert.ToInt32(drtext["igst"]);
                        taxamt = price * igst / 100;
                        netamt = price + taxamt;
                        drtext.Close();

                    }
                }
                else if (gsttype.SelectedValue == "cgst,sgst")
                {
                    SqlDataReader drtext = m.getDataofServiceOnCheckboxSelection("servicecategoryid,price," + gsttype.SelectedValue, "servicecategory", "servicename='" + chkItemId.Text + "'");
                    if (drtext.HasRows)
                    {
                        drtext.Read();
                        servicecategoryid = Convert.ToInt32(drtext["servicecategoryid"]);
                        price = Convert.ToInt32(drtext["price"]);
                        cgst = Convert.ToInt32(drtext["cgst"]);
                        sgst = Convert.ToInt32(drtext["sgst"]);
                        int cgstprice = price * cgst / 100;
                        int sgstprice = price * sgst / 100;
                        taxamt = cgstprice + sgstprice;
                        netamt = price + taxamt;
                        drtext.Close();

                    }
                }


                m.insert("ServiceOrderMaintain", "serviceordermasterid,orderno,refno,servicecategoryid,price,sgst,cgst,igst,taxamt,netamt,discount,isdelete", SOMid + "," + odno + ",'" + refrenceno.Text + "'," + servicecategoryid + "," + price + "," + sgst + "," + cgst + "," + igst + "," + taxamt + "," + netamt + ",5,1");

            }

        }
        m.close();
        //!! End of Partition (insertion in SOM Maintain-tbl)
    }
    public void alreadyExistServiceDisable()
    {
        model m = new model();
        m.open();
        DataTable dtc = m.multipleTableQuery("ServiceOrderMaintain.servicecategoryid,servicecategory.servicename", "(((ServiceOrderMaintain INNER JOIN ServiceOrderMaster ON ServiceOrderMaintain.serviceordermasterid=ServiceOrderMaster.serviceordermasterid)INNER JOIN servicecategory ON servicecategory.servicecategoryid=ServiceOrderMaintain.servicecategoryid)INNER JOIN carregi ON carregi.carid=ServiceOrderMaster.carid)", "carregi.contact = '" + contact.Text + "' and ServiceOrderMaster.isservicestart='yes' and (ServiceOrderMaintain.isdelete='1' and carregi.isdelete='1' and ServiceOrderMaster.isdelete='1' and servicecategory.isdelete='1')");

        if (dtc != null)
        {
            foreach (RepeaterItem aItem in repeaterSOM.Items)
            {
                CheckBox chkItemId = (CheckBox)aItem.FindControl("servicecategory");

                foreach (DataRow c in dtc.Rows)
                {
                    if (chkItemId.Text.Equals(c["servicename"].ToString()))
                    {
                        chkItemId.Enabled = false;
                    }
                }

            }
        }
        m.close();
    }
    protected void contact_TextChanged(object sender, EventArgs e)
    {
        showdataFromMobile();
        setSOM_ifMobileIsAvailable();
        OrdermasterDisplayMaintainRepeaterBind();
        alreadyExistServiceDisable();

       
    }

    public void setSOM_ifMobileIsAvailable()
    {
        model m = new model();
        m.open();

        SqlDataReader drSOMset = m.multipleTableQueryDATAROW("ServiceOrderMaster.*", "(ServiceOrderMaster INNER JOIN carregi ON carregi.carid=ServiceOrderMaster.carid)", "carregi.contact='" + contact.Text + "' and ServiceOrderMaster.isservicestart='yes' and (carregi.isdelete='1' and ServiceOrderMaster.isdelete='1')");
        if (drSOMset.HasRows)
        {
            drSOMset.Read();
            ordno = Convert.ToInt32(drSOMset["orderno"]);
            refrenceno.Text = drSOMset["refno"].ToString();
            drSOMset.Close();
        }
        else
        {
            GetOrdernoandRefno();
        }
        m.close();
    }

    public void ClearTextbox_carregi()
    {
        ownername.Text = "";
        address.Text = "";
        email.Text = "";
        carinsurance.Checked = false;
        engineno.Text = "";
        carcompany.SelectedValue = 0.ToString();
        cartype.SelectedValue = 0.ToString();
        carmodel.SelectedValue = 0.ToString();
        carsubmodel.SelectedValue = 0.ToString();
        carno1.Text = "GJ";
        carno2.Text = "05";
        carno3.Text = "";
        carno4.Text = "";
    }

    private void ClearTextBox()
    {
        totalnumofservice.Text = "";
        totalamount.Text = "";
        remark.Text = "";
        foreach (RepeaterItem i in repeaterSOM.Items)
        {
            CheckBox cb = (CheckBox)i.FindControl("servicecategory");
            cb.Checked = false;
        }
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

    protected void chkchange(object sender, EventArgs e)
    {
        int totalamountofservices = 0;
        int counter = 0;

        //to fetch how many data is there in SERVICECATEGORY TABLE and store it in "counter" variable
        model m = new model();
        m.open();
        SqlDataReader dr = m.getLastRecordByCOUNT("servicecategoryid", "servicecategory");
        if (dr.HasRows)
        {
            dr.Read();
            counter = Convert.ToInt32(dr[0].ToString());
            dr.Close();
        }


        //process of on checked change event according to Total Records in SERVICECATEGORY TABLE
        int service_count = 0;
        string str = "";
        remark.Text = "";
        foreach (RepeaterItem aItem in repeaterSOM.Items)
        {
            CheckBox chkItemId = (CheckBox)aItem.FindControl("servicecategory");
            if (chkItemId.Checked)
            {
                str = "";
                str = chkItemId.Text + " , ";
                remark.Text = remark.Text + str;

                service_count++;
                counter++;


                if (gsttype.SelectedValue == "igst")
                {
                    SqlDataReader drtext = m.getDataofServiceOnCheckboxSelection("price," + gsttype.SelectedValue, "servicecategory", "servicename='" + chkItemId.Text + "'");
                    if (drtext.HasRows)
                    {
                        drtext.Read();
                        int price = Convert.ToInt32(drtext["price"].ToString());
                        int igst = Convert.ToInt32(drtext["igst"].ToString());
                        int igstprice = price * igst / 100;
                        int finalprice = price + igstprice;
                        totalamountofservices += finalprice;
                        drtext.Close();
                    }
                }
                else if (gsttype.SelectedValue == "cgst,sgst")
                {
                    SqlDataReader drtext = m.getDataofServiceOnCheckboxSelection("price," + gsttype.SelectedValue, "servicecategory", "servicename='" + chkItemId.Text + "'");
                    if (drtext.HasRows)
                    {
                        drtext.Read();
                        int price = Convert.ToInt32(drtext["price"].ToString());
                        int cgst = Convert.ToInt32(drtext["cgst"].ToString());
                        int sgst = Convert.ToInt32(drtext["sgst"].ToString());
                        int cgstprice = price * cgst / 100;
                        int sgstprice = price * sgst / 100;
                        int finalprice = price + cgstprice + sgstprice;
                        totalamountofservices += finalprice;
                        drtext.Close();
                    }
                }
            }
            else
            {
                counter--;
            }

        }

        if (counter == 0)
        {
            remark.Text = "";
            totalnumofservice.Text = 0.ToString();
            totalamount.Text = 0.ToString();
        }
        else
        {
            String wholestr = remark.Text;
            String substr = wholestr.Substring(0, Convert.ToInt32(wholestr.Length - 2));
            servicecat = substr + " :";
            remark.Text = servicecat;

            totalnumofservice.Text = service_count.ToString();
            totalamount.Text = totalamountofservices.ToString();
        }

    }

    protected void printbtn_Click(object sender, EventArgs e)
    {
        //GetOrdernoandRefnoIncrement();
        Response.Redirect("ordermasterInvoice.aspx?refno=" + refrenceno.Text);
    }

    public void OrdermasterDisplayMaintainRepeaterBind()
    {
        //int ordernogenerate = 0;
        model m = new model();
        m.open();

        DataTable da = m.multipleTableQuery("ServiceOrderMaster.orderno as som,carregi.*,ServiceOrderMaintain.*,servicecategory.servicename", "(((ServiceOrderMaintain INNER JOIN ServiceOrderMaster ON ServiceOrderMaintain.serviceordermasterid=ServiceOrderMaster.serviceordermasterid)INNER JOIN servicecategory ON servicecategory.servicecategoryid=ServiceOrderMaintain.servicecategoryid)INNER JOIN carregi ON carregi.carid=ServiceOrderMaster.carid)", "carregi.contact = '" + contact.Text + "' and ServiceOrderMaster.isservicestart='yes' and (ServiceOrderMaintain.isdelete='1' and carregi.isdelete='1' and ServiceOrderMaster.isdelete='1' and servicecategory.isdelete='1')");
        SOMRepeaterMaintain.DataSource = da;
        SOMRepeaterMaintain.DataBind();
        m.close();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DateTime today = DateTime.Now;
        if (DropDownList1.SelectedValue == "1month")
        {

            DateTime onemonthdate = today.AddMonths(1);
            endservicedate.Text = onemonthdate.ToString();
        }
        else if (DropDownList1.SelectedValue == "2month")
        {

            DateTime twomonthdate = today.AddMonths(2);
            endservicedate.Text = twomonthdate.ToString();
        }
        else if (DropDownList1.SelectedValue == "3month")
        {

            DateTime threemonthdate = today.AddMonths(3);
            endservicedate.Text = threemonthdate.ToString();
        }
        else
        {
            DateTime enddate = today.AddDays(Convert.ToInt32(DropDownList1.SelectedValue));
            endservicedate.Text = enddate.ToString();
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

    protected void carcompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        getCarTypeDrop();

        carmodel.SelectedValue = "0";
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

        carmodel.Items.Insert(0, new ListItem("Select model", "0"));
    }
    protected void cartype_SelectedIndexChanged(object sender, EventArgs e)
    {
        getCarModelDrop();

        carsubmodel.SelectedValue = "0";
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
    protected void carmodel_SelectedIndexChanged(object sender, EventArgs e)
    {
        getCarSubModelDrop();
    }

    protected void SOMRepeaterMaintain_ItemDataBound(object sender, RepeaterItemEventArgs e)
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