using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

public partial class UserMaster : System.Web.UI.MasterPage
{
    MyHandler m = new MyHandler();
    static Person p;
    Tweet t = new Tweet();
    string filename;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["per"] != null)
        {
            if (!IsPostBack)
            {

                int twt, fol, follr, img;
                p = Session["per"] as Person;
                string user = p.user_id;
                lblname.Text = p.fullName;

                //  lbluser.Text = Session["uname"].ToString();
                lbluser.Text = "@" + user;

                m.count(user, out twt, out fol, out follr, out img);
                Label4.Text = twt.ToString();
                Label5.Text = fol.ToString();
                Label6.Text = follr.ToString();
                if (img == 1)
                {

                    Image1.ImageUrl = "Profilepic/" + user + ".jpg";
                }
                else
                { Image1.ImageUrl = "Profilepic/noprofile.jpg"; }

                p = Session["per"] as Person;
                string users = p.user_id;
                List<Person> pers = m.users(users);
                gdvusers.DataSource = pers;
                gdvusers.DataBind();
            }
        }
        else
        {
            Response.Redirect("~/LogIn.aspx");
        }


    }


    protected void Imgcompose_Click1(object sender, ImageClickEventArgs e)
    {

    }
    protected void Imgtweet_Click(object sender, ImageClickEventArgs e)
    {
        int id;
        string msg;
        DateTime dat = DateTime.Now;
        string user = p.user_id;// Session["uid"].ToString();
        if (txttweet.InnerText.Trim() == "")
        {

        }
        else
        {
            m.AddTweet(user, txttweet.InnerText, dat, out id);

            Response.Redirect("~/Home.aspx");
        }

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Session["follow"] = txtsearch.Text;

        Response.Redirect("~/Search.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        if (newAvatar.HasFile)
        {
            filename = p.user_id + ".jpg";
            newAvatar.SaveAs(Server.MapPath("/Profilepic/") + filename);
            m.imag(p.user_id);
            Image1.ImageUrl = "/Profilepic/" + filename;
            // Response.Redirect("~/Home.aspx");


        }
    }
    protected void Imgmsg_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home.aspx");
    }
    protected void gdvusers_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = gdvusers.SelectedIndex;
       // gdvusers.SelectedRow.RowIndex;


        Session["selectid"] = gdvusers.DataKeys[index].Value.ToString();
        Session["name"] = (gdvusers.Rows[index].FindControl("Label11") as Label).Text;
        Response.Redirect("~/Follow.aspx");
    }
    protected void gdvusers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvusers.PageIndex = e.NewPageIndex;
        gdvusers.DataSource = m.users(p.user_id);
        gdvusers.DataBind();
       
      //  gdvusers.DataBind();
       
    }
    protected void Label5_Click(object sender, EventArgs e)
    {
        Session["f"] = 1;
        Response.Redirect("~/FollowList.aspx");
    }
    protected void Label6_Click(object sender, EventArgs e)
    {
        Session["f"] = 2;
        Response.Redirect("~/FollowList.aspx");
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
    protected void Label4_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MyProfile.aspx");
    }
    protected void lblname_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MyProfile.aspx");
    }
}
