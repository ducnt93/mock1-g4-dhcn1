<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowResults.aspx.cs" Inherits="WebApplication1.UC4.ViewHistory.ShowResults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Content/css/bootstrap.css" rel="stylesheet" />
    <link href="~/Content/Style.css" rel="stylesheet" />
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
                        <div class="col-md-12" style="height: 190px;">
                                    
                                </div>
                        <table class="table">
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="btn50" CssClass="btn btn-primary col btn1" Text="Buttom 1"/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="btn200" CssClass="btn btn-primary col btn1" Text="Buttom 2" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="btn300" CssClass="btn btn-primary col btn1" Text="Buttom 3" OnClick="btn300_Click"/>

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
                                <h3><p>View transaction history</p></h3>
                                <div class="col-md-12">
                                    <asp:GridView ID="grViewhistory" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                                        BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="148px" Width="444px" AllowPaging="True" 
                                        EnableSortingAndPagingCallbacks="True" OnPageIndexChanging="grViewhistory_PageIndexChanging" PageSize="5">
                                        <Columns>
                                            <asp:BoundField DataField="ATMLocation" HeaderText="ATM(Location)" />
                                            <asp:BoundField DataField="Type" HeaderText="Type" />
                                            <asp:BoundField DataField="LogDate" HeaderText="Date" />
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                            <asp:BoundField DataField="Details" HeaderText="To" />
                                        </Columns>
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                </div>
                                <div class="col-md-12">
                                </div>
                                <div class="col-md-12">
                                    <div class="col-md-5 col-md-offset-1 col">
                                        <asp:Button runat="server" ID="btnPre" CssClass="btn btn-primary col btn1" Text="Pre"/>
                                    </div>
                                    <div class="col-md-5 col-md-offset-1 col">                                       
                                        <asp:Button runat="server" ID="btnNexxt" CssClass="btn btn-primary col btn1" Text="Next"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="col-md-12" style="height: 190px;">                                   
                                </div>
                        <table class="table">
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="btn100" CssClass="btn btn-primary col btn1" Text="Buttom 4" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="btn250" CssClass="btn btn-primary col btn1" Text="Buttom 5" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="btn6" CssClass="btn btn-primary col btn1" Text="Buttom 6" OnClick="btn6_Click" />
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
                                            <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-default" Text="Cancel" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum4" CssClass="btn btn-default" Text="4" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum5" CssClass="btn btn-default" Text="5" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum6" CssClass="btn btn-default" Text="6" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnClear" CssClass="btn btn-default" Text="Clear" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum7" CssClass="btn btn-default" Text="7" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum8" CssClass="btn btn-default" Text="8" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnNum9" CssClass="btn btn-default" Text="9" /></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnEnter" CssClass="btn btn-default" Text="Enter" /></td>
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
