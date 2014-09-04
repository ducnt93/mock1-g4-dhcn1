<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcDisplayInfomationAccount.ascx.cs" Inherits="WebApplication1.UC5.CashTransfer.UcController.InfomationAccount" %>

<div class="col-md-12">
    <h4 align="center">Receiver Information</h4>
    <table class="table">
            <tr>
                <td>Account Receiver Name: </td>
                <td><asp:Label runat="server" ID="lblAccountName" OnLoad="LoadName"/></td>
            </tr>
            <tr>
                <td>Account Receiver ID: </td>
                <td><asp:Label runat="server" ID="lblAccountID" OnLoad="LoadID"/></td>
            </tr>
        </table>
    <div class="col-md-6">
        <h4 align="left">Press accept to continue, Reject to re-enter account</h4>
    </div>
    <div class="col-md-5">
        <div class="col-md-4 col-lg-offset-8 col">
            <input type="text" class="btn btn-primary btn1" value="Accept" />
        </div>
        <div class="col-md-4 col-lg-offset-8 col">
            <input type="text" class="btn btn-primary btn1" value="Reject" />
        </div>
    </div>
</div>
