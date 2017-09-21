<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="LogIn.css" rel="stylesheet" />
    <title></title>
    <script src="Scripts/jquery-2.1.1.js"></script>
    <script src="Scripts/jquery.validate.js"></script>
    <script type="text/javascript">
        jQuery.extend(jQuery.validator.messages, {
            email: "Incorrect Email address",
            equalTo: "Password do not match",
            text: "Enter only alphabetic characters",
            required: "*"
        });
        $(function () {
            $("#btnlogin").click(function() {
                $("#form1").validate ({
                    rules: {
                        <%=txtemail.UniqueID %>:{required:"*",email:true},
                        <%=txtpassword.UniqueID %>:{required:"*"},
                       
                       
                    }
                });
            });
         });
        $(function () {
            $("#ImageButton1").click(function() {
                $("#form1").validate ({
                    rules: {
                        <%=txtname.UniqueID %>:{required:true},
                        <%=txtuser.UniqueID %>:{required:true},
                        <%=txtmail.UniqueID %>:{required:true,email:true},
                        <%=txtpass.UniqueID %>:{required:true},
                        <%=txtconfirm.UniqueID %>:{required:true,equalTo:"#txtpass"}
                       
                    }
                });
            });
        });
       
    </script>
</head>
<body>

    <form id="form1" runat="server">
        <div class="header">

            <div class="innerheader1">
                <img height="95px" width="300px;" src="Images/twitter1.jpg" /> 

            </div>
            <div class="innerheader2">
            </div>
            <div class="innerheader3">
                <asp:Label ID="lblemail" runat="server" Text="Email:"></asp:Label>
                <asp:TextBox ID="txtemail" CssClass="textbox" runat="server" placeholder="Enter your Email" AutoCompleteType="None" TextMode="SingleLine"></asp:TextBox>
                <asp:Label ID="lblpassword" CssClass="label" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="txtpassword" CssClass="textbox" runat="server" placeholder="Enter your Password" AutoCompleteType="None" ForeColor="Black" TextMode="Password"></asp:TextBox>
               <asp:Button ID="btnlogin" runat="server" ForeColor="Red" Text="Login" OnClick="btnlogin_Click" /><br />
                  <asp:Label ID="lblwrong" runat="server" Text="User does not exist" Visible="false"></asp:Label>
                
                <br />
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            
             <asp:LinkButton ID="lb1" CssClass="linkbutton" ForeColor="Red" runat="server">Forgot Password</asp:LinkButton>
            </div>



        </div>
        <div class="header1" style="margin-top: -40px;">
            <%-- <div style="height:20px";>

            </div>--%>
            <div class="middle" style="margin-top: 40px; margin-left: 40px; margin-right: 40px;">
                <div class="middleleft">
                    <img height="500px" width="600px" src="Images/twitter-526x329%20(3).png" />
                </div>
                <div class="middleright">
                    <%-- <asp:Label ID="Label1" runat="server" Text="New to Twitter :" CssClass="class"></asp:Label>--%>
                    <asp:Panel ID="Panel1" BorderStyle="Groove" BackColor="WhiteSmoke" BorderWidth="10px" BorderColor="WindowFrame" runat="server">
                        New to Twitter
                   <table class="table">
                       <tr>
                           <td>
                               <asp:Label ID="lblname" runat="server" Text="Full Name:"></asp:Label>
                           </td>
                           <td>
                               <asp:TextBox ID="txtname" placeholder="Full Name" runat="server" CssClass="textbox"></asp:TextBox>
                           </td>
                       </tr>
                       <caption>
                           <br />
                           <br />
                           <tr>
                               <td>
                                   <asp:Label ID="lbluser" runat="server" Text="Username:"></asp:Label>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtuser" runat="server" CssClass="textbox" placeholder="User Name"></asp:TextBox>
                               </td>
                               <td>
                                   <asp:Label ID="Label1" runat="server" Text="Username/Email already exists" Visible="false"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:Label ID="lblmail" runat="server" Text="Email:"></asp:Label>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtmail" runat="server" CssClass="textbox" placeholder="Email"></asp:TextBox>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:Label ID="lblpass" runat="server" Text="Password:"></asp:Label>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtpass" runat="server" CssClass="textbox" placeholder="Password" TextMode="Password"></asp:TextBox>
                               </td>
                               <td>
                                   <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:Label ID="lblconfirm" runat="server" Text="Confirm Password:"></asp:Label>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtconfirm" runat="server" CssClass="textbox" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                               </td>
                           </tr>
                            

                       </caption>

                       
                             
                          
                   </table>
                          <asp:Label ID="Label4" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="image" ImageUrl="Images/register-here-button.gif" OnClientClick="checkagain()" OnClick="ImageButton1_Click" />
                    </asp:Panel>
                    <div class="middlebottem">
                       
                    </div>
                </div>
            </div>


        </div>
        <%-- <hr class="horizontal" />--%>
        <%-- <div class="header2">

        </div>--%>
    </form>
</body>
</html>
