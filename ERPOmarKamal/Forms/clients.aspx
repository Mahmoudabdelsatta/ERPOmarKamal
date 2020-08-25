<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clients.aspx.cs" Inherits="ERPOmarKamal.Forms.clients" %>

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
        .auto-style21 {
            border: 2px solid #456879;
            border-radius: 10px;
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
            text-align: left;
            width: 982px;
        }
        .auto-style35 {
            direction: rtl;
        }
        .auto-style36 {
            height: 26px;
            width: 510px;
            direction: rtl;
        }
    </style>
</head>
<body style="background-color:antiquewhite">
    <form id="form1" runat="server">
       
           <div id="divadditem" runat="server">

            <table class="auto-style1" style="background-color:burlywood" >
                <tr>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style7">
                        &nbsp;</td>
                    <td class="auto-style3"></td>
                    <td class="auto-style36">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtItemName" ErrorMessage="*" ForeColor="#FF3300" ValidationGroup="a">يجب ادخال اسم الصنف</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtItemName" runat="server" TextMode="MultiLine" Width="482px" CssClass="auto-style21" Height="47px"></asp:TextBox>
                    </td>
                    <td class="auto-style2" style="direction: rtl">
                        <asp:Label ID="lblItemName" runat="server" Text="اسم العميل :"></asp:Label>
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
                    <td class="auto-style12">
                        &nbsp;</td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style13">
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" OnSelectionChanged="Calendar1_SelectionChanged" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                            <OtherMonthDayStyle ForeColor="#CC9966" />
                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                            <SelectorStyle BackColor="#FFCC66" />
                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                        </asp:Calendar>
                    </td>
                    <td style="direction: rtl">
                        <asp:Label ID="lblDate" runat="server" Text="التاريخ:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style13">
                        <asp:TextBox ID="txtdate" runat="server" style="direction:ltr" ValidationGroup="a" CssClass="tb5" OnTextChanged="txtdate_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdate" ErrorMessage="*" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                    </td>
                    <td style="direction: rtl">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9"></td>
                    <td class="auto-style5"></td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style15">
                        &nbsp;</td>
                    <td class="auto-style2" style="direction: rtl">
                        &nbsp;</td>
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
                    <td class="auto-style16">
                        <asp:Button ID="btnPay2" runat="server" Text="بحث" OnClick="btnPay2_Click" BorderStyle="Groove" Font-Bold="True" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                  
                    <td class="auto-style17">
                        <asp:Button ID="txtAdd" runat="server"  Text="اضافة عميل" ValidationGroup="a" BorderStyle="Groove" Font-Bold="True" OnClick="txtAdd_Click" />
                    </td>

                </tr>
               
            </table>

        </div>
           
       

           <div id="divsearch" runat="server" visible="false">
               <table align="right" class="auto-style19" style="background-color:blanchedalmond">
                   <tr>
                       <td class="auto-style20">
                           <asp:Button ID="btnback" runat="server" BorderStyle="Groove" Font-Bold="True" OnClick="Button1_Click" Text="رجوع للاضافه" />
                       </td>
                       <td class="auto-style35">
                           <asp:TextBox ID="txtsearch" runat="server" CssClass="tb5"></asp:TextBox>
                       </td>
                       <td>
                           <asp:Button ID="btnSearch" runat="server" BorderStyle="Groove" Font-Bold="True" OnClick="btnSearch_Click" Text=" بحث باسم عميل" />
                       </td>
                   </tr>
                   <tr>
                       <td class="auto-style20">&nbsp;</td>
                       <td class="auto-style35">
                           <asp:TextBox ID="txtitemsearch0" runat="server" CssClass="tb5"></asp:TextBox>
                       </td>
                       <td>
                           <asp:Button ID="btnSearchitem" runat="server" BorderStyle="Groove" Font-Bold="True" OnClick="btnSearchitem_Click" Text=" بحث باسم الصنف" />
                       </td>
                   </tr>
                   <tr>
                       <td class="auto-style20">&nbsp;</td>
                       <td class="auto-style20">&nbsp;</td>
                       <td>&nbsp;</td>
                   </tr>
               </table>
               <asp:Button ID="btnback3" runat="server" BorderStyle="Groove" Font-Bold="True" Text="خروج" OnClick="btnback3_Click1" />
           </div>
           <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateSelectButton="True" CellPadding="3" OnDataBound="GridView1_DataBound" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSorting="GridView1_Sorting" PageSize="15" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
               <Columns>
                   <asp:CommandField CancelText="الغاء" DeleteText="مسح" EditText="تعديل" InsertText="ادخال" SelectText="اختيار العنصر" ShowSelectButton="True" />
                   <asp:CommandField CancelText="الغاء" DeleteText="مسح" EditText="تعديل" InsertText="ادخال" NewText="جديد" SelectText="اختيار" ShowDeleteButton="True" UpdateText="تعديل" />
                   <asp:CommandField CancelText="الغاء" DeleteText="مسح" EditText="تعديل" InsertText="ادخال" NewText="جديد" SelectText="اختيار" ShowEditButton="True" UpdateText="تحديث" />
               </Columns>
               <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
               <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
               <PagerStyle BorderColor="#0066FF" BorderWidth="3px" Font-Size="Larger" ForeColor="#8C4510" HorizontalAlign="Center" />
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
                    <td class="auto-style23">
                        &nbsp;</td>
                    <td class="auto-style24">
                         <asp:Label ID="lblalltotal" runat="server" Text="الاجمالى :"></asp:Label>
                        <asp:TextBox ID="txtalltotal" runat="server" ReadOnly="True"></asp:TextBox>
                       
                    </td>
                      <td class="auto-style23">
                          &nbsp;</td>
                    <td class="auto-style30">
                        <asp:Label ID="lbltawtotal" runat="server" Text="اجمالى الوارد :"></asp:Label>
                        <asp:TextBox ID="txttawtotal" runat="server" ReadOnly="True"></asp:TextBox>
                        
                    </td>
                       <td class="auto-style31">
                           &nbsp;</td>
                    <td class="auto-style24">
                          <asp:Label ID="lbltxtrasedd" runat="server" Text=" اجمالى المنصرف :"></asp:Label>
                        <asp:TextBox ID="txtrasedd" runat="server" ReadOnly="True"></asp:TextBox>
                      
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style34">
                        <asp:Button ID="btnexceldownload" runat="server" Text="تنزيل فى اكسيل" OnClick="btnexceldownload_Click" />
                    </td>
                </tr>
            </table>

        </div>
           <div id="divpay" runat="server" visible="false">
               
            <table class="auto-style22" style="background-color:aliceblue;border-style:solid">
                <tr>
                    <td class="auto-style25">&nbsp;</td>
                    <td class="auto-style28">
                        &nbsp;</td>
                    <td class="auto-style23">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style25">&nbsp;</td>
                    <td class="auto-style28">&nbsp;</td>
                    <td class="auto-style23">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style26">&nbsp;</td>
                    <td class="auto-style27">
                       
                        <div class="auto-style35">
                       
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
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdate0" ErrorMessage="*" ForeColor="#FF3300" ValidationGroup="pay">يجب اختيار تاريخ</asp:RequiredFieldValidator>
                            
                        
                        
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="pay" ControlToValidate="txtMoney">يجب ادخال مبلغ</asp:RequiredFieldValidator>
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
                                    &nbsp;</td>
                    <td>
                        <asp:Button ID="btnPay0" runat="server" Text="دفع" OnClick="btnPay_Click" ValidationGroup="pay" BorderStyle="Groove" Font-Bold="True" />
                        </td>
                </tr>
            </table>
            </div>
       

    </form>

</body>
</html>
