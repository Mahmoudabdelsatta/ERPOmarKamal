<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ERPOmarKamal.Forms.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 400px;
            height: 248px;
            position: absolute;
            top: 204px;
            left: 490px;
            z-index: 1;
        }
        .auto-style2 {
            text-align: right;
        }
        .button{
    border-radius: 0.5em;           /* increased border-radius */
    text-decoration: none;
    color: black;                   /* changed text color to white */
    padding: 1em 3em;               /* increased padding for a larger button */
    background-color: antiquewhite;      /* changed background color to a nice blue */
    text-transform: uppercase;      /* made the text uppercase */
    font-weight: bold;              /* gave the text a bold look */
}
        .auto-style3 {
            text-align: right;
            height: 80px;
        }
        .auto-style4 {
            text-align: center;
        }
   .tb5 {
	border:2px solid #456879;
	border-radius:10px;
	height: 22px;
	width: 230px;
}
}
        </style>
</head>
<body style="background-color:antiquewhite">&nbsp;<form id="form1" runat="server" >
        <div>  
        </div>
        <table class="auto-style1" style="background-color: #C0C0C0; border: medium solid #000000; " >
        <tr>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtuserName" ErrorMessage="*" ForeColor="#FF3300" ValidationGroup="login"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtuserName" runat="server" ValidationGroup="login" CssClass="tb5"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:Label ID="Label1" runat="server" Text=":اسم المستخدم" Font-Size="Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass" ErrorMessage="*" ForeColor="#FF3300" ValidationGroup="login"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtPass" runat="server" EnableViewState="False" TextMode="Password" ValidationGroup="login" CssClass="tb5"></asp:TextBox>
            </td>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" Text=":الرقم السري" Font-Size="Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="2">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="دخول" ValidationGroup="login" CssClass="button" />
            </td>
        </tr>
    </table>
        <p>
                &nbsp;</p>
    </form>
</body>
</html>
