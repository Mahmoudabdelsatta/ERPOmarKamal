using ERPOmarKamal.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPOmarKamal.Forms
{
    public partial class clients : System.Web.UI.Page
    {
        System.Data.DataTable mytable = new System.Data.DataTable();
        System.Data.DataRow dr = null;
        System.Data.DataRow dr2 = null;
        private omarKamalEntities cx = new omarKamalEntities();
        string cs = ConfigurationManager.ConnectionStrings["omarKamalEntitiescon"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtdate.Text = Calendar1.SelectedDate.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString();
        }

        protected void txtdate_TextChanged(object sender, EventArgs e)
        {
          
        }

        protected void btnPay2_Click(object sender, EventArgs e)
        {
            divsearch.Visible = true;
            divadditem.Visible = false;

            btnback.Visible = true;
        }

        protected void txtAdd_Click(object sender, EventArgs e)
        {
          
            cx.العملاء.Add(new العملاء()
            {
                اسم_العميل = txtItemName.Text,
                التاريخ = Convert.ToDateTime(txtdate.Text),
               

            });
            string s = Session["userName"].ToString();
            cx.SaveChanges();
            cx.logs.Add(new log()
            {
                اسم_صاحب_العمليه = Session["userName"].ToString(),
                التاريخ = DateTime.Now,
                التفاصيل = txtItemName.Text + "دخول صنف جديد للمخزن",
                نوع_العمليه = "ادخال صنف "

            });
            cx.SaveChanges();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('تم اضافة العميل بنجاح')", true);

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowDatabyClient();
            divtotalday.Visible = true;
            btnexceldownload.Visible = true;

        }
        protected void ShowDatabyClient()
        {
            double? tot = 0;
            double? tawtotal = 0;
            double? rased = 0;
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();



            adapt = new SqlDataAdapter(" SELECT [id] ,[اسم العميل] ,[اجمالى المبلغ],[المدفوع] ,[المتبقي] ,المخزن.[اسم الصنف],العملاء.التاريخ FROM[dbo].[العملاء] left outer join المخزن on العملاء.[رقم كود الصنف]=المخزن.الكود where [اسم العميل] like " + "N'" + "%" + txtsearch.Text + "%" + "' ", con);

            adapt.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i].Field<double?>("اجمالى المبلغ") != null)
                    {
                        tot += dt.Rows[i].Field<double?>("اجمالى المبلغ");
                    }

                    if (dt.Rows[i].Field<double?>("المدفوع") != null)
                    {
                        tawtotal += dt.Rows[i].Field<double?>("المدفوع");
                    }
                    //    if (dt.Rows[i].Field<double?>("الرصيد")!= null)
                    //    {
                    //    rased += dt.Rows[i].Field<double?>("الرصيد");
                    //}




                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
                divtotalday.Visible = true;
                lblalltotal.Visible = true;
                txtalltotal.Visible = true;
                txtalltotal.Text = tot.ToString();
                lbltawtotal.Visible = true;
                txttawtotal.Visible = true;
                txttawtotal.Text = tawtotal.ToString();
                rased = tot - tawtotal;
                lbltxtrasedd.Visible = true;
                txtrasedd.Visible = true;
                txtrasedd.Text = rased.ToString();
                GridView1.Visible = true;
                GridView1.DataSource = dt;
                GridView1.DataBind();
               
            }
            con.Close();




        }

        protected void btnSearchitem_Click(object sender, EventArgs e)
        {
            btnexceldownload.Visible = true;
         
            ShowDatabyItem();

        }
        protected void ShowDatabyItem()
        {
            double? tot = 0;
            double? tawtotal = 0;
            double? rased = 0;
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();



            adapt = new SqlDataAdapter(" SELECT [id] ,[اسم العميل] ,[اجمالى المبلغ],[المدفوع] ,[المتبقي] ,المخزن.[اسم الصنف],العملاء.التاريخ FROM[dbo].[العملاء],المخزن where العملاء.[رقم كود الصنف]=المخزن.الكود   and [اسم الصنف] like " + "N'" + "%" + txtitemsearch0.Text + "%" + "' ", con);

            adapt.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i].Field<double?>("اجمالى المبلغ") != null)
                    {
                        tot += dt.Rows[i].Field<double?>("اجمالى المبلغ");
                    }

                    if (dt.Rows[i].Field<double?>("المدفوع") != null)
                    {
                        tawtotal += dt.Rows[i].Field<double?>("المدفوع");
                    }
                    //    if (dt.Rows[i].Field<double?>("الرصيد")!= null)
                    //    {
                    //    rased += dt.Rows[i].Field<double?>("الرصيد");
                    //}

                }



                    GridView1.Visible = true;
                GridView1.DataSource = dt;
                GridView1.DataBind();
               
            }
            con.Close();

                divtotalday.Visible = true;
                lblalltotal.Visible = true;
                txtalltotal.Visible = true;
                txtalltotal.Text = tot.ToString();
                lbltawtotal.Visible = true;
                txttawtotal.Visible = true;
                txttawtotal.Text = tawtotal.ToString();
                rased = tot - tawtotal;
                lbltxtrasedd.Visible = true;
                txtrasedd.Visible = true;
                txtrasedd.Text = rased.ToString();


            }

        protected void btnPay1_Click(object sender, EventArgs e)
        {
            divpay.Visible = true;
            btnback.Visible = true;
            divadditem.Visible = false;
            divsearch.Visible = false;
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            string x = txtdate0.Text.Substring(0, 18);
           
            string name = GridView1.SelectedRow.Cells[9].Text.ToString();
            if (string.IsNullOrWhiteSpace(name) ||name== "&nbsp;")
            {
               
                DateTime date = Convert.ToDateTime(x);
                cx.العملاء.Add(new العملاء()
                {
                    اسم_العميل = GridView1.SelectedRow.Cells[5].Text,
                    التاريخ = date,
                    المدفوع = Convert.ToDouble(txtMoney.Text),
                    رقم_كود_الصنف = null

                });
                cx.SaveChanges();
                cx.logs.Add(new log()
                {
                    اسم_صاحب_العمليه = Session["userName"].ToString(),
                    التاريخ = DateTime.Now,
                    التفاصيل = " دفع",
                    نوع_العمليه = "دفع  "

                });
                cx.SaveChanges();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('تم الدفع بنجاح')", true);
                ShowDatabyClient();
            }
            else
            {
                int itemId = cx.المخزن.FirstOrDefault(y => y.اسم_الصنف == name).الكود;
                DateTime date = Convert.ToDateTime(x);
                cx.العملاء.Add(new العملاء()
                {
                    اسم_العميل = GridView1.SelectedRow.Cells[5].Text,
                    التاريخ = date,
                    المدفوع = Convert.ToDouble(txtMoney.Text),
                    رقم_كود_الصنف = itemId

                });
                cx.SaveChanges();
                cx.logs.Add(new log()
                {
                    اسم_صاحب_العمليه = Session["userName"].ToString(),
                    التاريخ = DateTime.Now,
                    التفاصيل = " دفع",
                    نوع_العمليه = "دفع  "

                });
                cx.SaveChanges();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('تم الدفع بنجاح')", true);

                ShowDatabyClient();
            }
            
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowDatabyClient();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            btnexceldownload.Visible = true;

            ShowDatabyClient();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Change the index number as per your gridview design
                e.Row.Cells[4].Enabled = false;
                e.Row.Cells[9].Enabled = false;
                e.Row.Cells[10].Enabled = false;


            }
            if (e.Row.RowType != DataControlRowType.DataRow) return;
           
            var deleteButton = (LinkButton)e.Row.Cells[0].Controls[2];
            var deleteButton2 = (LinkButton)e.Row.Cells[2].Controls[0];
            if (deleteButton.Text == "Delete"|| deleteButton2.Text=="مسح")
            {
                deleteButton.OnClientClick = "return confirm('هل تريد مسح هذا العنصر؟');";
                deleteButton2.OnClientClick = "return confirm('هل تريد مسح هذا العنصر؟');";

            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            con = new SqlConnection(cs);


            int id1 = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[4].Text.ToString());
            string itemName = GridView1.Rows[e.RowIndex].Cells[5].Text.ToString();
            cx.logs.Add(new log()
            {
                اسم_صاحب_العمليه = Session["userName"].ToString(),
                التاريخ = DateTime.Now,
                التفاصيل = GridView1.Rows[e.RowIndex].Cells[5].Text.ToString() + "  مسح عميل",
                نوع_العمليه = "مسح  "

            });
            cx.SaveChanges();
            con.Open();
            cmd = new SqlCommand("delete from العملاء where id='" + id1 + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            GridView1.Visible = true;
            btnexceldownload.Visible = true;

            ShowDatabyClient();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            btnexceldownload.Visible = true;

            GridView1.EditIndex = e.NewEditIndex;
            ShowDatabyClient();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            btnexceldownload.Visible = true;

            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            TextBox textid = (TextBox)row.Cells[4].Controls[0];
            int id1 = Convert.ToInt32(textid.Text);

            TextBox textclientName = (TextBox)row.Cells[5].Controls[0];
            //   TextBox textitemName = (TextBox)row.Cells[7].Controls[0];
            TextBox textModel = (TextBox)row.Cells[8].Controls[0];

            TextBox texttotal = (TextBox)row.Cells[6].Controls[0];
            TextBox texttawreed = (TextBox)row.Cells[7].Controls[0];
            TextBox textraseed = (TextBox)row.Cells[8].Controls[0];
            cx.logs.Add(new log()
            {
                اسم_صاحب_العمليه = Session["userName"].ToString(),
                التاريخ = DateTime.Now,
                التفاصيل = GridView1.Rows[e.RowIndex].Cells[5].Text.ToString() + " تعديل عميل",
                نوع_العمليه = "تعديل  "

            });
            cx.SaveChanges();
            con = new SqlConnection(cs);
            con.Open();
            //updating the record  
            SqlCommand cmd = new SqlCommand("Update [dbo].[العملاء] set [اسم العميل]=N'" + textclientName.Text + "',[اجمالى المبلغ]='" + texttotal.Text + "',[المدفوع]='" + texttawreed.Text + "',[المتبقي]='" + textraseed.Text + "' where id=" + id1, con);
            cmd.ExecuteNonQuery();
            con.Close();
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            ShowDatabyClient();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            btnexceldownload.Visible = true;

            GridView1.DataBind();
        }

        protected void btnback0_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("clients.aspx");
        }

       

        protected void btnback3_Click(object sender, EventArgs e)
        {

        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtdate0.Text = Calendar2.SelectedDate.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString();
        }

        protected void txtdate0_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtMoney_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnback3_Click1(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("login.aspx");
        }

        protected void btnback2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("login.aspx");
        }

        protected void btnexceldownload_Click(object sender, EventArgs e)
        {
            Create_DataTable();         // CREATE A DATATABLE.

            // CALCULATE VALUES FOR GRAND TOTAL.


            // NOW ASSIGN DATA TO A DATAGRID.
            DataGrid dg = new DataGrid();
            dg.DataSource = mytable;
            dg.DataBind();

            // THE EXCEL FILE.
            string sFileName = "عملاء-" + System.DateTime.Now.Date + ".xls";
            sFileName = sFileName.Replace("/", "");

            // SEND OUTPUT TO THE CLIENT MACHINE USING "RESPONSE OBJECT".
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + sFileName);
            Response.ContentType = "application/vnd.ms-excel";
            EnableViewState = false;

            System.IO.StringWriter objSW = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter objHTW = new System.Web.UI.HtmlTextWriter(objSW);

            dg.HeaderStyle.Font.Bold = true;     // SET HEADER AS BOLD.
            dg.RenderControl(objHTW);

            // STYLE THE SHEET AND WRITE DATA TO IT.
            Response.Write("<style> TABLE { border:dotted 1px #999; } " +
                    "TD { border:dotted 1px #D5D5D5; text-align:center } </style>");
            Response.Write(objSW.ToString());

            // ADD A ROW AT THE END OF THE SHEET SHOWING A RUNNING TOTAL OF PRICE.


            Response.End();
            dg = null;
        }
        private void Create_DataTable()
        {
            int iRowCnt = 0;

            // CREATE A DATATABLE AND ADD COLUMNS TO IT.
            mytable.Columns.Add(new System.Data.DataColumn("اسم العميل",
              System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("اسم الصنف", System.Type.GetType("System.String")));

            mytable.Columns.Add(new System.Data.DataColumn("التاريخ",
              System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("اجمالى المبلغ", System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("المدفوع",
                 System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("المتبقى",
               System.Type.GetType("System.String")));
           
            // REMOVE PAGING TO HELP EXPORT ENTIRE GRIDVIEW TO EXCEL.
            ShowDatabyClient();
            GridView1.AllowPaging = false;
            GridView1.DataBind();

            foreach (GridViewRow row in GridView1.Rows)
            {
                dr = mytable.NewRow();
                dr[0] = GridView1.Rows[iRowCnt].Cells[5].Text;
                dr[1] = GridView1.Rows[iRowCnt].Cells[9].Text;
                dr[2] = GridView1.Rows[iRowCnt].Cells[10].Text;
                dr[3] = GridView1.Rows[iRowCnt].Cells[6].Text;
                dr[4] = GridView1.Rows[iRowCnt].Cells[7].Text;
                dr[5] = GridView1.Rows[iRowCnt].Cells[8].Text;
                mytable.Rows.Add(dr);

                iRowCnt += 1;
            }
            dr2 = mytable.NewRow();
            dr2[0] = "";
            dr2[1] = "";
            dr2[2] = "";
            dr2[3] = "الاجمالى :"+ txtalltotal.Text;
            dr2[4] = "اجمالى الوارد :" + txttawtotal.Text;
            dr2[5] = "اجمالى المنصرف :"+ txtrasedd.Text;
            mytable.Rows.Add(dr2);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            divpay.Visible = true;
            btnexceldownload.Visible = true;
            btnback.Visible = true;
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            divpay.Visible = true;
            btnexceldownload.Visible = true;
            btnback.Visible = true;
        }
    }
}