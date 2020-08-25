<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchases.aspx.cs" Inherits="ERPOmarKamal.Forms.Purchases" %>

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
        .auto-style18 {
           height: 26px;
           width: 637px;
           text-align: right;
       }
       .auto-style19 {
           height: 26px;
           width: 575px;
           text-align: right;
       }
        .auto-style20 {
           width: 510px;
           direction: rtl;
           height: 33px;
           text-align: left;
       }
       .auto-style21 {
           width: 510px;
           direction: rtl;
           height: 33px;
           text-align: right;
       }
        </style><style type="text/css">
        .auto-style1 {
           
        }
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            width: 6px;
            height: 26px;
        }
        .auto-style4 {
            width: 10px;
        }
        .auto-style5 {
            height: 26px;
            width: 10px;
        }
                    .auto-style22 {
                        width: 510px;
                    }
                    .auto-style23 {
                        height: 26px;
                        width: 575px;
                        text-align: right;
                        direction: rtl;
                    }
    </style>
</head>
<body style="background-color:antiquewhite">
    <form id="form1" runat="server">
        <div id="divadditem" runat="server">
            <table class="auto-style1" style="background-color:burlywood">
                <tr>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                   
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style11">
                    </td>
                    <td class="auto-style11">
                        
                        &nbsp;</td>
                    <td class="auto-style11">
                        
                        &nbsp;</td>
                    <td class="auto-style11">
                        
                        &nbsp;</td>
                    <td class="auto-style11">
                        
                    </td>
                    <td class="auto-style11">
                        <asp:TextBox ID="txtcount" runat="server" AutoPostBack="True" OnTextChanged="txtcount_TextChanged" TextMode="Number" ValidationGroup="c" CssClass="tb5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcount" ErrorMessage="*" ForeColor="#FF3300" ValidationGroup="c"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="lblcountFirst" runat="server" Text="العدد:"></asp:Label>
                    </td>

                    <td class="auto-style3"></td>
                    <td class="auto-style3" >
                        <asp:DropDownList ID="DropDownList1" runat="server"  DataSourceID="SqlDataSource1" DataTextField="اسم_الصنف" DataValueField="الكود" Width="700px" CssClass="tb5">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:omarKamalConnectionString2 %>" SelectCommand="SELECT [الكود], [اسم الصنف] AS اسم_الصنف FROM [المخزن]"></asp:SqlDataSource>
                    </td>
                    <td class="auto-style2" style="direction: rtl">
                        <asp:Label ID="lblItemName0" runat="server" Text="اسم الصنف:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11"></td>
                    <td class="auto-style7"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style2" style="direction: rtl"></td>

                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style2" style="direction: rtl">
                        &nbsp;</td>

                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style2" style="direction: rtl"></td>

                </tr>
                <tr>
                    <td class="auto-style12">
                        
                        &nbsp;</td>
                    <td class="auto-style12">
                        
                        &nbsp;</td>
                    
                    <td class="auto-style12">
                        
                        &nbsp;</td>
                    <td class="auto-style4">
                        
                        &nbsp;</td>
                    <td class="auto-style12">
                        
                        &nbsp;</td>
                    <td class="auto-style12">
                        
                        &nbsp;</td>
                    <td class="auto-style12">
                        
                        &nbsp;</td>
                    <td class="auto-style12">
                        
                        &nbsp;</td>
                    <td class="auto-style12">
                        
                        &nbsp;</td>
                    <td class="auto-style12">
                        
                        &nbsp;</td>
                    <td class="auto-style12">
                        
                        &nbsp;</td>
                    <td class="auto-style12">
                        
                        &nbsp;</td>
                    <td class="auto-style12">
                        
                        &nbsp;</td>
                    <td class="auto-style12">
                        
                        &nbsp;</td>
                    <td class="auto-style12">
                        
                    </td>
                    <td class="auto-style12">
                        
                        &nbsp;</td>
                    <td class="auto-style12">
                        
                        &nbsp;</td>
                    <td class="auto-style12">
                        
                        &nbsp;</td>
                    <td class="auto-style12">
                        
                    </td>
                    <td class="auto-style12">
                        <asp:TextBox ID="txtprice" runat="server" AutoPostBack="True" OnTextChanged="txtprice_TextChanged" ValidationGroup="c" CssClass="tb5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtprice" ErrorMessage="*" ForeColor="#FF3300" ValidationGroup="c"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style8">
                        <asp:Label ID="lblCountLast" runat="server" Text="السعر:"></asp:Label>
                    </td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style22">
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="#999966" OnSelectionChanged="Calendar1_SelectionChanged">
                            <SelectedDayStyle BackColor="#FF0066" />
                        </asp:Calendar>
                        <asp:TextBox ID="txtdate" runat="server" ReadOnly="True" OnTextChanged="txtdate_TextChanged" ValidationGroup="c" CssClass="tb5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdate" ErrorMessage="*" ForeColor="#FF3300" ValidationGroup="c"></asp:RequiredFieldValidator>
                    </td>
                    <td style="direction: rtl">
                        <asp:Label ID="lblDate" runat="server" Text="التاريخ:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td style="direction: rtl">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                   
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style23">
                        <asp:TextBox ID="txttotal" runat="server" ReadOnly="True" TextMode="Number" OnTextChanged="txttotal_TextChanged" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:Label ID="lblCountLast0" runat="server" Text=":الاجمالى"></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="auto-style2" style="direction: rtl">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style15">
                        &nbsp;</td>
                    <td class="auto-style2" style="direction: rtl">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style10">
                                    <asp:Button ID="btnback2" runat="server"  Text="خروج" BorderStyle="Groove" Font-Bold="True" OnClick="btnback2_Click" />
                                </td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style10">
                                    <asp:Button ID="btnback1" runat="server"  Text="رجوع للقائمه الرئيسيه" BorderStyle="Groove" Font-Bold="True" PostBackUrl="~/Forms/Home.aspx" />
                                </td>
                    <td class="auto-style6"></td>
                    <td class="auto-style16">
                        <asp:Button ID="btnPay2" runat="server" Text="بحث" OnClick="btnPay2_Click" BorderStyle="Groove" Font-Bold="True" />
                        </td>
                    <td class="auto-style21">
                        &nbsp;</td>
                    <td class="auto-style17">
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="اضافة صنف للشراء" ValidationGroup="c" BorderStyle="Groove" Font-Bold="True" />
                    </td>
                </tr>
               
            </table>
            </div>

            <div id="divpay" runat="server" visible="false">
            
            </div>

      
        <div id="divsearch" runat="server" visible="false">

       
        <table class="auto-style19" align="right" style="background-color:blanchedalmond">
                            <tr>
                                <td class="auto-style20">
                                    <asp:Button ID="btnback" runat="server" OnClick="Button1_Click" Text="رجوع للاضافه" BorderStyle="Groove" Font-Bold="True" />
                                </td>
                                <td class="auto-style20">
                        <asp:TextBox ID="txtsearch" runat="server" CssClass="tb5"></asp:TextBox>
                   
                                </td>
                                <td>
                   
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text=" بحث باسم صنف الشراء" BorderStyle="Groove" Font-Bold="True" />

                 
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">&nbsp;</td>
                                <td class="auto-style20">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
            </table>
             </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnDataBound="GridView1_DataBound" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" PageSize="15" OnSorting="GridView1_Sorting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField CancelText="الغاء" DeleteText="مسح" EditText="تعديل" InsertText="ادخال" SelectText="اختيار العنصر" ShowSelectButton="True" />
                <asp:CommandField CancelText="الغاء" DeleteText="مسح" EditText="تعديل" InsertText="ادخال" NewText="جديد" SelectText="اختيار" ShowDeleteButton="True" UpdateText="تعديل" />
                <asp:CommandField CancelText="الغاء" DeleteText="مسح" EditText="تعديل" InsertText="ادخال" NewText="جديد" SelectText="اختيار" ShowEditButton="True" UpdateText="تحديث" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FF0066" ForeColor="#FFFFCC" HorizontalAlign="Center" BorderColor="#0066FF" BorderWidth="3px" Font-Bold="True" Font-Overline="False" Font-Size="Larger" Font-Strikeout="False" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#FF3300" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </form>
</body>
</html>
