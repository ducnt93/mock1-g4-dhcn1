﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainATM.aspx.cs" Inherits="WebApplication1.MainATM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/css/bootstrap.css" rel="stylesheet" />
    <link href="Content/Style.css" rel="stylesheet" />
    <style type="text/css">
        #main {
            padding-top: 100px;
            background-color: aliceblue;
        }
    </style>
</head>
<body class="panel-body" id="main">

    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-2">
                        <table class="table">
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="btnWithdraw" CssClass="btn btn-primary col btn1" Text="Withdraw" OnClick="btnWithdraw_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   <asp:Button runat="server" ID="Button2" CssClass="btn btn-primary col btn1" Text="Check Balance" OnClick="btnWithdraw_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink runat="server" ID="hyperLinkTransfer" CssClass="btn btn-primary col btn1">Transfer</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-md-8 table-bordered">
                        <div class="col-md-12">
                            <div class="col-md-3">
                                <img src="../Content/images/nganhang2.jpg" class="img-thumbnail" />
                            </div>
                            <div class="col-md-9">
                                <h3>ABC Bank @ ATM</h3>
                                <h4>Please select a transaction</h4>
                                <p>
                                    Wellcom to ABC Bank @ ATM.
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <table class="table">
                            <tr>
                                <td>
                                    <asp:HyperLink runat="server" ID="hyperLinkViewHistory" CssClass="btn btn-primary col btn1">View History</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink runat="server" ID="hyperLinkChangePin" CssClass="btn btn-primary col btn1">Change PIN</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="btnExit" CssClass="btn btn-primary col btn1" Text="Exit" OnClick="btnExit_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="col-md-12 table-bordered">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="col-md-4 col-md-offset-4">
                                <table class="table table-bordered">
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum1" CssClass="btn btn-default" Text="1" OnClick="btnNum1_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum2" CssClass="btn btn-default" Text="2" OnClick="btnNum2_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum3" CssClass="btn btn-default" Text="3" OnClick="btnNum3_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-default" Text="Cancel" OnClick="btnCancel_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum4" CssClass="btn btn-default" Text="4" OnClick="btnNum4_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum5" CssClass="btn btn-default" Text="5" OnClick="btnNum5_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum6" CssClass="btn btn-default" Text="6" OnClick="btnNum6_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnClear" CssClass="btn btn-default" Text="Clear" OnClick="btnClear_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum7" CssClass="btn btn-default" Text="7" OnClick="btnNum7_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum8" CssClass="btn btn-default" Text="8" OnClick="btnNum8_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum9" CssClass="btn btn-default" Text="9" OnClick="btnNum9_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnEnter" CssClass="btn btn-default" Text="Enter" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btnDot" CssClass="btn btn-default" Text="." OnClick="btnDot_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum0" CssClass="btn btn-default" Text="0" OnClick="btnNum0_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnComma" CssClass="btn btn-default" Text="," OnClick="btnComma_Click" /></td>
                                    </tr>
                                </table>
                            </div>
                            <asp:Panel runat="server" ID="pnInsertCard">
                                <div class="col-md-4">
                                    <table class="table">
                                        <tr>
                                            <td>
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtCardNo" TextMode="Number"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button runat="server" ID="Button1" Text="Insert card" CssClass="btn btn-primary btn1 col" OnClick="Button1_Click" /></td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>

