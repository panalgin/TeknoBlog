<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="TeknoBlog._Category" %>
<asp:Content ID="NavBody" ContentPlaceHolderID="NavContent" runat="server">
    <header id="ust">
        <div class="alt">
            <div class="container">
                <ul class="list-inline ustmenu" id="cat_links" runat="server">
                </ul>
            </div>
        </div>
    </header>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ConHold" runat="server">
    </div>
</asp:Content>
