<%@ Page Title="Kullanıcı Ekle" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="TeknoBlog.Admin.Add._User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminMainContent" runat="server">
    <div class="container">
        <div class="info success" runat="server" id="Info" visible="false">Kullanıcı eklendi!</div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="Email alanı gereklidir." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Şifre</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="Şifre alanı gereklidir." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Şifre [Tekrar]</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Tekrarlama alanı gereklidir." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Şifreniz ve tekrarlama alanı birbiriyle uyuşmuyor." />
            </div>
        </div>
        <br />
        <br />
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="Create_User_Button" runat="server" OnClick="Create_User_Button_Click" Text="Ekle" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
