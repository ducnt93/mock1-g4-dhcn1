<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Withdraw.aspx.cs" Inherits="WebApplication1.UC2.WithdrawMoney.Withdraw1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Content/css/bootstrap.css" rel="stylesheet" />
    <link href="~/Content/Style.css" rel="stylesheet" />
</head>
<body class="panel-body" id="main">

    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="container table-bordered">
                    <div class="row">
                        <div class="col-md-10 col-md-offset-2">
                                    <div class="col-md-3">
                                        <img src="../Content/images/nganhang2.jpg" class="img-thumbnail imgbank" />
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
                            <div class="col-md-2">
                                <div class="col-md-12 paddingtop">
                                    <asp:Button runat="server" ID="btn50" CssClass="btn btn-default col btn1" Text="Buttom 1" OnClick="btn50_Click" />
                                </div>
                                <div class="col-md-12 paddingtop">
                                    <asp:Button runat="server" ID="btn200" CssClass="btn btn-default col btn1" Text="Buttom 2" OnClick="btn200_Click" />
                                </div>
                                <div class="col-md-12 paddingtop">
                                    <asp:Button runat="server" ID="btn300" CssClass="btn btn-default col btn1" Text="Buttom 3" OnClick="btn300_Click" />
                                </div>
                            </div>
                            <div class="col-md-8 table-bordered" style="height: 393px;">
                                <div class="col-md-12">
                                    <asp:PlaceHolder runat="server" ID="contenPlace"></asp:PlaceHolder>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="col-md-12 paddingtop">
                                    <asp:Button runat="server" ID="btn100" CssClass="btn btn-default col btn1" Text="Buttom 4" OnClick="btn100_Click" />
                                </div>
                                <div class="col-md-12 paddingtop">
                                    <asp:Button runat="server" ID="btn250" CssClass="btn btn-default col btn1" Text="Buttom 5" OnClick="btn250_Click" />
                                </div>
                                <div class="col-md-12 paddingtop">
                                    <asp:Button runat="server" ID="btnOrther" CssClass="btn btn-default col btn1" Text="Buttom 6" OnClick="btnOrther_Click" />
                                </div>
                            </div>
                        </div>
                        
        <div class="col-md-12">
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
                            <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger buttom" Text="Cancel" OnClick="btnCancel_Click" /></td>
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
        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>


