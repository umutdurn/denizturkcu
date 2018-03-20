<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:SqlDataSource ID="rptListeleme_DB" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [tbl_Kategoriler]"></asp:SqlDataSource>
    <asp:Repeater ID="rptListeleme" runat="server" DataSourceID="rptListeleme_DB">
        <HeaderTemplate>
            <div class="urunler">
        </HeaderTemplate>
        <ItemTemplate>
                <div class="urun">
                    <h3><%#Eval("VideoAdi") %></h3>
                    <%#Eval("Foto") %><br />
                    <span class="fiyat">₺<%#Eval("Fiyat") %></span>
                    <span class="aciklama"><%#Eval("VideoKisaAciklamasi") %></span>
                    <a href="#" class="btnEkle sol yarimdv">Sepete Ekle</a>
                    <a href="detay/<%#Eval("URL") %>" class="btnDetay sag yarimdv">Detaylı İncele</a>
                    <div class="clear"></div>
                </div>
        </ItemTemplate>
        <FooterTemplate>
                <div class="clear"></div>
            </div>
        </FooterTemplate>
    </asp:Repeater>
    
</asp:Content>
