<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="theSales.aspx.cs" Inherits="ERPOmarKamal.Forms.theSales" %>

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
            width: 637px;
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
        .auto-style19 {
           height: 26px;
           width: 575px;
           text-align: right;
       }
        .auto-style21 {
           width: 510px;
           direction: rtl;
           height: 33px;
           text-align: right;
       }
           .auto-style23 {
               height: 28px;
               width: 171px;
           }
           .auto-style24 {
               height: 28px;
               width: 441px;
               text-align: left;
               }
           .auto-style27 {
               border: 2px solid #456879;
               border-radius: 10px;
           }
           .auto-style29 {
               text-align: right;
           }
           .auto-style30 {
               height: 28px;
               width: 559px;
               text-align: left;
               }
           .auto-style31 {
               width: 186px;
           }
           .auto-style32 {
               direction: rtl;
           }
           .auto-style33 {
               height: 26px;
               text-align: right;
           }
           .auto-style34 {
               height: 26px;
               width: 577px;
           }
           .auto-style35 {
               width: 853px;
               direction: rtl;
           }
           .auto-style36 {
               height: 26px;
               width: 853px;
               text-align: right;
           }
           .auto-style37 {
               height: 26px;
               width: 853px;
           }
           .auto-style38 {
               width: 853px;
               height: 33px;
           }
           .auto-style39 {
               height: 26px;
               width: 853px;
               direction: rtl;
           }
           .auto-style40 {
               height: 26px;
               width: 390px;
               direction: rtl;
           }
           .auto-style41 {
               width: 390px;
               direction: rtl;
           }
           .auto-style42 {
               height: 26px;
               width: 390px;
               text-align: right;
           }
           .auto-style43 {
               height: 26px;
               width: 390px;
           }
           .auto-style44 {
               width: 390px;
               height: 33px;
           }
           .auto-style45 {
               height: 26px;
               width: 510px;
               text-align: right;
           }
        </style>

</head>
<body style="background-color:antiquewhite">
    <form id="form1" runat="server">
        <div id="divadditem" runat="server">
            <table class="auto-style1" style="background-color:burlywood">
                <tr>
                    <td class="auto-style11">
                        <asp:TextBox ID="txttawreed" runat="server" AutoPostBack="True" OnTextChanged="txttawreed_TextChanged" ValidationGroup="b" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td class="auto-style11">
                        <asp:Label ID="lblcountFirst0" runat="server" Text="التحصيل:"></asp:Label>
                    </td>
                    <td class="auto-style39">
                        <asp:TextBox ID="txtcount" runat="server" AutoPostBack="True" OnTextChanged="txtcount_TextChanged" TextMode="Number" ValidationGroup="b" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td class="auto-style40">
                        <asp:Label ID="lblcountFirst" runat="server" Text="العدد:"></asp:Label>
                    </td>

                    <td class="auto-style3"></td>
                    <td class="auto-style45">
                        <asp:DropDownList ID="DropDownList1"  runat="server" DataSourceID="SqlDataSource1" DataTextField="اسم_الصنف" DataValueField="الكود" OnDataBound="DropDownList1_DataBound">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2" style="direction: rtl">
                        
                        <asp:Label ID="lblItemName0" runat="server" Text="اسم الصنف:"></asp:Label>
                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style39"></td>
                    <td class="auto-style40"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style3">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:omarKamalConnectionString2 %>" SelectCommand="SELECT [الكود], [اسم الصنف] AS اسم_الصنف FROM [المخزن]"></asp:SqlDataSource>
                    </td>
                    <td class="auto-style2" style="direction: rtl"></td>

                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style39">&nbsp;</td>
                    <td class="auto-style40">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style2" style="direction: rtl">
                        &nbsp;</td>

                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style39">&nbsp;</td>
                    <td class="auto-style40">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2" style="direction: rtl">&nbsp;</td>

                </tr>
                <tr>
                    <td class="auto-style12">
                        <asp:TextBox ID="txtraseed" runat="server" OnTextChanged="txtraseed_TextChanged" ReadOnly="True" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td class="auto-style12">
                        <asp:Label ID="lblCountLast1" runat="server" Text="المتبقى:"></asp:Label>
                    </td>
                    <td class="auto-style35">
                        <asp:TextBox ID="txtprice" runat="server" AutoPostBack="True" OnTextChanged="txtprice_TextChanged" ValidationGroup="b" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td class="auto-style41">
                        <asp:Label ID="lblCountLast" runat="server" Text="السعر:"></asp:Label>
                    </td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style13">
                        <asp:TextBox ID="txtModel" runat="server" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td style="direction: rtl">
                        <asp:Label ID="lblModel" runat="server" Text="الموديل:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style35">&nbsp;</td>
                    <td class="auto-style41">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td style="direction: rtl">&nbsp;</td>
                </tr>
                <tr>
                   <td>

                   </td>
                    <td></td>
                    <td class="auto-style36">
                        <asp:TextBox ID="txttotal" runat="server" ReadOnly="True" TextMode="Number" OnTextChanged="txttotal_TextChanged" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td class="auto-style42">
                        <asp:Label ID="lblCountLast0" runat="server" Text=":الاجمالى"></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style33">
                        <div class="auto-style32">
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
                        <asp:TextBox ID="txtdate" runat="server" ReadOnly="True" style="direction:ltr" OnTextChanged="txtdate_TextChanged" ValidationGroup="b" CssClass="tb5"></asp:TextBox>
                    </td>
                    <td class="auto-style2" style="direction: rtl">
                        <asp:Label ID="lblDate" runat="server" Text="التاريخ:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style19" runat="server" id="tdtxtclient">
                        <asp:TextBox ID="txtclient" runat="server" TextMode="MultiLine" ValidationGroup="b" CssClass="auto-style27" Height="46px" ></asp:TextBox>
                    </td>
                    <td class="auto-style19" runat="server" id="lblclient">
                        <asp:Label ID="lblCountLast2" runat="server" Text=":اسم العميل"></asp:Label>
                    </td>
                    <td class="auto-style37">&nbsp;</td>
                    <td class="auto-style43">&nbsp;</td>
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
                    <td class="auto-style10">
                                    <asp:Button ID="btnback3" runat="server"  Text="خروج" BorderStyle="Groove" Font-Bold="True" OnClick="btnback3_Click" />
                                </td>
                    <td class="auto-style38"></td>
                    <td class="auto-style44">
                                    <asp:Button ID="btnback0" runat="server"  Text="رجوع للقائمه الرئيسيه" BorderStyle="Groove" Font-Bold="True" PostBackUrl="~/Forms/Home.aspx" />
                                </td>
                    <td class="auto-style16">
                        <asp:Button ID="btnPay2" runat="server" Text="بحث" OnClick="btnPay2_Click" BorderStyle="Groove" Font-Bold="True" />
                        </td>
                    <td class="auto-style21">
                        &nbsp;</td>
                    <td class="auto-style17">
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="بيع صنف" ValidationGroup="b" BorderStyle="Groove" Font-Bold="True" Height="29px" />
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
                   
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text=" بحث باسم عميل" BorderStyle="Groove" Font-Bold="True" />

                 
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">&nbsp;</td>
                                <td class="auto-style20">
                        <asp:TextBox ID="txtitemsearch0" runat="server" CssClass="tb5"></asp:TextBox>
                   
                                </td>
                                <td>
                   
                        <asp:Button ID="btnSearchitem" runat="server"  Text=" بحث باسم الصنف" BorderStyle="Groove" Font-Bold="True" OnClick="btnSearchitem_Click" />

                 
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">&nbsp;</td>
                                <td class="auto-style20">
                        <asp:Calendar ID="Calendar2" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                            <OtherMonthDayStyle ForeColor="#CC9966" />
                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True"  />
                            <SelectorStyle BackColor="#FFCC66" />
                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                        </asp:Calendar>
                                </td>
                                <td>
                   
                        <asp:Button ID="btnSearch0" runat="server" Text=" بحث بالتاريخ" OnClick="btnSearch0_Click" BorderStyle="Groove" Font-Bold="True" />

                 
                                </td>
                            </tr>
                <tr>
                                <td class="auto-style20">&nbsp;</td>
                                <td class="auto-style20">
                        <asp:TextBox ID="txtmonth" runat="server" CssClass="tb5" style="direction:ltr" TextMode="Month"></asp:TextBox>
                   
                                </td>
                                <td>
                   
                        <asp:Button ID="btnmonthSearch" runat="server"  Text=" بحث بالشهر" BorderStyle="Groove" Font-Bold="True" OnClick="btnmonthSearch_Click" style="height: 29px"  />

                 
                                </td>
                            </tr>
            </table>
                                    <asp:Button ID="btnback2" runat="server"  Text="خروج" BorderStyle="Groove" Font-Bold="True" OnClick="btnback2_Click" />
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
           <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateSelectButton="True" CellPadding="3" OnRowDeleting="GridView2_RowDeleting" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" OnDataBound="GridView2_DataBound" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowDataBound="GridView2_RowDataBound" PageSize="15" OnSorting="GridView2_Sorting" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnSelectedIndexChanging="GridView2_SelectedIndexChanging" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
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
        <div id="divtotalday" runat="server" visible="false">

            <table>
                <tr>
                    <td class="auto-style34">
                        &nbsp;</td>
                    <td class="auto-style31">
                        <asp:TextBox ID="txtalltotal" runat="server" ReadOnly="True" Width="112px"></asp:TextBox>
                       
                    </td>
                      <td class="auto-style23">
                         <asp:Label ID="lblalltotal" runat="server" Text=":اجمالى المبيعات "></asp:Label>
                        </td>
                    <td class="auto-style29">
                        <asp:TextBox ID="txttawtotal" runat="server" ReadOnly="True" Width="143px"></asp:TextBox>
                        
                    </td>
                       <td class="auto-style31">
                        <asp:Label ID="lbltawtotal" runat="server" Text=":اجمالى الوارد "></asp:Label>
                        </td>
                    <td class="auto-style30">
                          <asp:Label ID="lbltxtrasedd" runat="server" Text=" اجمالى المنصرف :"></asp:Label>
                        <asp:TextBox ID="txtrasedd" runat="server" ReadOnly="True" Width="84px"></asp:TextBox>
                      
                    </td>
                      <td class="auto-style24">
                          <asp:Label ID="lblrasedyomy" runat="server" Text="  الرصيد اليومى/الشهرى :"></asp:Label>
                        <asp:TextBox ID="txtrasedyomy" runat="server" ReadOnly="True" Width="131px"></asp:TextBox>
                      
                    </td>

                </tr>
                <tr>
                    <td>                        &nbsp;</td>
                    <td>

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
