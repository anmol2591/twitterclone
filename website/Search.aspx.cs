using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

public partial class Search : System.Web.UI.Page
{
    Person p = new Person();
    MyHandler m = new MyHandler();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        p = Session["per"] as Person;
        try
        {
            List<Person> per = m.search(Session["follow"].ToString(), p.user_id);
            if (per.Count == 0)
            {
                Label3.Text = "No results found";
            }
            else
            {
                Label3.Text = "Results for" + " " + " " +Session["follow"].ToString();
                gdvsearch.DataSource = per;
                gdvsearch.DataBind();
            }
        }
        catch
        {
            Label3.Text = "No results found";
        }
           
        //}
    }
    protected void gdvsearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = gdvsearch.SelectedRow.RowIndex;


        Session["selectid"] = gdvsearch.DataKeys[index].Value.ToString();
        Session["name"] = (gdvsearch.Rows[index].FindControl("Label11") as Label).Text;
        Response.Redirect("~/Follow.aspx");
    }
}