<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="FoodCartApplicationDemo.UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        h1{
            text-align:center;
            font-family:'Times New Roman', Times, serif;
            font-size:50px;
            color:darkred;
            background-color:aquamarine;
            background-image:initial;
        }
        div{
            text-align:center;
            font-size:25px;
            background-color:antiquewhite;
            color:blue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>
            Welcome to the Billing System
        </h1>
        <hr />
        <h2>The List Of Items U have selected </h2>
        <asp:Repeater runat="server">
            <ItemTemplate></ItemTemplate>
        </asp:Repeater>
        <div>
            <h1>We need information about you to deliver</h1>
            Customer Name : <asp:TextBox runat="server" ID="txtName"/><br />

            Customer Address : <asp:TextBox runat="server" ID="txtAddress"/><br />

            Customer Contact : <asp:TextBox runat="server" ID="txtPhone"/><br />

            <asp:Button Text="Complete Order" ID="btnOrder" runat="server" OnClick="btnOrder_Click" />
        </div>
    </form>
</body>
</html>
