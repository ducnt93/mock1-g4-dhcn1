<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowResults.aspx.cs" Inherits="WebApplication1.UC4.ViewHistory.ShowResults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Content/css/bootstrap.css" rel="stylesheet" />
    <link href="~/Content/Style.css" rel="stylesheet" />
</head>
<body class="panel-body" id="main">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container table-bordered">
                    <div class="row">
                        <div class="col-md-10 col-md-offset-2">
                            <div class="col-md-3">
                                <img src="../Content/images/nganhang2.jpg" class="img-thumbnail imgbank" />
                            </div>
                            <div class="col-md-9">
                                <h3><b>ABC Bank @ ATM</b></h3>
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
                                    <a href="javascript:__doPostBack('grViewhistory','Page$Prev')" class="btn btn-default col btn1">Buttom 3</a>
                                </div>
                            </div>
                            <div class="col-md-8 table-bordered" style="padding-top: 20px; height: 385px;">
                                    <h4>View transaction history</h4>
                                <div class="col-md-12 paddingtop1" style="height: 195px;">
                                    <asp:GridView ID="grViewhistory" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableSortingAndPagingCallbacks="True" Height="148px" OnPageIndexChanging="grViewhistory_PageIndexChanging" PageSize="5">
                                        <Columns>
                                            <asp:BoundField DataField="ATMLocation" HeaderText="ATM(Location)">
                                                <ItemStyle Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Type" HeaderText="Type">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LogDate" HeaderText="Date" DataFormatString="{0:d}">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Amount" HeaderText="Amount">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Details" HeaderText="To">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                        <PagerSettings Mode="NextPrevious" NextPageText="" PreviousPageText="" />
                                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                        <RowStyle BackColor="White" ForeColor="#330099" />
                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                    </asp:GridView>
                                </div>
                                <div class="col-md-12 paddingtop1" style="padding-top:35px; ">
                                    <div class="col-md-6">
                                        <input type="text" class="btn btn-success col btn1" value="Prev" />
                                    </div>
                                    <div class="col-md-offset-3  col-md-3">
                                        <input type="text" class="btn btn-success col btn1" value="Next" />
                                    </div>
                                </div>
                            </div>
                             <div class="col-md-2">
                            <div class="col-md-12 paddingtop">
                                <asp:Button runat="server" ID="btn100" CssClass="btn btn-default col btn1" Text="Buttom 4" />
                            </div>
                            <div class="col-md-12 paddingtop">
                                <asp:Button runat="server" ID="btn250" CssClass="btn btn-default col btn1" Text="Buttom 5" />
                            </div>
                            <div class="col-md-12 paddingtop">
                                <a href="javascript:__doPostBack('grViewhistory','Page$Next')" class="btn btn-default col btn1">Buttom 6</a>
                            </div>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
