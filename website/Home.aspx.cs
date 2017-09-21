using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

public partial class ViewProfile : System.Web.UI.Page
{
    Tweet twt = new Tweet();
    static Person per;
    MyHandler m = new MyHandler();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            per = Session["per"] as Person;
            string user = per.user_id;
            List<Tweet> tweet = m.DisplayTweets(user).OrderByDescending(twt => twt.created).ToList();
            gdvtweets.DataSource = tweet;
            gdvtweets.DataBind();
        }
    }
}