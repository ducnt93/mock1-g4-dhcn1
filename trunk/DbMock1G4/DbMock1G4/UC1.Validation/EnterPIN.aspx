<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterPIN.aspx.cs" Inherits="WebApplication1.UC1.Validation.EnterPIN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
            <Triggers>
                <%--<asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />--%>
                <%--<asp:AsyncPostBackTrigger ControlID="Timer2" EventName="Tick" />--%>
            </Triggers>
            <ContentTemplate>
                <fieldset>
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-2">
                                    <div class="col-md-12" style="height: 190px;">
                                    </div>
                                    <table class="table">
                                        <tr>
                                            <td>
                                                <%--<asp:Button runat="server" ID="btnWithdraw" CssClass="btn btn-primary col btn1" Text="Withdraw" OnClick="btnWithdraw_Click" />--%>
                                                <input type="button" class="btn btn-primary col btn1" value="Buttom 1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%--<asp:Button runat="server" ID="Button2" CssClass="btn btn-primary col btn1" Text="Check Balance" OnClick="btnWithdraw_Click" />--%>
                                                <input type="button" class="btn btn-primary col btn1" value="Buttom 2" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%-- <asp:HyperLink runat="server" ID="hyperLinkTransfer" CssClass="btn btn-primary col btn1">Transfer</asp:HyperLink>--%>
                                                <input type="button" class="btn btn-primary col btn1" value="Buttom 3" />
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

                                        <%--<asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" />--%>
                                        <asp:PlaceHolder runat="server" ID="contenBlockCard">
                                            <div class="col-lg-9 col-md-offset-3">
                                                <asp:PlaceHolder runat="server" ID="contenEnterPIN"></asp:PlaceHolder>
                                                Enter your PIN<br />
                                                <div>
                                                    <asp:TextBox ID="txtPIN" runat="server" CssClass="form-control1" TextMode="Password"/>
                                                </div>
                                                <br />
                                            </div>
                                            <div class="col-lg-9 col-md-offset-3">
                                                <div>
                                                    <p>then press Enter buttom</p>
                                                </div>

                                                <div class="col-md-4 col-lg-offset-8 col">
                                                    <p></p>
                                                    <input type="text" class="btn btn-primary btn1" value="OK" />
                                                </div>
                                                <div class="col-md-4 col-lg-offset-8 col">
                                                    <input type="text" class="btn btn-primary btn1" value="Cancel" />
                                                </div>
                                            </div>
                                        </asp:PlaceHolder>

                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="col-md-12" style="height: 190px;">
                                    </div>
                                    <table class="table">
                                        <tr>
                                            <td>
                                                <%-- <asp:HyperLink runat="server" ID="hyperLinkViewHistory" CssClass="btn btn-primary col btn1">View History</asp:HyperLink>--%>
                                                <input type="button" class="btn btn-primary col btn1" value="Buttom 4" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%--<asp:HyperLink runat="server" ID="hyperLinkChangePin" CssClass="btn btn-primary col btn1">Change PIN</asp:HyperLink>--%>
                                                <asp:Button runat="server" ID="Button5" CssClass="btn btn-primary col btn1" Text="Buttom 5" OnClick="Button5_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%--<asp:Button runat="server" ID="btnExit" CssClass="btn btn-primary col btn1" Text="Exit" OnClick="btnExit_Click" />--%>
                                                <asp:Button runat="server" ID="Button6" CssClass="btn btn-primary col btn1" Text="Buttom 6" OnClick="Button6_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="col-md-12 table-bordered">
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
                                                <asp:Button runat="server" ID="btnEnter" CssClass="btn btn-default" Text="Enter" OnClick="btnEnter_Click" /></td>
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
                                        <asp:Button runat="server" ID="btnInsertCard" Text="Insert card" CssClass="btn btn-primary btn1 col" OnClick="btnInsertCard_Click" /></td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>--%>
                            </div>
                        </div>
                    </div>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
