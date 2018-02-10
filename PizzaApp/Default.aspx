<%@ Page Title="Pizza App" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PizzaApp._Default" %>

<html>
    <head>
        <title>Pizza App</title>
        <link type="text/css" rel="stylesheet" href="Content/utilities.css" />
    </head>

    <body>
        <div id="heading_container" class="flex row j-center a-center bg-m-dk">

            <asp:Label ID="lblHeaderTitle" CssClass="txt-gry-lt" runat="server" Text="Pizza App"></asp:Label>

        </div>

        <div id="content_container">
            <form id="form1" runat="server">
                <asp:DropDownList ID="ddlPizzaSize" runat="server"></asp:DropDownList>
                <asp:CheckBoxList ID="cblIngredients" runat="server"></asp:CheckBoxList>
                <asp:RadioButtonList ID="rblCrustType" runat="server"></asp:RadioButtonList>
                <asp:Button ID="btnSaveForm" runat="server" Text="Save Input" OnClick="btnSaveForm_Click" />
            </form>
        </div>
    </body>
</html>
