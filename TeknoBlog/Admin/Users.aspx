<%@ Page Title="Kullanıcılar" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="TeknoBlog.Admin.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminMainContent" runat="server">
    <div class="form-group row">
        <div class="col-md-10" style="margin-top: 10px;">
            <a class="btn btn-success" href="/Admin/Add/User">Yeni Ekle</a>
        </div>
    </div>
    <table id="user-table" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Kullanıcı Adı</th>
                <th>Yetkiler</th>
                <th>İşlemler</th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <th>Kullanıcı Adı</th>
                <th>Yetkiler</th>
                <th>İşlemler</th>
            </tr>
        </tfoot>
        <tbody runat="server" id="Table_Body">
        </tbody>
    </table>

    <script type="text/javascript">
        $(document).ready(function () {
            $('table#user-table').DataTable();
        });
    </script>
</asp:Content>
