<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UpdateProfile.aspx.cs" Inherits="UpdateProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        
  <%-- <script type ="text/javascript">
       function check() {
           var x = document.getElementById("txtname").value.trim();
           var y = document.getElementById("txtpass").value.trim();
           var z = document.getElementById("txtconfirm").value.trim();
           if (x == "") {
               alert("Full name cannot be empty");
               document.getElementById("flag").value = "false";
               return false;
           }
           else if (y == "") {
               alert("Password cannot be empty");
               document.getElementById("flag").value = "false";
               return false;
           }
           else if (z == "") {
               alert("Password cannot be empty");
               document.getElementById("flag").value = "false";
               return false;
           }
           else if (y != z) {
               alert("Please confirm the password");
               document.getElementById("flag").value = "false";
               return false;
           }
           return true;
       }
   </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <asp:Label ID="lblmessage" BackColor="Black" ForeColor="Wheat" runat="server" Text="" Visible="false"></asp:Label>
   <br />
    <br />
    <br />
    &nbsp&nbsp&nbsp&nbsp&nbsp <asp:Label ID="lblname" ForeColor="red" runat="server" CssClass="label" Text="Full Name:"></asp:Label>
   &nbsp&nbsp&nbsp&nbsp&nbsp
         <asp:TextBox ID="txtname" CssClass="textbox" runat="server" ClientIDMode="Static"></asp:TextBox><br /><br />

      &nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="lblemail" ForeColor="red" runat="server" CssClass="label"  Text="Email:"></asp:Label>
   &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
         <asp:TextBox ID="txtemail" CssClass="textbox" runat="server" ReadOnly="True" ClientIDMode="Static"></asp:TextBox><br /><br />
     &nbsp&nbsp&nbsp&nbsp&nbsp <asp:Label ID="lbluser" ForeColor="red" runat="server" CssClass="label"  Text="User Name:"></asp:Label>
    &nbsp&nbsp&nbsp&nbsp
        <asp:TextBox ID="txtuser" CssClass="textbox" runat="server" ReadOnly="True" ClientIDMode="Static"></asp:TextBox><br /><br />
     &nbsp&nbsp&nbsp&nbsp&nbsp <asp:Label ID="lblpass" ForeColor="red" runat="server" CssClass="label"  Text="Password:"></asp:Label>
    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:TextBox ID="txtpass" CssClass="textbox" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox><br /><br />
    
    &nbsp&nbsp&nbsp&nbsp&nbsp
       <br />
        <asp:ImageButton ID="imgupdate" CssClass="update" runat="server" src="Images/update.jpg" Height="40px" Width="80px"  OnClick="imgupdate_Click"  ClientIDMode="Static" />
    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
    <%-- <input type="hidden" name="flag" id="flag" runat="server" />--%>
      <asp:Panel ID="Panel1" runat="server" CssClass="popuppanel" BackColor="LightPink" Height="500px" Width="400px">
                 <asp:ImageButton ID="imgclose" runat="server" src="/Images/close.png" Height="30px" Width="40px" />
                 <br />
                 <br />
                     &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src="Images/delete.png" width="350px" height="300px" />
                <br />
                 <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:Button ID="btnsubmit" runat="server" Text="Delete" Height="50px" Width="150px" OnClick="btnsubmit_Click"  />
                </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DropShadow="true" BackgroundCssClass="popup" PopupControlID="Panel1" TargetControlID="imgdel" CancelControlID="imgclose"></asp:ModalPopupExtender>
    <asp:ImageButton ID="imgdel" runat="server" src="Images/del.jpg" Height="40px" Width="80px"/> 
</asp:Content>

