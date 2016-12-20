<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="TeknoBlog.View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 id="Caption" runat="server"></h1>
        <div id="Content" runat="server"></div>

        <hr />
        <div id="Comments" runat="server">

        </div>
        <hr />
        <asp:LoginView ID="Login_View" runat="server">
            <AnonymousTemplate>
                <div class="row">
                    Yorum yapabilmeniz için giriş yapmalısınız.
                </div>
            </AnonymousTemplate>
            <LoggedInTemplate>
                <div class="row">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="Comment_Box" CssClass="col-sm-1 control-label" Text="Yorumunuz" runat="server"></asp:Label>
                        <div class="col-sm-4" style="margin-left: 12px">
                            <asp:TextBox ID="Comment_Box" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Comment_Box" CssClass="text-danger" ErrorMessage="Yorum alanı gereklidir." />
                        </div>
                    </div>
                </div>
                <div class="row comment">
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-2" style="margin-left: 95px">
                            <asp:Button id="Submit_Comment" CssClass="btn btn-success btn-circle text-uppercase" runat="server" OnClick="Submit_Comment_Click" Text="Yorum Yap"/>
                        </div>
                    </div>
                </div>
            </LoggedInTemplate>
        </asp:LoginView>
    </div>
</asp:Content>
