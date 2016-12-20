<%@ Page Title="Kullanıcı Düzenle" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="TeknoBlog.Admin.Edit._User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminMainContent" runat="server">
    <div class="container">
        <div class="info success" runat="server" id="Info" visible="false">Kullanıcı düzenlendi!</div>

        <div class="form-group">
            <span class="col-md-2 control-label">Email</span>
            <div class="col-md-10">
                <span class="text-muted" readonly="readonly" id="Email_Label" runat="server"></span>
            </div>
        </div>
        <div class="form-group">
            <span class="col-md-2 control-label">Yetki</span>
            <div class="col-md-10">
                <asp:CheckBox ID="IsAdministrator_Check" runat="server" Text="Administrator" />
            </div>
        </div>
        <br />
        <br />
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="Save_Button" runat="server" OnClick="Save_Button_Click" Text="Kaydet" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
