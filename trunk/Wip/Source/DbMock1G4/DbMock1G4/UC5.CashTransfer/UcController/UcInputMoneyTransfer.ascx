<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcInputMoneyTransfer.ascx.cs" Inherits="WebApplication1.UC5.CashTransfer.UcController.AmountTransfer" %>
<div class="col-md-12" style="padding-top: 50px;">
    <h4 align="center">Transfer Cash Amount</h4>        
<table align="center">
            
            <tr>
                <td><asp:Label runat="server" Text="Amount: "></asp:Label></td>
                <td><asp:TextBox runat="server" ID="txtAmount"  CssClass="form-control" TextMode="Number" Width="320px"></asp:TextBox></td>
            </tr>
        </table>
<h5 align="center">Press enter to continue</h5>
</div>

