<%@ Page Title="Pizza App" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PizzaApp._Default" %>

<html class="hfull">
    <head>
        <title>Ian's Rosso Pizzaria</title>
        <link type="text/css" rel="stylesheet" href="Content/utilities.css" />
        <link type="text/css" rel="stylesheet" href="Content/Site_Custom.css" />
    </head>

    <body class="hfull flex column">
        <div id="heading_container" class="flex row j-center a-center bg-m-dk p15px">
            <asp:Image ID="imgLogo" Height="80px" Width="80px" runat="server" ImageUrl="Content/Images/Logo.png"/>
            <asp:Label ID="lblHeaderTitle" CssClass="txt-gry-lt" runat="server" Text="Ian's Rosso Pizzaria" Font-Size="48"></asp:Label>

        </div>

        <div id="content_container" class="wfull grow" style="background-image: url('Content/Images/Pizza_Background.jpg'); background-repeat: no-repeat; background-size: cover;">
            <div>
                <form id="form1" runat="server">
                    <div class="flex column ps15px pt15px">
                        <div class="flex row">
                            <asp:DropDownList ID="ddlPizzaSize" runat="server" AutoPostBack="true"></asp:DropDownList>
                        </div>

                        <div class="flex row pt5px">
                            <asp:CheckBoxList ID="cblIngredients" runat="server" AutoPostBack="true"></asp:CheckBoxList>
                        </div>

                        <div class="flex column pt5px">
                            <asp:RequiredFieldValidator ID="rfvCrustType" ControlToValidate="rblCrustType" runat="server" ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                            <asp:RadioButtonList ID="rblCrustType" runat="server" AutoPostBack="true"></asp:RadioButtonList>
                        </div>

                        <div class="flex row pt5px">
                            <asp:Button ID="btnSaveForm" CssClass="mr5px" runat="server" Text="Save Input" OnClick="btnSaveForm_Click" />
                            <asp:Button ID="btnClearForm" runat="server" Text="Reset Form" OnClick="btnClearForm_Click" />
                        </div>
                    </div>
                    <div id="divCheckoutInfoContainer" runat="server" visible="false" class="flex column ps15px pt15px">
                        <div class="pb5px">
                            <asp:TextBox ID="tbInputDisplay" runat="server" AutoPostBack="true" TextMode="MultiLine" Height="120px" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="flex row pb5px">
                            <asp:Label ID="lblTipPrompt" runat="server" Text="Tip Amount:"></asp:Label>
                            <asp:TextBox ID="txtTip" runat="server" AutoPostBack="true" type="number"></asp:TextBox>
                        </div>
                        <div class="flex row pb5px">
                            <asp:Label ID="lblDeliveryPrompt" runat="server" Text="Is this order for delivery?"></asp:Label>
                            <asp:CheckBox ID="chkDelivery" runat="server" AutoPostBack="true" />
                        </div>
                        <div>
                            <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
                        </div>
                    </div>
                    <div id="divInvoiceDisplayContainer" class="flex column ps15px pt15px" runat="server" visible="false">
                        <div>
                            <asp:TextBox ID="tbInvoice" runat="server" AutoPostBack="true" Height="100px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </body>
</html>
