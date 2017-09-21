using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
public partial class Follow : System.Web.UI.Page
{
    
    MyHandler m = new MyHandler();
    static Person p;
    Tweet t = new Tweet();
    string filename;
    protected void Page_Load(object sender, EventArgs e)
    {
        p = Session["per"] as Person;
        List<Tweet> t = m.getTweet(Session["selectid"].ToString());
        gdvtweets.DataSource = t;
        gdvtweets.DataBind();
        
    }
}