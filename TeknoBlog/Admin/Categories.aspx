<%@ Page Title="Kategoriler" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="TeknoBlog.Admin.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminMainContent" runat="server">
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
