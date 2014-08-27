<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBank.Master" AutoEventWireup="true" CodeBehind="ValidateCard.aspx.cs" Inherits="WebApplication1.UC1.Validation.Validation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" runat="server">
   <%-- <script type="text/javascript">
        setTimeout(function() {
            window.location.href = "~/ValidationError.aspx";
        }, 1000);
    </script>--%>
    <p>
        Validating your ATM card...</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content2" runat="server">
</asp:Content>