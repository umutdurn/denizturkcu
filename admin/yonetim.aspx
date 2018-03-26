<%@ Page Title="" Language="C#" MasterPageFile="~/admin/yonetim.master" AutoEventWireup="true" CodeFile="yonetim.aspx.cs" Inherits="admin_yonetim" %>

<%@ Register Src="~/admin/moduller/videokategori.ascx" TagPrefix="uc1" TagName="videokategori" %>
<%@ Register Src="~/admin/moduller/dersekle.ascx" TagPrefix="uc1" TagName="dersekle" %>
<%@ Register Src="~/admin/moduller/kategorilistele.ascx" TagPrefix="uc1" TagName="kategorilistele" %>
<%@ Register Src="~/admin/moduller/derslistele.ascx" TagPrefix="uc1" TagName="derslistele" %>
<%@ Register Src="~/admin/moduller/siparisler.ascx" TagPrefix="uc1" TagName="siparisler" %>
<%@ Register Src="~/admin/moduller/uyeler.ascx" TagPrefix="uc1" TagName="uyeler" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Kontrol Paneli
        <small>Kontrol Paneli</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Anasayfa</a></li>
        <li class="active">Kontrol Paneli</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">
      <!-- Main row -->
      <div class="row">
        <!-- Left col -->
        <section class="col-lg-12 connectedSortable">
          <!-- Chat box -->
          <div class="box box-success">
            <asp:Panel ID="AnaPanel" runat="server">
                <asp:Panel ID="pnlkategori" runat="server" Visible="false">
                    <div class="box-header">
                        <i class="fa fa-comments-o"></i>
                        <h3 class="box-title">Video Kategorisi Ekle</h3>
                    </div>
                    <div class="box-body">
                        <uc1:videokategori runat="server" ID="videokategori" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlders" runat="server" Visible="false">
                    <div class="box-header">
                        <i class="fa fa-comments-o"></i>
                        <h3 class="box-title">Ders Ekle</h3>
                    </div>
                    <div class="box-body">
                        <uc1:dersekle runat="server" ID="dersekle" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlkategoril" runat="server" Visible="false">
                    <div class="box-header">
                        <i class="fa fa-comments-o"></i>
                        <h3 class="box-title">Kategori Listesi</h3>
                    </div>
                    <div class="box-body">
                        <uc1:kategorilistele runat="server" ID="kategorilistele" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnldersl" runat="server" Visible="false">
                    <div class="box-header">
                        <i class="fa fa-comments-o"></i>
                        <h3 class="box-title">Ders Listesi</h3>
                    </div>
                    <div class="box-body">
                        <uc1:derslistele runat="server" ID="derslistele" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlsiparis" runat="server" Visible="false">
                    <div class="box-header">
                        <i class="fa fa-comments-o"></i>
                        <h3 class="box-title">Sipariş Listesi</h3>
                    </div>
                    <div class="box-body">
                        <uc1:siparisler runat="server" ID="siparisler" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnluyeler" runat="server" Visible="false">
                    <div class="box-header">
                        <i class="fa fa-comments-o"></i>
                        <h3 class="box-title">Üye Listesi</h3>
                    </div>
                    <div class="box-body">
                        <uc1:uyeler runat="server" ID="uyeler" />
                    </div>
                </asp:Panel>
            </asp:Panel>
          </div>
          <!-- /.box (chat box) -->

        </section>
        <!-- /.Left col -->
      </div>
      <!-- /.row (main row) -->

    </section>
</asp:Content>

