<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Caculator.ascx.cs" Inherits="WebApplication1.Caculator" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                            <asp:Button runat="server" ID="btnEnter" CssClass="btn btn-default" Text="Enter" /></td>
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

        </ContentTemplate>

    </asp:UpdatePanel>
