using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
public partial class FollowPage : System.Web.UI.MasterPage
{
    MyHandler m = new MyHandler();
    static Person p;
    Tweet t = new Tweet();
    string filename;
    int twt, fol, follr, img;
    int check;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["per"] != null)
        {
            p = Session["per"] as Person;
            m.count(Session["selectid"].ToString(), out twt, out fol, out follr, out img);

            Label4.Text = twt.ToString();
            Label5.Text = fol.ToString();
            Label6.Text = follr.ToString();
            if (img == 1)
            { Image1.ImageUrl = "Profilepic/" + Session["selectid"].ToString() + ".jpg"; }
            else
            { Image1.ImageUrl = "Profilepic/noprofile.jpg"; }
            lblname.Text = Session["name"].ToString();
            lbluser.Text = "@" + Session["selectid"].ToString();
            check = m.CheckUser(p.user_id, Session["selectid"].ToString());
            if (check == 0)
            {

                followuser.Visible = true;
                unfollowuser.Visible = false;

            }
            else
            {
                unfollowuser.Visible = true;
                followuser.Visible = false;

            }
            p = Session["per"] as Person;
            string users = p.user_id;
            List<Person> pers = m.users(users);
            gdvusers.DataSource = pers;
            gdvusers.DataBind();
            // p = Session["selectid"].ToString();
            // string user = per.user_id;
            //List<Tweet> tweet = m.getTweet(Session["selectid"].ToString());
            //gdvtweets.DataSource = tweet;
            //gdvtweets.DataBind();
        }
        else
        {
            Response.Redirect("~/LogIn.aspx");
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Session["follow"] = txtsearch.Text;

        Response.Redirect("~/Search.aspx");
    }
    protected void followuser_Click(object sender, ImageClickEventArgs e)
    {
        m.Follow(p.user_id, Session["selectid"].ToString());
        m.count(Session["selectid"].ToString(), out twt, out fol, out follr, out img);
        Label6.Text = follr.ToString();
       followuser.Visible = false;
        unfollowuser.Visible = true;
       
    }
    protected void unfollowuser_Click(object sender, ImageClickEventArgs e)
    {
        m.UnFollow(p.user_id, Session["selectid"].ToString());
        m.count(Session["selectid"].ToString(), out twt, out fol, out follr, out img);
        Label6.Text = follr.ToString();
       unfollowuser.Visible = false;
        followuser.Visible = true;
    }
    protected void Imgmsg_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home.aspx");
    }
   
    protected void gdvusers_SelectedIndexChanged1(object sender, EventArgs e)
    {
        int index = gdvusers.SelectedIndex;
        // gdvusers.SelectedRow.RowIndex;


        Session["selectid"] = gdvusers.DataKeys[index].Value.ToString();
        Session["name"] = (gdvusers.Rows[index].FindControl("Label11") as Label).Text;
       
        Response.Redirect("~/Follow.aspx");
    }
    protected void imgsignout_Click(object sender, ImageClickEventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("~/LogIn.aspx");
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        int id;
        string msg;
        DateTime dat = DateTime.Now;
        string user = p.user_id;// Session["uid"].ToString();
        if (TextArea1.InnerText.Trim() == "")
        {

        }
        else
        {
            m.AddTweet(user, TextArea1.InnerText, dat, out id);

            Response.Redirect("~/Home.aspx");
        }
    }
    protected void gdvusers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvusers.PageIndex = e.NewPageIndex;
        gdvusers.DataSource = m.users(p.user_id);
        gdvusers.DataBind();
    }
}
