<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="FoodCartApplicationDemo.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .foodItem{
            border:1px solid blue;
            margin:2px;
            padding:2px;
            width:300px;
            background-color:lightblue;
            text-align:center
        }
        img{
            width:300px;
            height:200px;
            background-color:aquamarine;
            text-align:center
        }
        h1{
            font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            font-size:50pt;
            text-align:center;
            color:darkslateblue;
            background-color:lightcyan;
        }
    </style>
</head>
<body>
    <h1>Navayuga Restaurent,Narasaraopet</h1>
    <hr />
    <form id="form1" runat="server">
        <div>
            <h2>Please Select the Food Items Here!</h2>
            <asp:DataList runat="server" RepeatDirection="Horizontal" ID="dtList" OnItemCommand="dtList_ItemCommand">
                <ItemTemplate>
                    <div class="foodItem">
                        <h2><%#Eval("ItemName") %></h2>
                        <hr />
                        <p><%#Eval("ItemName") %></p>
                        <p>
                            <img src="<%#Eval("ItemImage")%>"/>

                        </p>
                        <p>Cost: <%# Eval("ItemCost")%></p>                        
                        <asp:Button Text="Select" CommandName="Select" runat="server" />
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div style="text-align:center;color:orangered;font-size:25pt">
            <asp:Label Text="Items Basket Count: " ID="lblItemCount" runat="server" />
        </div>
        <div style="text-align:center">
            <asp:Button Text="GenerateBill" runat="server" ID="btnBill" OnClick="btnBill_Click"/>
        </div>
    </form>
</body>
</html>
