<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcInputAccountReceive.ascx.cs"  Inherits="WebApplication1.UC5.CashTransfer.UcController.AccountInput" %>
<div class="col-md-12">
        <h4 align="center">Please enter account number work to transfer</h4>
        <table align="center" class="table">
            <tr>
                <td><asp:Label runat="server" Text="Account Transfer Name"></asp:Label></td>
                <td><asp:Label runat="server" ID="lblAccTransferName" OnLoad="LoadID"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label runat="server" Text="Account Transfer ID"></asp:Label></td>
                <td><asp:Label runat="server" ID="lblAccTransferID" OnLoad="LoadName"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label runat="server" Text="Account Receive ID"></asp:Label></td>
                <td><asp:TextBox runat="server" id="txtAccountReceiveID"/></td>
            </tr>
        </table>
        <h4 align="center">Press enter to submit, cancel to quit</h4>
</div>
