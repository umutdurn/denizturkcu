<%@ Control Language="C#" AutoEventWireup="true" CodeFile="videokategori.ascx.cs" Inherits="admin_moduller_videogiris" %>
<div class="form-group">
    <asp:TextBox ID="txtVideoAdi" runat="server" placeholder="Kategori Adı" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <asp:TextBox ID="txtFiyat" runat="server" placeholder="Ürün Fiyatı" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <asp:TextBox ID="txtOnizlemeIframe" ValidateRequestMode="Disabled" runat="server" TextMode="MultiLine" placeholder="Önizleme İframe Kodu" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <asp:TextBox ID="txtKisaOzet" runat="server" TextMode="MultiLine" placeholder="Kısa Özet" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <asp:TextBox ID="txtDetayliOzet" runat="server" TextMode="MultiLine" placeholder="Detaylı Özet" CssClass="form-control"></asp:TextBox>
</div>
<asp:Button ID="btnKaydet" runat="server" Text="Dersi Kaydet" OnClick="btnKaydet_Click" CssClass="btn btn-primary" />
<asp:Label ID="lblUyari" runat="server" Text="" CssClass="text-red"></asp:Label>

