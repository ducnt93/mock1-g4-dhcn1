<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcDisplayAccountReceiveAndAmount.ascx.cs" Inherits="WebApplication1.UC5.CashTransfer.UcController.UcDisplayAccountReceiveAndAmount" %>
<div class="col-md-12">
    <div class="col-md-8 col-lg-offset-4">
        <table>
            <tr>
                <td>Account Receive Name</td>
                <td><asp:Label runat="server" ID="lblAccountName" OnLoad="LoadName"/></td>
            </tr>
            <tr>
                <td>Account Receive ID</td>
                <td><asp:Label runat="server" ID="lblAccountID" OnLoad="LoadID"/></td>
            </tr>
            <tr>
                <td>Amount</td>
                <td><asp:Label runat="server" ID="lblAmount" OnLoad="LoadAmount"/></td>
            </tr>
        </table>
        <h5></h5>
    </div>
    <div class="col-md-4 col-lg-offset-8 col">
        <input type="text" class="btn btn-primary btn1" value="Accept" />
    </div>
    <div class="col-md-4 col-lg-offset-8 col">
        <input type="text" class="btn btn-primary btn1" value="Reject" />
    </div>
</div>
