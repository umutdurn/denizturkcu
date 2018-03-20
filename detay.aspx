<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="detay.aspx.cs" Inherits="detay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Repeater ID="rptListeleme" runat="server" OnItemCommand="rptListeleme_ItemCommand">
        <HeaderTemplate>
            <div class="urunler">
        </HeaderTemplate>
        <ItemTemplate>
               <h3 class="urunAdi"><%#Eval("VideoAdi") %></h3>
                    <%#Eval("Foto") %><br />
                    <span class="fiyat">₺<%#Eval("Fiyat") %></span><span class="aciklama"><%#Eval("VideoAciklamasi") %></span><asp:Button ID="btnSatinAl" runat="server" Text="SatinAl" CommandName="satinal" CommandArgument='<%#Eval("ID") %>' />
                    <div class="clear"></div>
        </ItemTemplate>
        <FooterTemplate>
                <div class="clear"></div>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

