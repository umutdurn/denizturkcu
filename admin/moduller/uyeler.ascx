<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uyeler.ascx.cs" Inherits="admin_moduller_uyeler" %>
<asp:SqlDataSource ID="rptUyeler_db" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [AspNetUsers]"></asp:SqlDataSource>
<table id="example2" class="table table-bordered table-hover">
<asp:Repeater ID="rptUyeler" runat="server" DataSourceID="rptUyeler_db">
    <HeaderTemplate>
        <thead>
           <tr>
               <th>Kullanıcı Adı</th>
               <th>Email</th>
               <th>Düzenle</th>
               <th>Sil</th>
            </tr>
        </thead>
        <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%#Eval("UserName") %></td>
            <td><%#Eval("Email") %></td>
            <td>
                <a href="#" class="btn btn-primary">Düzenle</a>
            </td>
            <td>
                <asp:Button ID="btnSil" runat="server" Text="Sil" CssClass="btn btn-primary" />
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
    </FooterTemplate>
</asp:Repeater>
</table>