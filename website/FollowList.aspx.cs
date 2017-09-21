using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

public partial class FollowList : System.Web.UI.Page
{
    MyHandler m = new MyHandler();
    static Person p;
    Tweet t = new Tweet();
    string filename;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["f"].ToString()) == 1)
        {
            Label2.Text = "List of Following";
            p = Session["per"] as Person;
            List<Person> per = m.following(p.user_id);
            gdvtweets.DataSource = per;
            gdvtweets.DataBind();
        }
        else
        {
            Label2.Text = "List of Follower";
            p = Session["per"] as Person;
            List<Person> per = m.follower(p.user_id);
            gdvtweets.DataSource = per;
            gdvtweets.DataBind();
        }
    }
}