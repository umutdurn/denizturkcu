<%@ Control Language="C#" AutoEventWireup="true" CodeFile="siparisler.ascx.cs" Inherits="admin_moduller_siparisler" %>

<asp:SqlDataSource ID="rptSiparisListe_db" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [tbl_Siparisler]"></asp:SqlDataSource>
<table id="example2" class="table table-bordered table-hover">
<asp:Repeater ID="rptSiparisListe" runat="server" DataSourceID="rptSiparisListe_db" OnItemCommand="rptSiparisListe_ItemCommand">
    <HeaderTemplate>
        <thead>
           <tr>
               <th>Kullanıcı Adı</th>
               <th>Fiyat</th>
               <th>Sipariş Tarihi</th>
               <th>Durum</th>
               <th>Detay</th>
            </tr>
        </thead>
        <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%#Eval("Nick") %></td>
            <td><%#Eval("ToplamFiyat") %></td>
            <td><%#Eval("Tarih") %></td>
            <td><%#Eval("Durum").ToString() == "1" ? "Aktif" : "Pasif" %></td>
            <td>
                <asp:Button ID="btnGoster" runat="server" Text="Detay" CssClass="btn btn-primary" CommandName="goster" CommandArgument='<%#Eval("ID") %>' />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="pnlGizli" Visible="false" runat="server" CssClass="sipDetay">
                    <span>Satın Alınan Videolar</span>
                    <%#SiparisDetay(Eval("Sepet").ToString()) %>
                </asp:Panel>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
    </FooterTemplate>
</asp:Repeater>
</table>