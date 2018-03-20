<%@ Control Language="C#" AutoEventWireup="true" CodeFile="dersekle.ascx.cs" Inherits="admin_moduller_dersekle" %>
<div class="form-group">
    <asp:TextBox ID="txtVideoAdi" runat="server" CssClass="form-control" placeholder="Video Adı" ></asp:TextBox>
</div>
<div class="form-group">
    <asp:SqlDataSource ID="dropKategoriler_db" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [tbl_Kategoriler]"></asp:SqlDataSource>
    <asp:DropDownList ID="dropKategoriler" runat="server" CssClass="form-control" DataSourceID="dropKategoriler_db" DataTextField="VideoAdi" DataValueField="ID"></asp:DropDownList>
</div>
<div class="form-group">
    <asp:TextBox ID="txtVideoAciklamasi" runat="server" CssClass="form-control" placeholder="Video Açıklaması" TextMode="MultiLine" ></asp:TextBox>
</div>
<div class="form-group">
    <asp:TextBox ID="txtVideoIframe" runat="server" CssClass="form-control" placeholder="İframe"  TextMode="MultiLine" ValidateRequestMode="Disabled" ></asp:TextBox>
</div>
<asp:Button ID="btnKaydet" runat="server" Text="Dersi Kaydet" CssClass="btn btn-primary" OnClick="btnKaydet_Click" />
<asp:Label ID="lblUyari" runat="server" Text="" CssClass="text-red"></asp:Label>

