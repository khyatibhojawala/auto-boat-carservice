using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ServiceOrderMasterView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            displayOrderMasterAndMaintain();
        }
    }
    public void displayOrderMasterAndMaintain()
    {
        model m = new model();
        m.open();
        DataTable da = m.multipleTableQuery("ServiceOrderMaster.orderno as SOMOrderno,ServiceOrderMaintain.refno as mrefno,ServiceOrderMaster.refno as SOMrefno,ServiceOrderMaster.*,ServiceOrderMaintain.*,ServiceOrderMaintain.orderno as morderno,ServiceOrderMaster.carid", "(ServiceOrderMaster INNER JOIN ServiceOrderMaintain On ServiceOrderMaster.serviceordermasterid=ServiceOrderMaintain.serviceordermasterid)", "ServiceOrderMaster.isdelete=1 and ServiceOrderMaintain.isdelete=1");
        SOMRepeaterMaintain.DataSource = da;
        SOMRepeaterMaintain.DataBind();
        m.close();
    }
}