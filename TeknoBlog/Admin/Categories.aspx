<%@ Page Title="Kategoriler" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="TeknoBlog.Admin.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminMainContent" runat="server">
    <div class="form-group row">
        <div class="col-md-10" style="margin-top: 10px;">
            <a class="btn btn-success" href="/Admin/Add/Category">Yeni Ekle</a>
        </div>
    </div>

    <table id="category-table" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Kategori Adı</th>
                <th>İşlemler</th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <th>Kategori Adı</th>
                <th>İşlemler</th>
            </tr>
        </tfoot>
        <tbody runat="server" id="Table_Body">
        </tbody>
    </table>

    <script type="text/javascript">
        $(document).ready(function () {
            $('table#category-table').DataTable();
        });
    </script>

</asp:Content>
