<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertCardMain.aspx.cs" Inherits="WebApplication1.InsertCardMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/css/bootstrap.css" rel="stylesheet" />
    <link href="Content/Style.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="~/Content/engine1/style.css" />
    <style type="text/css">
        .active {
            z-index: 99;
        }
    </style>
</head>
<body class="panel-body" id="main">

    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="updatePanl1">
            <ContentTemplate>
                <div class="container table-bordered">
                    <div class="row">
                        <div class="col-md-8 col-md-offset-2">
                            <div class="col-md-3">
                                <img src="../Content/images/nganhang2.jpg" class="img-thumbnail imgbank"/>
                            </div>
                            <div class="col-md-9">
                                <h3>ABC Bank @ ATM</h3>
                                <h4>Wellcom to ABC Bank @ ATM.</h4>
                            </div>
                            <asp:Label ID="lblError" Text="" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-2">
                                <div class="col-md-12 paddingtop">
                                    <input type="button" class="btn btn-default col btn1" value="Buttom 1" />
                                </div>
                                <div class="col-md-12 paddingtop">
                                    <input type="button" class="btn btn-default col btn1" value="Buttom 2" />
                                </div>
                                <div class="col-md-12 paddingtop">
                                    <input type="button" class="btn btn-default col btn1" value="Buttom 3" />
                                </div>
                            </div>
                            <div class="col-md-8 table-bordered">
                                <asp:Panel runat="server" ID="slider">
                                    <div class="col-md-12" style="padding-top: 10px; padding-bottom: 10px;">
                                        <div id="wowslider-container1">
                                            <div class="ws_images">
                                                <ul>
                                                    <li>
                                                        <img src="Content/images/20070509_Citibank.JPG" alt="jquery slideshow" title="Bank 1" id="wows1_0" />
                                                    </li>
                                                    <li>
                                                        <img src="Content/images/Bank.jpg" alt="slider" title="Bank 2" id="wows1_1" /></li>
                                                    <li>
                                                        <img src="Content/images/bank-of-america-in-the-us.jpg" alt="jquery carousel" title="Bank 3" id="wows1_2" /></li>
                                                </ul>
                                            </div>
                                            <div class="ws_bullets">
                                                <div>
                                                    <a href="#" title="20070509_Citibank">
                                                        <img src="~/Content/data1/tooltips/20070509_citibank.jpg" alt="20070509_Citibank" />1</a>
                                                    <a href="#" title="Bank">
                                                        <img src="~/Content/data1/tooltips/bank.jpg" alt="Bank" />2</a>
                                                    <a href="#" title="bank-of-america-in-the-us">
                                                        <img src="~/Content/data1/tooltips/bankofamericaintheus.jpg" alt="bank-of-america-in-the-us" />3</a>
                                                </div>
                                            </div>
                                            <div class="ws_shadow"></div>
                                        </div>
                                        <script type="text/javascript" src="~/Content/engine1/wowslider.js"></script>
                                        <script type="text/javascript" src="~/Content/engine1/script.js"></script>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div class="col-md-2">
                                <div class="col-md-12 paddingtop">
                                    <input type="button" class="btn btn-default col btn1" value="Buttom 4" />
                                </div>
                                <div class="col-md-12 paddingtop">
                                    <input type="button" class="btn btn-default col btn1" value="Buttom 5" />
                                </div>
                                <div class="col-md-12 paddingtop">
                                    <input type="button" class="btn btn-default col btn1" value="Buttom 6" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12" style="padding-top: 20px;">
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
                                            <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger buttom" Text="Cancel" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum4" CssClass="btn btn-default" Text="4" OnClick="btnNum4_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum5" CssClass="btn btn-default" Text="5" OnClick="btnNum5_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum6" CssClass="btn btn-default" Text="6" OnClick="btnNum6_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnClear" CssClass="btn btn-warning buttom" Text="Clear" OnClick="btnClear_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum7" CssClass="btn btn-default" Text="7" OnClick="btnNum7_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum8" CssClass="btn btn-default" Text="8" OnClick="btnNum8_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum9" CssClass="btn btn-default" Text="9" OnClick="btnNum9_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnEnter" CssClass="btn btn-primary buttom" Text="Enter" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btnDot" CssClass="btn btn-default" Text="." /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum0" CssClass="btn btn-default" Text="0" OnClick="btnNum0_Click" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnComma" CssClass="btn btn-default" Text="," /></td>
                                    </tr>
                                </table>
                            </div>
                            <asp:Panel runat="server" ID="pnInsertCard">
                                <div class="col-md-4">
                                    <table class="table">
                                        <tr>
                                            <td>
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtCardNo" TextMode="Password"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button runat="server" ID="Button1" Text="Insert card" CssClass="btn btn-primary btn1 col" OnClick="btnInsertCard_Click" /></td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>

