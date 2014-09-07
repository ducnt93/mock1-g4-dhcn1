<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcBlockCard.ascx.cs" Inherits="WebApplication1.UC1.Validation.UcController.UcBlockCard" %>
<asp:Timer ID="time" Interval="5000" OnTick="Timer_Tick" runat="server"></asp:Timer>
<div class="col-lg-9 col-md-offset-3">
    <div class="col-md-offset-3-2">
        <h4>You enterred three times invalid PIN<br />
            System BLOCK CARD<br />
            Swallow card ...
        </h4>
    </div>
</div>
