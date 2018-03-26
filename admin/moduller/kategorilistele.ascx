<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kategorilistele.ascx.cs" Inherits="admin_moduller_kategorilistele" %>
<asp:TextBox ID="txtArama" runat="server" placeholder="Kullanıcı adı ara"></asp:TextBox>
<asp:SqlDataSource ID="rptKategoriDuzenle_db" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [tbl_Kategoriler]"></asp:SqlDataSource>
<table id="example2" class="table table-bordered table-hover">
<asp:Repeater ID="rptKategoriDuzenle" runat="server" DataSourceID="rptKategoriDuzenle_db" OnItemCommand="rptKategoriDuzenle_ItemCommand">
    <HeaderTemplate>
        <thead>
           <tr>
               <th>Kategori Adı</th>
               <th>Eklenme Tarihi</th>
               <th>Fiyat</th>
               <th>Sil</th>
               <th>Düzenle</th>
            </tr>
        </thead>
        <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%#Eval("VideoAdi") %></td>
            <td><%#Eval("Tarih") %></td>
            <td><%#Eval("Fiyat") %> TL</td>
            <td><asp:Button ID="btnSil" runat="server" Text="Sil" CssClass="btn btn-primary" CommandName="sil" CommandArgument='<%#Eval("ID") %>' /></td>
            <td><a href="?v=kategori&d=<%#Eval("ID") %>" class="btn btn-primary">Düzenle</a></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
    </FooterTemplate>
</asp:Repeater>
</table>
