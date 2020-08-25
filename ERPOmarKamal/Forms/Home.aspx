<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ERPOmarKamal.Forms.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
        }
        .button{
    border-radius: 0.5em;           
    text-decoration: none;
    color: white;                   
    padding: 1em;                   /* removed the right and left padding value */     
    padding-right: 3em;             /* added only padding-right to align the icon left  */
    background-color: #329bd8;      
    text-transform: uppercase;      
    font-weight: bold;              
}
         .tb5 {
	border:2px solid #456879;
	border-radius:10px;
	height: 22px;
	width: 230px;
}
 
        .auto-style3 {
            text-align: center;
            height: 239px;
        }
 
        .auto-style4 {
            text-align: center;
            height: 44px;
            font-size: x-large;
        }
        .auto-style5 {
            text-align: center;
            height: 44px;
        }
 
    </style>
</head>
<body style="background-color:antiquewhite">
    <form id="form1" runat="server">
        <div class="auto-style2">
            
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            
        </div>
        <table class="auto-style1" >
            <tr>
                <td class="auto-style3">
                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Img/download.jpg" PostBackUrl="~/Forms/theSales.aspx" Width="352px" Height="450px" />
                </td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style3">
                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Img/50603ba434026db0a37beb80260b14e1.jpg" PostBackUrl="~/Forms/clients.aspx" Width="352px" Height="450px" />
                </td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style3">
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Img/pngtree-accounting-logo-image_80315.jpg" PostBackUrl="~/Forms/suppliers.aspx" Width="352px" Height="450px" />
                </td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style3">
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="450px" ImageUrl="~/Img/1220.jpg" PostBackUrl="~/Forms/Store.aspx" Width="352px" AlternateText="المخازن" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    المبيعات</td>
                <td class="auto-style5">
                </td>
                <td class="auto-style5">
                </td>
                <td class="auto-style4">
                    العملاء</td>
                <td class="auto-style5">
                </td>
                <td class="auto-style5">
                </td>
                <td class="auto-style4">
                    الموردين</td>
                <td class="auto-style5">
                </td>
                <td class="auto-style5">
                </td>
                <td class="auto-style4">
                    <strong>المخازن</strong></td>
            </tr>
            </table>
        <p>
                                    <asp:Button ID="btnback2" runat="server"  Text="خروج" BorderStyle="Groove" Font-Bold="True" OnClick="btnback2_Click" />
                                </p>
        <p>
                                    <asp:Button ID="btnback3" runat="server"  Text="استخراج نسخه من قاعدة البيانات" BorderStyle="Groove" Font-Bold="True" OnClick="btnback3_Click"  />
                                </p>
    </form>
</body>
</html>
