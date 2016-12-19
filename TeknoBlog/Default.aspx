<%@ Page Title="Anasayfa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TeknoBlog._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <ul class="bxslider">
      <li><img src="/Content/Images/s1.jpg" /></li>
      <li><img src="/Content/Images/s2.jpg" /></li>
      <li><img src="/Content/Images/s3.jpg" /></li>
      <li><img src="/Content/Images/s4.jpg" /></li>
    </ul>
    <script type="text/javascript">
        $(document).ready(function () {
            $("ul.bxslider li img").show();
            $('.bxslider').bxSlider({
                auto: true,
            });
        });
    </script>
    <div id="ConHold" runat="server">

    </div>

</asp:Content>
