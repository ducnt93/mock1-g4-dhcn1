<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WaittedScreen.aspx.cs" Inherits="WebApplication1.UC4.ViewHistory.WaittedScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Content/css/bootstrap.css" rel="stylesheet" />
    <link href="~/Content/Style.css" rel="stylesheet" />
     <script type="text/JavaScript">
        setTimeout("location.href = 'http://localhost:39319/UC4.ViewHistory/ShowResults.aspx';", 2000);
    </script>
</head>
<body class="panel-body" id="main">
    <form id="form1" runat="server">
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
                            <asp:Button runat="server" ID="btn50" CssClass="btn btn-default col btn1" Text="Buttom 1" />
                        </div>
                        <div class="col-md-12 paddingtop">
                            <asp:Button runat="server" ID="btn200" CssClass="btn btn-default col btn1" Text="Buttom 2" />
                        </div>
                        <div class="col-md-12 paddingtop">
                            <asp:Button runat="server" ID="btn300" CssClass="btn btn-default col btn1" Text="Buttom 3" />
                        </div>
                    </div>
                    <div class="col-md-8 table-bordered" style="padding-top: 20px; height: 385px;">
                        <div class="col-md-12">
                            <h3 style="text-align: center;">View transaction history</h3>
                            <h4 style="text-align: center; color: #04EBEB;">Searching....</h4>
                        </div>
                    </div>
                    <div class="col-md-2 ">
                        <div class="col-md-2">
                            <div class="col-md-12 paddingtop">
                                <asp:Button runat="server" ID="btn100" CssClass="btn btn-default col btn1" Text="Buttom 4" />
                            </div>
                            <div class="col-md-12 paddingtop">
                                <asp:Button runat="server" ID="btn250" CssClass="btn btn-default col btn1" Text="Buttom 5" />
                            </div>
                            <div class="col-md-12 paddingtop">
                                <asp:HyperLink runat="server" ID="HyperLink1" CssClass="btn btn-default btn1 col">Buttom 6</asp:HyperLink>
                            </div>
                        </div>
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
