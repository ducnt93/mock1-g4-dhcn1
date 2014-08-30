<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBank.Master" AutoEventWireup="true" CodeBehind="ValidateCard.aspx.cs" Inherits="WebApplication1.UC1.Validation.Validation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        </ContentTemplate>

    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" OnLoad="Page_Load">
        <ProgressTemplate>
              Validating your ATM card...
        </ProgressTemplate>
       
    </asp:UpdateProgress>
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content2" runat="server">
</asp:Content>
