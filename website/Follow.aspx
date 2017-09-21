<%@ Page Title="" Language="C#" MasterPageFile="~/FollowPage.master" AutoEventWireup="true" CodeFile="Follow.aspx.cs" Inherits="Follow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label2" runat="server" Text="" ForeColor="White"></asp:Label>
    <asp:GridView ID="gdvtweets" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderWidth="1px" CellPadding="17" BorderStyle="None" Height="100px" Width="630px">
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
                <asp:TemplateField HeaderText="Tweets">
                    
                    <ItemTemplate>
                        <asp:Label ID="Label11" Text='<%# Eval("Message") %>' runat="server" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UserID">
                    <ItemTemplate>
                        <asp:Label ID="Label1" Text='<%# Eval("user_id")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Created">
                    <ItemTemplate>
                        <asp:Label ID="Label12" Text='<%# Eval("Created")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField>--%>
                    <%--<ItemTemplate>
                        <asp:Label ID="Label12" Text='<%# Eval("tweet_id")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                 
            </Columns>

         <FooterStyle BackColor="White" ForeColor="#000066" />
         <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
         <RowStyle ForeColor="#000066" />
         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
         <SortedAscendingCellStyle BackColor="#F1F1F1" />
         <SortedAscendingHeaderStyle BackColor="#007DBB" />
         <SortedDescendingCellStyle BackColor="#CAC9C9" />
         <SortedDescendingHeaderStyle BackColor="#00547E" />

    </asp:GridView>
        </asp:Content>

