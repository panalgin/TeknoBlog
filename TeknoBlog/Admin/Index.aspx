<%@ Page Title="Yönetim" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TeknoBlog.Admin.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="admin-nav">
        <ul>
            <li><a href="/Admin/Index">Anasayfa</a></li>
            <li><a href="/Admin/Posts">İçerik</a></li>
            <li><a href="/Admin/Users">Kullanıcılar</a></li>
            <li><a href="/Admin/Comments">Yorumlar</a></li>
            <li><a href="/Admin/Categories">Kategoriler</a></li>
            <li></li>
        </ul>
    </div>
    <div class="admin-con">
        İçerik buraya gelecek
    </div>
    <div class="spacer"></div>
</asp:Content>
