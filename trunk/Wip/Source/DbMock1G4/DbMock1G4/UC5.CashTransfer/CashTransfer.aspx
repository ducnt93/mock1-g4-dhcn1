<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashTransfer.aspx.cs" Inherits="WebApplication1.UC5.CashTransfer.CashTranfer" %>

<%@ Register Src="~/UC5.CashTransfer/UcController/UcHelloCashTransfer.ascx" TagPrefix="uc1" TagName="UcHelloCashTransfer" %>
<%@ Register Src="~/UC5.CashTransfer/UcController/UcInputAccountReceive.ascx" TagPrefix="uc1" TagName="UcInputAccountReceive" %>
<%@ Register Src="~/UC5.CashTransfer/UcController/UcErrorAccount.ascx" TagPrefix="uc1" TagName="UcErrorAccount" %>
<%@ Register Src="~/UC5.CashTransfer/UcController/UcErrorAmount.ascx" TagPrefix="uc1" TagName="UcErrorAmount" %>
<%@ Register Src="~/UC5.CashTransfer/UcController/UcInputMoneyTransfer.ascx" TagPrefix="uc1" TagName="UcInputMoneyTransfer" %>
<%@ Register Src="~/UC5.CashTransfer/UcController/UcPrintPeceiptCT.ascx" TagPrefix="uc1" TagName="UcPrintPeceiptCT" %>
<%@ Register Src="~/UC5.CashTransfer/UcController/UcDisplayInfomationAccount.ascx" TagPrefix="uc1" TagName="UcDisplayInfomationAccount" %>
<%@ Register Src="~/UC5.CashTransfer/UcController/UcDisplayAccountReceiveAndAmount.ascx" TagPrefix="uc1" TagName="UcDisplayAccountReceiveAndAmount" %>


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
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-2">
                                    <div class="col-md-12 paddingtop">
                                        <asp:Button runat="server" ID="btn1" CssClass="btn btn-default col btn1" Text="Buttom 1" />
                                    </div>
                                    <div class="col-md-12 paddingtop">
                                        <asp:Button runat="server" ID="btn2" CssClass="btn btn-default col btn1" Text="Buttom 2" />
                                    </div>
                                    <div class="col-md-12 paddingtop">
                                        <asp:Button runat="server" ID="btn3" CssClass="btn btn-default col btn1" Text="Buttom 3" />
                                    </div>
                                </div>
                                <div class="col-md-8 table-bordered">
                                    <div class="col-md-12">
                                        <asp:PlaceHolder runat="server" ID="contenPlace">
                                            <uc1:UcHelloCashTransfer runat="server" ID="UcHelloCashTransfer" />
                                            <uc1:UcInputAccountReceive runat="server" ID="UcInputAccountReceive" />
                                            <uc1:UcInputMoneyTransfer runat="server" ID="UcInputMoneyTransfer" />
                                            <uc1:UcDisplayInfomationAccount runat="server" ID="UcDisplayInfomationAccount" />
                                            <uc1:UcErrorAccount runat="server" ID="UcErrorAccount" />
                                            <uc1:UcErrorAmount runat="server" ID="UcErrorAmount" />
                                            <uc1:UcPrintPeceiptCT runat="server" ID="UcPrintPeceiptCT" />
                                            <uc1:UcDisplayAccountReceiveAndAmount runat="server" ID="UcDisplayAccountReceiveAndAmount" />
                                        </asp:PlaceHolder>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="col-md-2">
                                        <div class="col-md-12 paddingtop">
                                            <asp:Button runat="server" ID="btn100" CssClass="btn btn-default col btn1" Text="Buttom 4" />
                                        </div>
                                        <div class="col-md-12 paddingtop">
                                            <asp:Button runat="server" ID="btnAccept" CssClass="btn btn-default col btn1" Text="Buttom 5" OnClick="btnAccept_Click" />
                                        </div>
                                        <div class="col-md-12 paddingtop">
                                            <asp:Button runat="server" ID="btnReject" CssClass="btn btn-default col btn1" Text="Buttom 6" OnClick="btnReject_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
            </ContentTemplate>
        </asp:UpdatePanel>

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
                            <asp:Button runat="server" ID="btnEnter" CssClass="btn btn-primary buttom" Text="Enter" OnClick="btnEnter_Click" /></td>
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
    </form>
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>



