<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="TeknoBlog.Admin.Edit._Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminMainContent" runat="server">
    <div class="info success" runat="server" id="Info" visible="false">Kategori düzenlendi!</div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Name_Box" CssClass="col-md-2 control-label">Kategori Adı</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="Name_Box" CssClass="form-control" />
            <asp:CustomValidator ID="Validator" ControlToValidate="Name_Box" OnServerValidate="Validator_ServerValidate" runat="server" Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
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
