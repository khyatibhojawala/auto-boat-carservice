using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class salesmaintainView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            displaySalesAndMaintain();
        }
    }
    public void displaySalesAndMaintain()
    {
        model m = new model();
        m.open();
        DataTable da = m.multipleTableQuery("purchaseordermaintain.*,partstbl.partname,carcompany.carcompanyname,cartype.cartype,carmodel.carmodelname,carsubmodel.carsubmodelname,carregi.contact", "(((((((purchasemaster INNER JOIN purchaseordermaintain ON purchasemaster.purchasemasterid=purchaseordermaintain.purchasemasterid)INNER JOIN partstbl ON purchaseordermaintain.partid=partstbl.partid)INNER JOIN carregi ON purchasemaster.carid=carregi.carid)INNER JOIN carcompany ON partstbl.carcompanyid=carcompany.carcompanyid)INNER JOIN cartype ON partstbl.cartypeid=cartype.cartypeid)INNER JOIN carmodel ON partstbl.carmodelid=carmodel.carmodelid)INNER JOIN carsubmodel ON partstbl.carsubmodelid=carsubmodel.carsubmodelid)", "purchasemaster.isdelete=1 and purchaseordermaintain.isdelete=1 and carcompany.isdelete=1 and cartype.isdelete=1 and carmodel.isdelete=1 and carsubmodel.isdelete=1");
        POMRepeaterMaintain.DataSource = da;
        POMRepeaterMaintain.DataBind();
        m.close();
    }
}