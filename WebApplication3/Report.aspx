<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="WebApplication3.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report</title>
    <link href="Data/StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" ID="getReport" Text="Get Excel" OnClick="getReport_Click" />
            <asp:GridView ID="grdProductReport" runat="server">

            </asp:GridView>
            
        </div>
    </form>
</body>
</html>
