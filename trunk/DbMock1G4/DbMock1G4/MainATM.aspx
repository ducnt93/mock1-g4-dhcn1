<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainATM.aspx.cs" Inherits="WebApplication1.MainATM" %>

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
                        <div class="col-md-12" style="height: 180px;">
                        </div>
                        <table class="table">
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="btnWithdraw" CssClass="btn btn-primary col btn1" Text="Buttom 1" OnClick="btnWithdraw_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="btnCheckBalance" CssClass="btn btn-primary col btn1" Text="Buttom 2" OnClick="btnCheckBalance_Click"  />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink runat="server" ID="hyperLinkTransfer" CssClass="btn btn-primary col btn1">Button 3</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-md-8 table-bordered" style="height: 393px;">
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
                        <div class="col-md-12">
                               <h4>Choose amount below or enter your amount you want:</h4>
                                <div class="col-md-12">
                                    <div class="col-md-5 col-md-offset-1 col">

                                        <input type="text" class="btn btn-success btn1 col" value="Withdraw" />
                                    </div>
                                    <div class="col-md-5 col-md-offset-1 col">
                                        <input type="text" class="btn btn-success btn1 col" value="View History" />
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="col-md-5 col-md-offset-1 col">

                                        <input type="text" class="btn btn-success btn1 col" value="Check Balance" />
                                    </div>
                                    <div class="col-md-5 col-md-offset-1 col">

                                        <input type="text" class="btn btn-success btn1 col" value="Change PIN" />
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="col-md-5 col-md-offset-1 col">

                                        <input type="text" class="btn btn-success btn1 col" value="Transfer" />
                                    </div>
                                    <div class="col-md-5 col-md-offset-1 col">

                                        <input type="text" class="btn btn-success btn1 col" value="Exit" />
                                    </div>
                                </div>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="col-md-12" style="height: 180px;">
                        </div>
                        <table class="table">
                            <tr>
                                <td>
                                    <asp:HyperLink runat="server" ID="hyperLinkViewHistory" CssClass="btn btn-primary col btn1">Button 4</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink runat="server" ID="hyperLinkChangePin" CssClass="btn btn-primary col btn1">Button 5</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="btnExit" CssClass="btn btn-primary col btn1" Text="Button 6" OnClick="btnExit_Click" />
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
                                            <asp:Button runat="server" ID="btnEnter" CssClass="btn btn-primary buttom " Text="Enter" /></td>
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
                            <%--<asp:Panel runat="server" ID="pnInsertCard">
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
                            </asp:Panel>--%>
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

