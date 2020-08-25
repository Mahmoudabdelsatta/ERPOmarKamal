<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="suppliers.aspx.cs" Inherits="ERPOmarKamal.Forms.suppliers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
         <link href="../css/select2.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../Scripts/select2.js"></script>
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
            width: 472px;
        }
        .auto-style7 {
           height: 26px;
           width: 472px;
           direction: rtl;
       }
        .auto-style8 {
           width: 472px;
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
           width: 472px;
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
           width: 483px;
           direction: rtl;
           height: 33px;
           text-align: right;
       }
        .auto-style22 {
           width: 100%;
       }
       .auto-style23 {
           text-align: right;
       }
       .auto-style24 {
           direction: rtl;
           width: 394px;
       }
       .auto-style25 {
           text-align: right;
           width: 982px;
       }
       .auto-style26 {
           width: 982px;
       }
       .auto-style27 {
           text-align: right;
           width: 394px;
           direction: rtl;
       }
        .auto-style28 {
           text-align: right;
           width: 394px;
       }
        .auto-style29 {
           border: 2px solid #456879;
           border-radius: 10px;
       }
        .auto-style30 {
           direction: rtl;
           width: 435px;
       }
       .auto-style31 {
           text-align: right;
           width: 75px;
       }
       .auto-style32 {
           width: 585px;
           text-align: left;
       }
        .auto-style33 {
           width: 99%;
       }
        .auto-style34 {
           text-align: right;
           width: 4px;
       }
       .auto-style35 {
           width: 4px;
       }
        .auto-style36 {
           text-align: left;
           width: 982px;
       }
        .auto-style37 {
           height: 26px;
           width: 483px;
           direction: rtl;
       }
       .auto-style38 {
           height: 26px;
           width: 483px;
       }
       .auto-style39 {
           width: 483px;
           direction: rtl;
       }
        .auto-style40 {
           direction: rtl;
       }
       .auto-style41 {
           height: 26px;
           width: 1122px;
           direction: rtl;
       }
       .auto-style42 {
           width: 1122px;
           direction: rtl;
       }
       .auto-style43 {
           height: 26px;
           width: 1122px;
           text-align: right;
       }
       .auto-style44 {
           height: 26px;
           width: 1122px;
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
                    <td class="auto-style41">
                        &nbsp;</td>
                    <td class="auto-style7">
                        &nbsp;</td>

                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style37">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="1">اضافة مورد جديد</asp:ListItem>
                            <asp:ListItem Value="2">اضافة صنف لمورد موجود</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="auto-style2" style="direction: rtl">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:TextBox ID="txttawreed" runat="server" AutoPostBack="True" OnTextChanged="txttawreed_TextChanged" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td class="auto-style11">
                        <asp:Label ID="lblcountFirst0" runat="server" Text="توريد:"></asp:Label>
                    </td>
                    <td class="auto-style41">
                        <asp:TextBox ID="txtcount" runat="server" AutoPostBack="True" OnTextChanged="txtcount_TextChanged" TextMode="Number" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="lblcountFirst" runat="server" Text="العدد:"></asp:Label>
                    </td>

                    <td class="auto-style3"></td>
                    <td class="auto-style37">
                        <asp:TextBox ID="txtsupplierName" runat="server" Visible="false" TextMode="MultiLine" Width="482px" CssClass="auto-style29" Height="43px"></asp:TextBox>
                    </td>
                    <td class="auto-style2" style="direction: rtl">
                        <asp:Label ID="lblItemName" Visible="false" runat="server" Text="اسم المورد:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style41"></td>
                    <td class="auto-style7"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style37">
                        <asp:DropDownList ID="DropDownList3" Visible="false" runat="server" DataSourceID="SqlDataSource3" DataTextField="اسم_المورد"  CssClass="tb5">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:omarKamalConnectionString3 %>" SelectCommand="SELECT DISTINCT [اسم المورد] AS اسم_المورد FROM [الموردين]"></asp:SqlDataSource>
                    </td>
                    <td class="auto-style2" style="direction: rtl">
                        <asp:Label ID="lblItemName2" runat="server" Visible="false" Text=" :اسم المورد"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style41">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style37">
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="اسم_الصنف" DataValueField="الكود" CssClass="tb5">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:omarKamalConnectionString2 %>" SelectCommand="SELECT [الكود], [اسم الصنف] AS اسم_الصنف FROM [المخزن]"></asp:SqlDataSource>
                    </td>
                    <td class="auto-style2" style="direction: rtl">
                        <asp:Label ID="lblItemName0" runat="server" Text="اسم الصنف:"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style11"></td>
                    <td class="auto-style11"></td>
                    <td class="auto-style41"></td>
                    <td class="auto-style7"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style38"></td>
                    <td class="auto-style2" style="direction: rtl"></td>

                </tr>
                <tr>
                    <td class="auto-style12">
                        <asp:TextBox ID="txtraseed" runat="server" OnTextChanged="txtraseed_TextChanged" ReadOnly="True" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td class="auto-style12">
                        <asp:Label ID="lblCountLast1" runat="server" Text="الرصيد:"></asp:Label>
                    </td>
                    <td class="auto-style42">
                        <asp:TextBox ID="txtprice" runat="server" AutoPostBack="True" OnTextChanged="txtprice_TextChanged" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:Label ID="lblCountLast" runat="server" Text="السعر:"></asp:Label>
                    </td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style39">
                        <asp:TextBox ID="txtModel" runat="server" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td style="direction: rtl">
                        <asp:Label ID="lblModel" runat="server" Text="الموديل:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style42">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style39">&nbsp;</td>
                    <td style="direction: rtl">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style43">
                        <asp:TextBox ID="txttotal" runat="server" ReadOnly="True" TextMode="Number" OnTextChanged="txttotal_TextChanged" style="height: 25px" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:Label ID="lblCountLast0" runat="server" Text=":الاجمالى"></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style37">
                        <div class="auto-style40">
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
                        <asp:TextBox ID="txtdate" runat="server" ReadOnly="True" style="direction:ltr" OnTextChanged="txtdate_TextChanged" CssClass="tb5" ValidationGroup="a"></asp:TextBox>
                    </td>
                    <td class="auto-style2" style="direction: rtl">
                        <asp:Label ID="lblDate" runat="server" Text="التاريخ:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style44"></td>
                    <td class="auto-style5"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style37">
                        &nbsp;</td>
                    <td class="auto-style2" style="direction: rtl">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">
                                    <asp:Button ID="btnback2" runat="server"  Text="خروج" BorderStyle="Groove" Font-Bold="True" OnClick="btnback2_Click" />
                                </td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style17" colspan="2">
                                    <asp:Button ID="btnback1" runat="server"  Text="رجوع للقائمه الرئيسيه" BorderStyle="Groove" Font-Bold="True" PostBackUrl="~/Forms/Home.aspx" />
                                </td>
                    <td class="auto-style16">
                        <asp:Button ID="btnPay2" runat="server" Text="بحث" OnClick="btnPay2_Click" BorderStyle="Groove" Font-Bold="True" />
                        </td>
                    <td class="auto-style21">
                        <asp:Button ID="btnPay1" runat="server" Text="دفع" OnClick="btnPay1_Click" BorderStyle="Groove" Font-Bold="True" />
                   
                                <br />
                   
                                </td>
                    <td class="auto-style17">
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="اضافة " ValidationGroup="a" BorderStyle="Groove" Font-Bold="True" />
                    </td>
                </tr>
               
            </table>
            </div>

            <div id="divpay" runat="server" visible="false">
            <table class="auto-style22" style="background-color:aliceblue;border-style:solid">
                <tr>
                    <td class="auto-style25">&nbsp;</td>
                    <td class="auto-style28">
                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="اسم_المورد"  CssClass="tb5">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:omarKamalConnectionString3 %>" SelectCommand="SELECT DISTINCT [اسم المورد] AS اسم_المورد FROM [الموردين]"></asp:SqlDataSource>
                    </td>
                    <td class="auto-style23">
                        <asp:Label ID="lblItemName1" runat="server" Text=" :اسم المورد"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style25">&nbsp;</td>
                    <td class="auto-style28">&nbsp;</td>
                    <td class="auto-style23">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style26">&nbsp;</td>
                    <td class="auto-style27">
                       
                        <div class="auto-style40">
                       
                        <asp:Calendar ID="Calendar2" runat="server" BackColor="#FFFFCC" OnSelectionChanged="Calendar2_SelectionChanged" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                            <OtherMonthDayStyle ForeColor="#CC9966" />
                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                            <SelectorStyle BackColor="#FFCC66" />
                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                        </asp:Calendar>
                            </div>
                            <asp:TextBox ID="txtdate0" runat="server" OnTextChanged="txtdate0_TextChanged" style="direction:ltr" Height="25px" ReadOnly="True" ValidationGroup="pay" CssClass="tb5"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdate0" ErrorMessage="*" ForeColor="#FF3300" ValidationGroup="pay">يجب اختيار تاريخ</asp:RequiredFieldValidator>
                            
                        
                        
                    &nbsp;
                            
                        
                        
                    </td>
                    <td class="auto-style23">
                        <asp:Label ID="lblDate0" runat="server" Text=":التاريخ"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style26">&nbsp;</td>
                    <td class="auto-style24">&nbsp;</td>
                    <td class="auto-style23">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style26">&nbsp;</td>
                    <td class="auto-style24">
                        <asp:TextBox ID="txtMoney" runat="server" AutoPostBack="True" OnTextChanged="txtMoney_TextChanged" ValidationGroup="pay" CssClass="tb5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="pay" ControlToValidate="txtMoney">يجب ادخال مبلغ</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style23">
                        <asp:Label ID="lblcountFirst1" runat="server" Text=":المبلغ"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style26">&nbsp;</td>
                    <td class="auto-style24">&nbsp;</td>
                    <td class="auto-style23">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style26">&nbsp;</td>
                    <td class="auto-style24">
                                    <asp:Button ID="btnback0" runat="server" OnClick="btnback0_Click" Text="رجوع للاضافه" BorderStyle="Groove" Font-Bold="True" />
                                </td>
                    <td>
                        <asp:Button ID="btnPay0" runat="server" Text="دفع" OnClick="btnPay_Click" ValidationGroup="pay" BorderStyle="Groove" Font-Bold="True" />
                        </td>
                </tr>
            </table>
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
                   
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text=" بحث باسم المورد" BorderStyle="Groove" Font-Bold="True" />

                 
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">&nbsp;</td>
                                <td class="auto-style20">
                        <asp:TextBox ID="txtitemsearch0" runat="server" CssClass="tb5"></asp:TextBox>
                   
                                </td>
                                <td>
                   
                        <asp:Button ID="btnSearch0" runat="server"  Text=" بحث باسم الصنف" BorderStyle="Groove" Font-Bold="True" OnClick="btnSearch0_Click" />

                 
                                </td>
                            </tr>
            </table>
             </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateSelectButton="True" CellPadding="3" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnDataBound="GridView1_DataBound" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" PageSize="15" OnSorting="GridView1_Sorting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
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
        <div id="divtotalday" runat="server" visible="false" class="auto-style32">

            <table class="auto-style33">
                <tr>
                    <td class="auto-style34">
                        &nbsp;</td>
                    <td class="auto-style24">
                         <asp:Label ID="lblalltotal" runat="server" Text="الاجمالى :"></asp:Label>
                        <asp:TextBox ID="txtalltotal" runat="server" ReadOnly="True"></asp:TextBox>
                       
                    </td>
                      <td class="auto-style23">
                          &nbsp;</td>
                    <td class="auto-style30">
                        <asp:Label ID="lbltawtotal" runat="server" Text="اجمالى التوريد :"></asp:Label>
                        <asp:TextBox ID="txttawtotal" runat="server" ReadOnly="True"></asp:TextBox>
                        
                    </td>
                       <td class="auto-style31">
                           &nbsp;</td>
                    <td class="auto-style24">
                          <asp:Label ID="lbltxtrasedd" runat="server" Text=" الرصيد :"></asp:Label>
                        <asp:TextBox ID="txtrasedd" runat="server" ReadOnly="True"></asp:TextBox>
                      
                    </td>
                </tr>
                <tr>
                    <td class="auto-style35">&nbsp;</td>
                    <td class="auto-style36">
                        <asp:Button ID="btnexceldownload" runat="server" Text="تنزيل فى اكسيل" OnClick="btnexceldownload_Click" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
<script>
    $(function () {
        $("#<%=DropDownList1.ClientID%>").select2();
    })
</script>