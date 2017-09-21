<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn2.aspx.cs" Inherits="LogIn2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="LogIn2.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="header" >
        
        <div class ="innerheader1">
        <img height="95px" width="300px;"src="/Images/twitter1.jpg" /> ; 
            
        </div>
        <div class="innerheader2">
            

        </div>
        <div class="innerheader3">
           
        </div>
      
        
        
        
    </div>
        <div class="middle">
           <p><h1>Welcome to Twitter</h1></p> 
            <br />
            <br />
            <br />
            <p style="text-align:center;">Connect with your friends — and other<br />
                fascinating people. Get in-the-moment updates on the things that<br />
                 interest you. And watch events unfold, in real time, from every angle.</p>

        </div>
   <div class="bottom">
       
       <asp:ImageButton ID="ImageButton1" runat="server" src="/Images/followme.png" Height="106px" Width="157px" style="margin-left: 0px" OnClick="ImageButton1_Click" /> 
       
           </div>
    </form>
</body>
</html>
