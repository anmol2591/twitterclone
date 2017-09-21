using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

public partial class LogIn : System.Web.UI.Page
{
    MyHandler m = new MyHandler();
    Person per = new Person();
    bool valid;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {


        DateTime dat = (DateTime.Now);
        try
        {
            m.CreateUser(txtname.Text, txtuser.Text, txtpass.Text, txtmail.Text, dat, true);
            Label4.Text = "Congratulations , Registration Complete";
            //Label4.ForeColor = "Green";
            Label4.Visible = true;

        }
        catch (Exception ex)
        {
            Label4.Text = "Username/Email Already Exists";
            Label4.Visible = true;
        }
        
            txtname.Text = "";
        txtuser.Text = "";
        txtpass.Text = "";
        txtmail.Text = "";
        txtconfirm.Text = "";
           
        }
    protected void btnlogin_Click(object sender, EventArgs e)
{

    try
    {
        per = m.login(txtemail.Text, txtpassword.Text);
        Session["per"] = per;
        Response.Redirect("~/LogIn2.aspx");
    }
    catch (Exception ex)
    {
        lblwrong.Visible = true;
    }
}
}
   
   
  
