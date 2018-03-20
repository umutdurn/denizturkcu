<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="sepet.aspx.cs" Inherits="sepet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Repeater ID="rptSepet" runat="server" OnItemCommand="rptSepet_ItemCommand">
        <HeaderTemplate>
            <table style="width:100%;">
                <tr>
                    <td><strong>Video Adı</strong</td>
                    <td><strong>Açıklaması</strong</td>
                    <td><strong>Fiyatı</strong</td>
                    <td><strong>Sil</strong></td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td><%#Eval("VideoAdi") %></td>
                    <td><%#Eval("VideoKisaAciklamasi") %></td>
                    <td><%#Eval("Fiyat") %></td>
                    <td>
                        <asp:Button ID="btnSil" runat="server" Text="Sil" CommandName="urunsil" CommandArgument='<%#Eval("ID") %>'  />
                    </td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Button ID="btnIleri" runat="server" Text="Ödemeye Geç" OnClick="btnIleri_Click" />
    <asp:Panel ID="pnlOdeme" runat="server" Visible="false">
        <asp:Button ID="btnKrediKarti" runat="server" Text="Kredi Kartı ile Öde" OnClick="btnKrediKarti_Click" />
        <div id="iyzipay-checkout-form" class="popup"></div>
    </asp:Panel>
</asp:Content>

