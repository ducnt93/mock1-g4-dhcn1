<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validate.aspx.cs" Inherits="WebApplication1.UC1.Validation.Validate" %>

<%@ Reference Control="~/UC1.Validation/UcController/UcValidating.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Content/css/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Style.css" rel="stylesheet" />
</head>
<body class="panel-body" id="main">
    <form id="form1" runat="server">

        <div class="container table-bordered">
            <div class="row">
                <div class="col-md-10 col-md-offset-2">
                    <div class="col-md-3">
                        <img src="../Content/images/nganhang2.jpg" class="img-thumbnail imgbank" style="height: 150px; width: 150px;" />
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
                        <div class="col-md-12">
                            <div class="col-lg-9 col-md-offset-3">
                                <asp:Label ID="lblError" Text="" runat="server"></asp:Label>
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                        <%--<asp:AsyncPostBackTrigger ControlID="Timer2" EventName="Tick" />--%>
                                    </Triggers>
                                    <ContentTemplate>

                                        <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick" />

                                        <asp:PlaceHolder runat="server" ID="contenValidate"></asp:PlaceHolder>

                                    </ContentTemplate>

                                </asp:UpdatePanel>
                                <%--<asp:UpdateProgress ID="UpProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">--%>
                                <%--<ProgressTemplate>--%>
                                <%--Validating your ATM card...--%>
                                <%--</ProgressTemplate>--%>
                                <%--</asp:UpdateProgress>--%>
                            </div>
                        </div>
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
                <div class="col-md-12 table-bordered">
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
                                    <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger buttom " Text="Cancel" /></td>
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
    </form>
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
