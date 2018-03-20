<%@ Control Language="C#" AutoEventWireup="true" CodeFile="derslistele.ascx.cs" Inherits="admin_moduller_derslistele" %>
<asp:SqlDataSource ID="rptDersDuzenle_db" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [tbl_Videolar]"></asp:SqlDataSource>
<table id="example2" class="table table-bordered table-hover">
<asp:Repeater ID="rptDersDuzenle" runat="server" DataSourceID="rptDersDuzenle_db" OnItemCommand="rptDersDuzenle_ItemCommand">
    <HeaderTemplate>
        <thead>
           <tr>
               <th>Ders Adı</th>
               <th>Kategori</th>
               <th>Sil</th>
               <th>Düzenle</th>
            </tr>
        </thead>
        <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%#Eval("VideoAdi") %></td>
            <td><%#Eval("KatID") %></td>
            <td><asp:Button ID="btnSil" runat="server" Text="Sil" CssClass="btn btn-primary" CommandName="sil" CommandArgument='<%#Eval("ID") %>' /></td>
            <td><a href="?v=ders&d=<%#Eval("ID") %>" class="btn btn-primary">Düzenle</a></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
    </FooterTemplate>
</asp:Repeater>
</table>
