using ERPOmarKamal.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPOmarKamal.Forms
{
    public partial class suppliers : System.Web.UI.Page
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
            if (Session["userName"] == "" || Session["userName"] == null)
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(txtsupplierName.Text) && ViewState["supp"]!=null) || String.IsNullOrEmpty(txtdate.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('يجب ادخال اسم المورد فى حالة ظهوره وادخال التاريخ')", true);
            }
            else
            {

                string name = null;
                if (RadioButtonList1.SelectedValue == "1")
                {
                    name = txtsupplierName.Text;
                }
                else
                {
                    name = DropDownList3.SelectedItem.Text;
                }
                int f = 0;
                bool first = Int32.TryParse(txtcount.Text, out f);
                double l = 0;
                bool last = double.TryParse(txtprice.Text, out l);
                double tot = 0;
                bool total = double.TryParse(txttotal.Text, out tot);
                double ras = 0;
                bool raseed = double.TryParse(txtraseed.Text, out ras);
                double taw = 0;
                bool tawreed = double.TryParse(txttawreed.Text, out taw);
                cx.الموردين.Add(new الموردين()
                {
                    اسم_المورد = name,
                    الصنف = Convert.ToInt32(DropDownList1.SelectedItem.Value),
                    التاريخ = Convert.ToDateTime(txtdate.Text),
                    الموديل = txtModel.Text,
                    العدد = f,
                    السعر = l,
                    الاجمالى = tot,
                    الرصيد = ras,
                    تورديد = taw

                });
                int code = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                المخزن store = cx.المخزن.FirstOrDefault(x => x.الكود == code);
                int? rased = store.رصيد_اخر_المده;
                if (rased == null)
                {
                    rased = 0;
                }
                rased += f;
                store.رصيد_اخر_المده = rased;
                cx.Entry(store).State = System.Data.Entity.EntityState.Modified;
                cx.SaveChanges();
                cx.SaveChanges();
                cx.logs.Add(new log()
                {
                    اسم_صاحب_العمليه = Session["userName"].ToString(),
                    التاريخ = DateTime.Now,
                    التفاصيل = DropDownList1.SelectedItem.Text + " اضافة  مورد",
                    نوع_العمليه = "اضافة  "

                });
                cx.SaveChanges();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('تم اضافة المورد بنجاح')", true);
            }
        

        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtdate.Text = Calendar1.SelectedDate.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("suppliers.aspx");
        }
        protected void ShowData()
        {
            btnexceldownload.Visible = true;
            double? tot = 0;
            double? tawtotal = 0;
            double? rased = 0;
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();
            adapt = new SqlDataAdapter("SELECT dbo.[الموردين].الكود,[اسم المورد],dbo.[الموردين].[التاريخ],[اسم الصنف],dbo.[الموردين].[الموديل],[العدد],[السعر],[الاجمالى],[تورديد],[الرصيد]FROM [dbo].[الموردين],dbo.المخزن where المخزن.الكود=الموردين.الصنف and [اسم المورد ] like N" + "'" + "%" + txtsearch.Text.Trim().ToLower() + "%" + "' union SELECT dbo.[الموردين].الكود,[اسم المورد],dbo.[الموردين].[التاريخ],[اسم الصنف],dbo.[الموردين].[الموديل],[العدد],[السعر],[الاجمالى],[تورديد],[الرصيد]FROM [dbo].[الموردين] left outer join dbo.المخزن on المخزن.الكود=الموردين.الصنف where الصنف is null and [اسم المورد ] like N" + "'" + "%" + txtsearch.Text.Trim().ToLower() + "%" + "' ", con);
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i].Field<double?>("الاجمالى")!=null)
                    {
                        tot += dt.Rows[i].Field<double?>("الاجمالى");
                    }

                    if (dt.Rows[i].Field<double?>("تورديد")!= null)
                    {
                        tawtotal += dt.Rows[i].Field<double?>("تورديد");
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
            }
            con.Close();
        }
        protected void ShowitemData()
        {
            btnexceldownload.Visible = true;
            double? tot = 0;
            double? tawtotal = 0;
            double? rased = 0;
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();
            adapt = new SqlDataAdapter("SELECT dbo.[الموردين].الكود,[اسم المورد],dbo.[الموردين].[التاريخ],[اسم الصنف],dbo.[الموردين].[الموديل],[العدد],[السعر],[الاجمالى],[تورديد],[الرصيد]FROM [dbo].[الموردين],dbo.المخزن where المخزن.الكود=الموردين.الصنف and [اسم الصنف ] like N" + "'" + "%" + txtitemsearch0.Text.Trim().ToLower() + "%" + "' union SELECT dbo.[الموردين].الكود,[اسم المورد],dbo.[الموردين].[التاريخ],[اسم الصنف],dbo.[الموردين].[الموديل],[العدد],[السعر],[الاجمالى],[تورديد],[الرصيد]FROM [dbo].[الموردين] left outer join dbo.المخزن on المخزن.الكود=الموردين.الصنف where الصنف is null and [اسم الصنف ] like N" + "'" + "%" + txtitemsearch0.Text.Trim().ToLower() + "%" + "' ", con);
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i].Field<double?>("الاجمالى") != null)
                    {
                        tot += dt.Rows[i].Field<double?>("الاجمالى");
                    }

                    if (dt.Rows[i].Field<double?>("تورديد") != null)
                    {
                        tawtotal += dt.Rows[i].Field<double?>("تورديد");
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
            }
            con.Close();
        }
        protected void ShowAllData()
        {
            btnexceldownload.Visible = true;
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();
            adapt = new SqlDataAdapter("SELECT dbo.[الموردين].الكود,[اسم المورد],dbo.[الموردين].[التاريخ],[اسم الصنف],dbo.[الموردين].[الموديل],[العدد],[السعر],[الاجمالى],[تورديد],[الرصيد]FROM [dbo].[الموردين],dbo.المخزن where  [اسم المورد ] like N" + "'" + "%" + txtsearch.Text.Trim().ToLower() + "%" + "'", con);
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            con.Close();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            btnexceldownload.Visible = true;
            txtsearch.Visible = true;
            GridView1.Visible = true;
            divadditem.Visible = false;
            btnback.Visible = true;
            ShowData();
        }

        protected void txtprice_TextChanged(object sender, EventArgs e)
        {
            Regex r = new Regex("[+-]?([0-9]*[.])?[0-9]+"); // This is the main part, can be altered to match any desired form or limitations
            Match m = r.Match(txtprice.Text);
            if (m.Success)
            { }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('يجب ادخال رقم للسعر')", true);

            }
            if (!String.IsNullOrEmpty(txtprice.Text) && !String.IsNullOrEmpty(txtcount.Text))
            {
                decimal price = (Convert.ToDecimal(txtprice.Text) * Convert.ToInt32(txtcount.Text));
                txttotal.Text = price.ToString();
            }

        }

        protected void txttawreed_TextChanged(object sender, EventArgs e)
        {
            Regex r = new Regex("[+-]?([0-9]*[.])?[0-9]+"); // This is the main part, can be altered to match any desired form or limitations
            Match m = r.Match(txttawreed.Text);
            if (m.Success)
            { }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('يجب ادخال رقم للتوريد')", true);

            }
            if (!String.IsNullOrEmpty(txttawreed.Text) && !String.IsNullOrEmpty(txtcount.Text))
            {
                double raseed = (Convert.ToDouble(txttotal.Text) - Convert.ToInt32(txttawreed.Text));
                txtraseed.Text = raseed.ToString();
            }
           

        }

        protected void txtraseed_TextChanged(object sender, EventArgs e)
        {
            //Regex r = new Regex("[+-]?([0-9]*[.])?[0-9]+"); // This is the main part, can be altered to match any desired form or limitations
            //Match m = r.Match(txtraseed.Text);
            //if (m.Success)
            //{ }
            //else
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('يجب ادخال رقم للسعر')", true);

            //}
        }

        protected void txtcount_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtprice.Text)&& !String.IsNullOrEmpty(txtcount.Text))
            {
                double price = (Convert.ToDouble(txtprice.Text) * Convert.ToInt32(txtcount.Text));
                txttotal.Text = price.ToString();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Change the index number as per your gridview design
                e.Row.Cells[4].Enabled = false;
                e.Row.Cells[7].Enabled = false;


            }
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            var deleteButton = (LinkButton)e.Row.Cells[0].Controls[2];
            var deleteButton2 = (LinkButton)e.Row.Cells[2].Controls[0];
            if (deleteButton.Text == "Delete" || deleteButton2.Text == "مسح")
            {
                deleteButton.OnClientClick = "return confirm('هل تريد مسح هذا العنصر؟');";
                deleteButton2.OnClientClick = "return confirm('هل تريد مسح هذا العنصر؟');";

            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            btnexceldownload.Visible = true;
            GridView1.EditIndex = -1;
            ShowData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            btnexceldownload.Visible = true;
            con = new SqlConnection(cs);


            int id1 = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[4].Text.ToString());
            cx.logs.Add(new log()
            {
                اسم_صاحب_العمليه = Session["userName"].ToString(),
                التاريخ = DateTime.Now,
                التفاصيل = GridView1.Rows[e.RowIndex].Cells[5].Text+" مسح  مورد",
                نوع_العمليه = "مسح  "

            });
            cx.SaveChanges();
            con.Open();
            cmd = new SqlCommand("delete from الموردين where الكود='" + id1 + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            GridView1.Visible = true;
            ShowData();
           
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            btnexceldownload.Visible = true;
            GridView1.EditIndex = e.NewEditIndex;
            ShowData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            btnexceldownload.Visible = true;
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            TextBox textid = (TextBox)row.Cells[4].Controls[0];
            int id1 = Convert.ToInt32(textid.Text);
            TextBox textdate = (TextBox)row.Cells[6].Controls[0];
            TextBox textsupplierName = (TextBox)row.Cells[5].Controls[0];
         //   TextBox textitemName = (TextBox)row.Cells[7].Controls[0];
            TextBox textModel = (TextBox)row.Cells[8].Controls[0];
            TextBox textcount = (TextBox)row.Cells[9].Controls[0];
            TextBox textcost = (TextBox)row.Cells[10].Controls[0];
            TextBox texttotal = (TextBox)row.Cells[11].Controls[0];
            TextBox texttawreed = (TextBox)row.Cells[12].Controls[0];
            TextBox textraseed = (TextBox)row.Cells[13].Controls[0];
            // string x=textdate.Text.Substring(0,20);
           // DateTime date = Convert.ToDateTime(x);
            con = new SqlConnection(cs);
            cx.logs.Add(new log()
            {
                اسم_صاحب_العمليه = Session["userName"].ToString(),
                التاريخ = DateTime.Now,
                التفاصيل = GridView1.Rows[e.RowIndex].Cells[5].Text+" تعديل  مورد",
                نوع_العمليه = "تعديل  "

            });
            cx.SaveChanges();
            con.Open();
            //updating the record  
            SqlCommand cmd = new SqlCommand("Update [dbo].[الموردين] set [اسم المورد]=N'" + textsupplierName.Text + "',[الموديل]=N'" + textModel.Text + "',[التاريخ]='" + textdate.Text + "',[العدد]='" + textcount.Text + "',[السعر]='" + textcost.Text + "',[الاجمالى]='" + texttotal.Text + "',[تورديد]='" + texttawreed.Text + "',[الرصيد]='" + textraseed.Text + "' where الكود=" + id1, con);
            cmd.ExecuteNonQuery();
            con.Close();
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            ShowData();
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            btnexceldownload.Visible = true;
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            string x = txtdate0.Text.Substring(0, 18);
            DateTime date = Convert.ToDateTime(x);
            cx.الموردين.Add(new الموردين()
            {
                اسم_المورد = DropDownList2.SelectedItem.Text,
                التاريخ = date,
                تورديد = Convert.ToDouble(txtMoney.Text)

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

            GridView1.Visible = false;
        }

        protected void txtdate0_TextChanged(object sender, EventArgs e)
        {
            //int code = cx.الموردين.FirstOrDefault(x => x.الكود == Convert.ToInt32(DropDownList2.SelectedItem.Value)).الكود;
            //الموردين m = cx.الموردين.Where(x => x.الكود == code).FirstOrDefault();
            
           

        }

        protected void txtMoney_TextChanged(object sender, EventArgs e)
        {
            Regex r = new Regex("[+-]?([0-9]*[.])?[0-9]+"); // This is the main part, can be altered to match any desired form or limitations
            Match m = r.Match(txtMoney.Text);
            if (m.Success)
            { }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('يجب ادخال رقم وليس حروف للتوريد')", true);

            }
        }

        protected void btnPay1_Click(object sender, EventArgs e)
        {
            divpay.Visible = true;
            btnback.Visible = true;
            divadditem.Visible = false;
            divsearch.Visible = false;

        }

        protected void btnPay2_Click(object sender, EventArgs e)
        {
            divsearch.Visible = true;
            divadditem.Visible = false;
            divpay.Visible = false;
            btnback.Visible = true;
        }

        protected void btnback0_Click(object sender, EventArgs e)
        {
            Response.Redirect("suppliers.aspx");
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtdate0.Text = Calendar2.SelectedDate.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString();

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            btnexceldownload.Visible = true;
            GridView1.DataBind();
        }

        protected void txtdate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txttotal_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnback2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("login.aspx");
        }

        protected void btnSearch0_Click(object sender, EventArgs e)
        {
            btnexceldownload.Visible = true;
            txtsearch.Visible = true;
            GridView1.Visible = true;
            divadditem.Visible = false;
            btnback.Visible = true;
            ShowitemData();
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
            string sFileName = "موردين-" + System.DateTime.Now.Date + ".xls";
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
            mytable.Columns.Add(new System.Data.DataColumn("اسم المورد",
              System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("التاريخ", System.Type.GetType("System.String")));

            mytable.Columns.Add(new System.Data.DataColumn("اسم الصنف",
              System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("الموديل", System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("العدد",
                 System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("السعر",
               System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("الاجمالى",
              System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("توريد",
               System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("الرصيد",
               System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("الاجمالى الكلى",
        System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("اجمالى الوارد",
               System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("اجمالى المنصرف",
               System.Type.GetType("System.String")));

            // REMOVE PAGING TO HELP EXPORT ENTIRE GRIDVIEW TO EXCEL.
            ShowData();
            GridView1.AllowPaging = false;
            GridView1.DataBind();

            foreach (GridViewRow row in GridView1.Rows)
            {
                dr = mytable.NewRow();
                dr[0] = GridView1.Rows[iRowCnt].Cells[5].Text;
                dr[1] = GridView1.Rows[iRowCnt].Cells[6].Text;
                dr[2] = GridView1.Rows[iRowCnt].Cells[7].Text;
                dr[3] = GridView1.Rows[iRowCnt].Cells[8].Text;
                dr[4] = GridView1.Rows[iRowCnt].Cells[9].Text;
                dr[5] = GridView1.Rows[iRowCnt].Cells[10].Text;
                dr[6] = GridView1.Rows[iRowCnt].Cells[11].Text;
                dr[7] = GridView1.Rows[iRowCnt].Cells[12].Text;
                dr[8] = GridView1.Rows[iRowCnt].Cells[13].Text;
              
                mytable.Rows.Add(dr);

                iRowCnt += 1;
            }
            dr = mytable.NewRow();
            dr[0] = "";
            dr[1] = "";
            dr[2] = "";
            dr[3] = "";
            dr[4] = "";
            dr[5] = "";
            dr[6] = "";
            dr[7] = "";
            dr[8] = "";
            dr[9] = "الاجمالى :" + txtalltotal.Text;
            dr[10] = "اجمالى الوارد :" + txttawtotal.Text;
            dr[11] = "اجمالى المنصرف :" + txtrasedd.Text;
            mytable.Rows.Add(dr.ItemArray);
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue=="1")
            {
                DropDownList3.Visible = false;
                lblItemName2.Visible = false;
                txtsupplierName.Visible = true;
                lblItemName.Visible = true;
                ViewState["supp"] = "newsupp";
            }
            else
            {
                txtsupplierName.Visible = false;
                lblItemName.Visible = false;
                DropDownList3.Visible = true;
                lblItemName2.Visible = true;
                ViewState["supp"] = null;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnexceldownload.Visible = true;
            btnback.Visible = true;
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            btnexceldownload.Visible = true;
            btnback.Visible = true;
        }
    }

}