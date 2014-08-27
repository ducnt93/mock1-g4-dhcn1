<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorScreen.aspx.cs" Inherits="WebApplication1.UC2.WithdrawMoney.ErrorScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        setTimeout(function() {
            window.location.href = "~/MainATM.aspx";
        }, 1000);
    </script>
</head>

<body>
    <form id="form1" runat="server">
    <div>
            Error...
    </div>
    </form>
</body>
</html>
