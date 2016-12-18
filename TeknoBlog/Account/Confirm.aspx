<%@ Page Title="Hesap Doğrulaması" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="TeknoBlog.Account.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p>
                Hesabınızı doğrulattığınız için teşekkürler. <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">Buraya</asp:HyperLink> tıklayarak giriş yapabilirsiniz.             
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <p class="text-danger">
                Bir problem oluştu.
            </p>
        </asp:PlaceHolder>
    </div>
</asp:Content>
