<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcDisplayAccountReceiveAndAmount.ascx.cs" Inherits="WebApplication1.UC5.CashTransfer.UcController.UcDisplayAccountReceiveAndAmount" %>
<div class="col-md-12">
    <h4 align="center">Please enter account number work to transfer</h4>
        <table class="table">
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
    <table>
        <tr>
            <td><h4 align="left" style="width: 346px">Press accept to continue, Reject to re-enter amount</h4></td>
            <td>
                <div class="col-md-4 col-lg-offset-8 col">
                    <input type="text" class="btn btn-success btn1" value="Accept" />
                </div>
                <div class="col-md-4 col-lg-offset-8 col paddingtop">
                    <input type="text" class="btn btn-success btn1" value="Reject" />
                </div>
            </td>
        </tr>
    </table>
</div>
