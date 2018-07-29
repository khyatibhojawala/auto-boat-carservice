using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class cardetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showCarregi();
        }
    }
    public void showCarregi()
    {
        model m = new model();
        m.open();
        DataTable dt = m.multipleTableQuery("carcompany.carcompanyname,cartype.cartype,carmodel.carmodelname,carsubmodel.carsubmodelname,carregi.*", "(((carregi INNER JOIN carcompany ON carregi.carcompanyid=carcompany.carcompanyid)INNER JOIN cartype ON carregi.cartypeid=cartype.cartypeid)INNER JOIN carmodel ON carregi.carmodelid=carmodel.carmodelid)INNER JOIN carsubmodel ON carregi.carsubmodelid=carsubmodel.carsubmodelid", "carregi.isdelete='1'");
        CarRegiRepeater.DataSource = dt;
        CarRegiRepeater.DataBind();
        m.close();
    }
}