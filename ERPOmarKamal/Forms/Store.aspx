<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="ERPOmarKamal.Forms.Store" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border-left-style: solid;
            border-left-width: 6px;
            border-right: 6px solid #C0C0C0;
            border-top-style: solid;
            border-top-width: 6px;
            border-bottom: 6px solid #C0C0C0;
            background-color: #FFFFFF;
        }
        .tb5 {
	border:2px solid #456879;
	border-radius:10px;
	height: 22px;
	width: 230px;
}
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
            width: 510px;
        }
        .auto-style5 {
            height: 26px;
            width: 637px;
        }
        .auto-style6 {
            width: 637px;
            height: 33px;
        }
        .auto-style7 {
            height: 26px;
            width: 637px;
            direction: rtl;
        }
        .auto-style8 {
            width: 637px;
            direction: rtl;
        }
        .auto-style9 {
            height: 26px;
            width: 575px;
        }
        .auto-style10 {
            width: 575px;
            height: 33px;
        }
        .auto-style11 {
            height: 26px;
            width: 575px;
            direction: rtl;
        }
        .auto-style12 {
            width: 575px;
            direction: rtl;
        }
        .auto-style13 {
            width: 510px;
            direction: rtl;
        }
        .auto-style14 {
            text-align: left;
        }
        .auto-style15 {
            height: 26px;
            width: 510px;
            text-align: left;
        }
        .auto-style16 {
            width: 510px;
            direction: rtl;
            height: 33px;
        }
        .auto-style17 {
            height: 33px;
        }
        .auto-style19 {
            width: 100%;
        }
        .auto-style20 {
            width: 998px;
        }
        .auto-style21 {
            border: 2px solid #456879;
            border-radius: 10px;
        }
        .auto-style22 {
            height: 26px;
            width: 510px;
            text-align: right;
            direction: rtl;
        }
        .auto-style23 {
            direction: rtl;
        }
        .auto-style24 {
            width: 510px;
            text-align: right;
        }
        .auto-style25 {
            width: 575px;
            direction: rtl;
            text-align: right;
        }
        .auto-style26 {
            height: 26px;
            width: 575px;
            direction: rtl;
            text-align: right;
        }
        .auto-style27 {
            width: 998px;
            text-align: right;
            direction: rtl;
        }
        .auto-style28 {
            height: 26px;
            width: 510px;
            direction: rtl;
        }
    </style>
</head>
<body style="background-color:antiquewhite">
    <form id="form1" runat="server">
        <div class="auto-style14">
        <div id="divadditem" runat="server">

            <table class="auto-style1" style="background-color:burlywood">
                <tr>
                    <td class="auto-style26">
                        <asp:TextBox ID="txtcountFirst" runat="server" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="lblcountFirst" runat="server" Text="رصيد أول المده:"></asp:Label>
                    </td>
                    <td class="auto-style3"></td>
                    <td class="auto-style28">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtItemName" ErrorMessage="*" ForeColor="#FF3300" ValidationGroup="a">يجب ادخال اسم الصنف</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtItemName" runat="server" TextMode="MultiLine" Width="482px" CssClass="auto-style21" Height="47px"></asp:TextBox>
                    </td>
                    <td class="auto-style2" style="direction: rtl">
                        <asp:Label ID="lblItemName" runat="server" Text="اسم الصنف:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2" style="direction: rtl">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style25">
                        <asp:TextBox ID="txtCountLast" runat="server" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:Label ID="lblCountLast" runat="server" Text="رصيد اخر المده:"></asp:Label>
                    </td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style24">
                        <asp:TextBox ID="txtModel" runat="server" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td style="direction: rtl">
                        <asp:Label ID="lblModel" runat="server" Text="الموديل:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td style="direction: rtl">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9"></td>
                    <td class="auto-style5"></td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style22">
                        <div class="auto-style23">
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" OnSelectionChanged="Calendar1_SelectionChanged" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                            <OtherMonthDayStyle ForeColor="#CC9966" />
                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                            <SelectorStyle BackColor="#FFCC66" />
                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                        </asp:Calendar>
                        </div>
                        <asp:TextBox ID="txtdate" runat="server"  style="direction:ltr" ValidationGroup="a" CssClass="tb5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdate" ErrorMessage="*" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style2" style="direction: rtl">
                        <asp:Label ID="lblDate" runat="server" Text="التاريخ:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style15">
                        &nbsp;</td>
                    <td class="auto-style2" style="direction: rtl">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">
                                    <asp:Button ID="btnback2" runat="server"  Text="خروج" BorderStyle="Groove" Font-Bold="True" OnClick="btnback2_Click" />
                                </td>
                    <td class="auto-style6"></td>
                    <td class="auto-style16">
                                    <asp:Button ID="btnback1" runat="server"  Text="رجوع للقائمه الرئيسيه" BorderStyle="Groove" Font-Bold="True" PostBackUrl="~/Forms/Home.aspx" />
                                </td>
                    <td class="auto-style16">&nbsp;</td>
                    <td class="auto-style17">
                        <asp:Button ID="txtAdd" runat="server" OnClick="txtAdd_Click" Text="اضافة صنف" ValidationGroup="a" BorderStyle="Groove" Font-Bold="True" />
                    </td>
                </tr>
               
            </table>

        </div>
        <br />
            <br />
            <div>
                        <table class="auto-style19" style="background-color:blanchedalmond">
                            <tr>
                                <td class="auto-style20">
                                    <asp:Button ID="btnback" runat="server" OnClick="Button1_Click" Text="رجوع للاضافه" BorderStyle="Groove" Font-Bold="True" />
                                </td>
                                <td class="auto-style27">
                        <asp:TextBox ID="txtsearch" runat="server" CssClass="tb5"></asp:TextBox>
                   
                                </td>
                                <td>
                   
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text=" بحث باسم الصنف او الموديل" BorderStyle="Groove" Font-Bold="True" />

                 
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">&nbsp;</td>
                                <td class="auto-style20">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
            </table>

                </div> 
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateSelectButton="True" CellPadding="3" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnDataBound="GridView1_DataBound" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" PageSize="20" OnSorting="GridView1_Sorting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
            <Columns>
                <asp:CommandField CancelText="الغاء" DeleteText="مسح" EditText="تعديل" InsertText="ادخال" SelectText="اختيار العنصر" ShowSelectButton="True" />
                <asp:CommandField CancelText="الغاء" DeleteText="مسح" EditText="تعديل" InsertText="ادخال" NewText="جديد" SelectText="اختيار" ShowDeleteButton="True" UpdateText="تعديل" />
                <asp:CommandField CancelText="الغاء" DeleteText="مسح" EditText="تعديل" InsertText="ادخال" NewText="جديد" SelectText="اختيار" ShowEditButton="True" UpdateText="تحديث" />
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" BorderColor="#0066FF" BorderWidth="3px" Font-Size="Larger" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>

            <asp:Button ID="btnexceldownload" runat="server" OnClick="btnexceldownload_Click" Text="تنزيل فى اكسيل" />

        </div>
    </form>
</body>
</html>
