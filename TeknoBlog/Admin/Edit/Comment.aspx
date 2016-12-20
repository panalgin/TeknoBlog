<%@ Page Title="Yorum Düzenle" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="Comment.aspx.cs" Inherits="TeknoBlog.Admin.Edit._Comment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminMainContent" runat="server">
     <div class="info success" runat="server" id="Info" visible="false">Yorum düzenlendi!</div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Data_Box" CssClass="col-md-2 control-label">Yorum</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="Data_Box" TextMode="MultiLine" CssClass="form-control" />

        </div>
    </div>
    <br />
    <br />
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <asp:Button ID="Save_Button" runat="server" Text="Kaydet" CssClass="btn btn-default" OnClick="Save_Button_Click" />
        </div>
    </div>
</asp:Content>
