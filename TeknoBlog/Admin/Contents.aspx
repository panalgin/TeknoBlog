<%@ Page Title="İçerikler" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="Contents.aspx.cs" Inherits="TeknoBlog.Admin.Contents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminMainContent" runat="server">

    <div class="form-group row">
        <div class="col-md-10" style="margin-top: 10px;">
            <a class="btn btn-success" href="/Admin/Add/Content">Yeni Ekle</a>
        </div>
    </div>

    <table id="content-table" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>İçerik Adı</th>
                <th>Başlatan</th>
                <th>Tarih</th>
                <th>Kategori</th>
                <th>İşlemler</th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <th>İçerik Adı</th>
                <th>Başlatan</th>
                <th>Tarih</th>
                <th>Kategori</th>
                <th>İşlemler</th>
            </tr>
        </tfoot>
        <tbody runat="server" id="Table_Body">
        </tbody>
    </table>

    <script type="text/javascript">
        $(document).ready(function () {
            $('table#content-table').DataTable();
        });
    </script>
</asp:Content>
