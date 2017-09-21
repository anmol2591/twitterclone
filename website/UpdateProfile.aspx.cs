using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

public partial class UpdateProfile : System.Web.UI.Page
{
    MyHandler m = new MyHandler();
    static Person p;
    Person per = new Person();
    string user;
   // static Person per;
    protected void Page_Load(object sender, EventArgs e)
    {
        per = Session["per"] as Person;
        user = per.user_id;
        txtemail.Text = per.email;
        txtuser.Text = per.user_id;
        p = Session["per"] as Person;
    }
    protected void imgupdate_Click(object sender, ImageClickEventArgs e)
    {
        //if (flag.Value != "false")
        //{
            
                m.UpdateProfile(user, txtname.Text, txtpass.Text);
                lblmessage.Text = "Congratulations!....your profile is updated.....";
                lblmessage.Visible = true;
                per.fullName = txtname.Text;
        //}
        //    else
        //    {
        //        lblmessage.Text = "Profile not updated";
        //    }
        }
    protected void btnsubmit_Click(object sender, EventArgs e)
{
         m.DeleteProfile(p.user_id);
        Response.Redirect("~/LogIn.aspx");
}
}
    
    //protected void imgdel_Click(object sender, ImageClickEventArgs e)
    //{
    //    Session["delete"] = per.user_id;
    //    Response.Redirect("~/Delete.aspx");
    //}
    
