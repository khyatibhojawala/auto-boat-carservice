using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ordermasterInvoice : System.Web.UI.Page
{
    static String ref_no = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ref_no = Request.QueryString["refno"];
            ServiceOrderMaintainDetail();
            DeatilsOfCarOwner();
            extraOrderNoDeatils();
            dateOrderNoDeatils();
        }
    }

    public void ServiceOrderMaintainDetail()
    {
        model m = new model();
        m.open();
        //int ordernogenerate = 0;
        //SqlDataReader drr1 = m.maxrecordFind("ServiceOrderMaster.orderno", "ServiceOrderMaster", "ServiceOrderMaster.orderno=(select MAX(ServiceOrderMaster.orderno)from ServiceOrderMaster)");
        //if (drr1.HasRows)
        //{
        //    drr1.Read();
        //    ordernogenerate = Convert.ToInt32(drr1["orderno"]);
        //    drr1.Close();
        //}
        DataTable dt = m.multipleTableQuery("carregi.contact,ServiceOrderMaintain.orderno,servicecategory.servicename,ServiceOrderMaster.orderno as som,ServiceOrderMaintain.refno,ServiceOrderMaintain.price,ServiceOrderMaintain.sgst,ServiceOrderMaintain.cgst,ServiceOrderMaintain.igst", "((ServiceOrderMaintain INNER JOIN servicecategory ON ServiceOrderMaintain.servicecategoryid=servicecategory.servicecategoryid)INNER JOIN ServiceOrderMaster ON ServiceOrderMaster.serviceordermasterid=ServiceOrderMaintain.serviceordermasterid)INNER JOIN carregi ON carregi.carid=ServiceOrderMaster.carid", "ServiceOrderMaster.refno = '" + ref_no + "' and (ServiceOrderMaintain.isdelete='1' and servicecategory.isdelete='1' and ServiceOrderMaster.isdelete='1' and carregi.isdelete='1')");
        OrdermasterDeatilsRepeater.DataSource = dt;
        OrdermasterDeatilsRepeater.DataBind();
        m.close();
    }
    public void DeatilsOfCarOwner()
    {
        model m = new model();
        m.open();
        //int carid = 0;

        //SqlDataReader drr1 = m.getLastRecord("carid", "ServiceOrderMaster", "serviceordermasterid");
        //if (drr1.HasRows)
        //{
        //    drr1.Read();
        //    carid = Convert.ToInt32(drr1["carid"]);
        //    drr1.Close();
            
            
        //}
        DataTable dt1 = m.multipleTableQuery("carregi.*", "(carregi INNER JOIN ServiceOrderMaster ON ServiceOrderMaster.carid=carregi.carid)", "ServiceOrderMaster.refno = '" + ref_no + "' and (ServiceOrderMaster.isdelete='1' and carregi.isdelete='1')");
        CarOwnerDeatilsRepeater.DataSource = dt1;
        CarOwnerDeatilsRepeater.DataBind();
        m.close();
    }
    public void extraOrderNoDeatils()
    {
        model m = new model();
        m.open();
        DataTable dtorderno = m.multipleTableQuery(" ServiceOrderMaster.*", "ServiceOrderMaster", "ServiceOrderMaster.refno='" + ref_no + "' and ServiceOrderMaster.isdelete='1'");
        ordernorepeterbind.DataSource = dtorderno;
        ordernorepeterbind.DataBind();
        m.close();
    }
    public void dateOrderNoDeatils()
    {
        model m = new model();
        m.open();
        DataTable dtdate = m.multipleTableQuery(" ServiceOrderMaster.*", "ServiceOrderMaster", "ServiceOrderMaster.refno='" + ref_no + "' and ServiceOrderMaster.isdelete='1'");
        dateRepeater.DataSource = dtdate;
        dateRepeater.DataBind();
        m.close();
    }
}