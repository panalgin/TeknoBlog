<%@ Page Title="Yorumlar" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="TeknoBlog.Admin.Comments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminMainContent" runat="server">
    <table id="comment-table" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Yorum Sahibi</th>
                <th>Tarih</th>
                <th>Konu</th>
                <th>Mesaj</th>
                <th>İşlemler</th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <th>Yorum Sahibi</th>
                <th>Tarih</th>
                <th>Konu</th>
                <th>Mesaj</th>
                <th>İşlemler</th>
            </tr>
        </tfoot>
        <tbody runat="server" id="Table_Body">
        </tbody>
    </table>

    <script type="text/javascript">
        $(document).ready(function () {
            $('table#comment-table').DataTable();
        });
    </script>
</asp:Content>
