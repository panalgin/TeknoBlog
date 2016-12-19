<%@ Page Title="İçerik Ekle" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="Content.aspx.cs" Inherits="TeknoBlog.Admin.Add._Content" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminMainContent" runat="server">
    <div class="form-group row">
        <asp:Label runat="server" AssociatedControlID="Name_Box" CssClass="col-md-2 control-label">Başlık</asp:Label>
        <div class="col-sm-4">
            <asp:TextBox runat="server" ID="Name_Box" CssClass="form-control input-medium" />
            <asp:CustomValidator ID="Validator" ControlToValidate="Name_Box" OnServerValidate="Validator_ServerValidate" runat="server" Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
        </div>
    </div>
    <div class="form-group row">
        <asp:Label runat="server" AssociatedControlID="Category_Combo" CssClass="col-md-2 control-label">Kategori</asp:Label>
        <div class="col-sm-4">
            <asp:DropDownList runat="server" ID="Category_Combo" CssClass="form-control input-medium">
            </asp:DropDownList>
        </div>
    </div>
    <div class="spacer"></div>
    <script type="text/javascript">
        tinymce.init({
            selector: 'textarea',
            language: 'tr_TR',
            height: 500,
            menubar: false,
            forced_root_block: "",
            force_br_newlines: true,
            force_p_newlines: false,

            plugins: [
              'advlist autolink lists link image charmap print preview anchor',
              'searchreplace visualblocks code fullscreen',
              'insertdatetime media table contextmenu paste code'
            ],
            toolbar: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image'
        });
    </script>
    <textarea></textarea>
    <div class="form-group row">
        <div class="col-md-10" style="margin-top: 10px;">
            <asp:Button ID="Save_Button" runat="server" Text="Ekle" CssClass="btn btn-default" OnClick="Save_Button_Click" />
        </div>
    </div>
    <br />
</asp:Content>
