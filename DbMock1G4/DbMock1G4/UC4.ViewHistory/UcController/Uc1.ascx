<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Uc1.ascx.cs" Inherits="WebApplication1.UC4.ViewHistory.UcController.Uc1" %>
                            <div class="col-md-9">
                                <h3>ABC Bank @ ATM</h3>
                                <h4>Please select a transaction</h4>
                                <p>
                                    Wellcom to ABC Bank @ ATM.
                                </p>
                                <h3><p>View transaction history</p></h3>
                                <div class="col-md-12">
                                    <asp:GridView ID="grViewhistory" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="148px" Width="444px">
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
                                        <asp:Button runat="server" ID="btnPre" CssClass="btn btn-primary col btn1" Text="Pre" OnClick="btnPre_Click"/>
                                    </div>
                                    <div class="col-md-5 col-md-offset-1 col">                                       
                                        <asp:Button runat="server" ID="btnNexxt" CssClass="btn btn-primary col btn1" Text="Next" OnClick="btnNexxt_Click"/>
                                    </div>
                                </div>
                            </div>