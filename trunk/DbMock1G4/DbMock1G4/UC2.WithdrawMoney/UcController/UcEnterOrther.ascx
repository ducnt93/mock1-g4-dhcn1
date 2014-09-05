<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcEnterOrther.ascx.cs" Inherits="WebApplication1.UC2.WithdrawMoney.UcController.EnterOrther" %>
<div class="col-md-12">
    <div class="col-md-8 col-lg-offset-4">
        <asp:TextBox runat="server" ID="txtEnterCash" CssClass="form-control" TextMode="Number"></asp:TextBox>
    </div>
    <div class="col-md-4 col-lg-offset-8 col paddingtop1">

        <input type="text" class="btn btn-success btn1" value="OK" />
    </div>
    <div class="col-md-4 col-lg-offset-8 col paddingtop1">
        <input type="text" class="btn btn-success btn1" value="Cancel" />

    </div>
</div>
