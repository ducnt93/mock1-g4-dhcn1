﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckBalace.aspx.cs" Inherits="WebApplication1.UC3.CheckBalance.CheckBalace" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../Content/css/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Style.css" rel="stylesheet" />

    <style type="text/css">
        #main {
            padding-top: 100px;
            background-color: aliceblue;
        }
    </style>
</head>
<body class="panel-body" id="main">
    <form id="form2" runat="server">
        <div class="container table-bordered">
            <div class="row">
                <div class="col-md-10 col-md-offset-2">
                    <div class="col-md-3">
                        <img src="../Content/images/nganhang2.jpg" class="img-thumbnail imgbank" />
                    </div>
                    <div class="col-md-9">
                        <h2>ABC Bank @ ATM</h2>
                        <h3>Wellcom to ABC Bank @ ATM.</h3>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="col-md-12 paddingtop">
                            <asp:Button runat="server" ID="btnWithdraw" CssClass="btn btn-default col btn1" Text="Buttom 1" />
                        </div>
                        <div class="col-md-12 paddingtop">
                            <asp:Button runat="server" ID="Button2" CssClass="btn btn-default col btn1" Text="Buttom 2" />
                        </div>
                        <div class="col-md-12 paddingtop">
                            <asp:HyperLink runat="server" ID="hyperLinkTransfer" CssClass="btn btn-default col btn1">Button 3</asp:HyperLink>
                        </div>
                    </div>
                    <div class="col-md-8 table-bordered">
                        <div class="col-md-12">
                            <h4><b>You account have:<asp:Label runat="server" ID="lblAccount"></asp:Label></b></h4>
                            <h4 style="padding-top: 10px;">Do you want to print receipt?</h4>
                            <div class="col-md-12 paddingtop">
                                <div class="col-md-5 col-md-offset-7 col paddingtop1">                                   
                                    <span class="btn btn-success btn1 col">OK</span>
                                </div>
                                <div class="col-md-5 col-md-offset-7 col paddingtop1">
                                    <span class="btn btn-success btn1 col">Cancel</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="col-md-12 paddingtop">
                            <asp:HyperLink runat="server" ID="hyperLinkViewHistory" CssClass="btn btn-default col btn1">Button 4</asp:HyperLink>
                        </div>
                        <div class="col-md-12 paddingtop">
                            <asp:HyperLink runat="server" ID="hyperLinkChangePin" CssClass="btn btn-default col btn1">Button 5</asp:HyperLink>
                        </div>
                        <div class="col-md-12 paddingtop">
                            <asp:Button runat="server" ID="btnExit" CssClass="btn btn-default col btn1" Text="Button6" OnClick="btnExit_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="col-md-4 col-md-offset-4">
                            <table class="table table-bordered">
                                <tr>
                                    <td>
                                        <asp:Button runat="server" ID="btnNum1" CssClass="btn btn-default" Text="1" /></td>
                                    <td>
                                        <asp:Button runat="server" ID="btnNum2" CssClass="btn btn-default" Text="2" /></td>
                                    <td>
                                        <asp:Button runat="server" ID="btnNum3" CssClass="btn btn-default" Text="3" /></td>
                                    <td>
                                        <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger buttom" Text="Cancel" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button runat="server" ID="btnNum4" CssClass="btn btn-default" Text="4" /></td>
                                    <td>
                                        <asp:Button runat="server" ID="btnNum5" CssClass="btn btn-default" Text="5" /></td>
                                    <td>
                                        <asp:Button runat="server" ID="btnNum6" CssClass="btn btn-default" Text="6" /></td>
                                    <td>
                                        <asp:Button runat="server" ID="btnClear" CssClass="btn btn-warning buttom" Text="Clear" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button runat="server" ID="btnNum7" CssClass="btn btn-default" Text="7" /></td>
                                    <td>
                                        <asp:Button runat="server" ID="btnNum8" CssClass="btn btn-default" Text="8" /></td>
                                    <td>
                                        <asp:Button runat="server" ID="btnNum9" CssClass="btn btn-default" Text="9" /></td>
                                    <td>
                                        <asp:Button runat="server" ID="btnEnter" CssClass="btn btn-primary buttom" Text="Enter" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button runat="server" ID="btnDot" CssClass="btn btn-default" Text="." /></td>
                                    <td>
                                        <asp:Button runat="server" ID="btnNum0" CssClass="btn btn-default" Text="0" /></td>
                                    <td>
                                        <asp:Button runat="server" ID="btnComma" CssClass="btn btn-default" Text="," /></td>
                                </tr>
                            </table>
                        </div>
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
