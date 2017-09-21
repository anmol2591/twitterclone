using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

public partial class Home : System.Web.UI.Page
{
    Tweet twt = new Tweet();
    static Person per;
    MyHandler m = new MyHandler();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["per"] != null)
        {
            if (!IsPostBack)
            {
                per = Session["per"] as Person;
                string user = per.user_id;
                List<Tweet> tweet = m.getTweet(user).OrderByDescending(twt => twt.created).ToList();
                gdvtweet.DataSource = tweet;
                gdvtweet.DataBind();
            }
        }
        else
        {
            Response.Redirect("~/LogIn.aspx");
        }
    }
    protected void gdvtweet_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gdvtweet.EditIndex = e.NewEditIndex;
        List<Tweet> twee = m.getTweet(per.user_id);
        gdvtweet.DataSource = twee;
        gdvtweet.DataBind();
    }
    protected void gdvtweet_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(gdvtweet.DataKeys[e.RowIndex].Value.ToString());
        m.DelTweet(id);
        Response.Redirect("~/Home.aspx");
    }
    protected void gdvtweet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gdvtweet.EditIndex = -1;
        List<Tweet> twee = m.getTweet(per.user_id);
        gdvtweet.DataSource = twee;
        gdvtweet.DataBind();
    }

    protected void gdvtweet_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int id = Convert.ToInt32(gdvtweet.DataKeys[e.RowIndex].Value.ToString());
        int index = gdvtweet.EditIndex;
        GridViewRow row = gdvtweet.Rows[index];
        TextBox uptweet = row.FindControl("TextBox1") as TextBox;
        m.UpdTweet(id, uptweet.Text);
        gdvtweet.EditIndex = -1;


        List<Tweet> twee = m.getTweet(per.user_id);
        gdvtweet.DataSource = twee;
        gdvtweet.DataBind();
    }
   
}