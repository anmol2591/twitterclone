<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label3" runat="server" Text="" ForeColor="White" BackColor="Maroon" Height="54px" Font-Size="XX-Large"></asp:Label>
   <br />
     <asp:GridView ID="gdvsearch" runat="server" DataKeyNames="user_id" AutoGenerateSelectButton="True"  BackColor="White" BorderColor="#CC9966" BorderWidth="1px" CellPadding="17" BorderStyle="None" Height="100px" Width="630px" AutoGenerateColumns="False" OnSelectedIndexChanged="gdvsearch_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
         <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" BorderColor="#660033" BorderStyle="None" ForeColor="#FFFFCC" Height="50px" Width="500px" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFF99" ForeColor="#330099" Height="50px" />
        <SelectedRowStyle BackColor="#FFCC66" ForeColor="#663399" Font-Bold="True" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
        <Columns>
                <asp:TemplateField HeaderText="Full Name">
                    
                    <ItemTemplate>
                        <asp:Label ID="Label11" Text='<%# Eval("FullName") %>' runat="server" ></asp:Label>
                    </ItemTemplate>
                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UserName">
                    <ItemTemplate>
                        <asp:Label ID="Label1" Text='<%# Eval("user_id")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label ID="Label12" Text='<%# Eval("Email")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField>--%>
                    <%--<ItemTemplate>
                        <asp:Label ID="Label12" Text='<%# Eval("tweet_id")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                 
            </Columns>
</asp:GridView>
   
</asp:Content>

