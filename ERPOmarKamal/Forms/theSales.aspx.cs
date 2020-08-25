using ERPOmarKamal.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPOmarKamal.Forms
{
    public partial class theSales : System.Web.UI.Page
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
            if (Calendar2.SelectedDate.ToString() == "01/01/0001 12:00:00 AM")
            {
                Calendar2.SelectedDate = DateTime.Today;
            }
            if (Session["userName"] == "" || Session["userName"] == null)
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if ((tdtxtclient.Visible == true && String.IsNullOrEmpty(txtclient.Text)) || String.IsNullOrEmpty(txtdate.Text) || String.IsNullOrEmpty(txtcount.Text)|| String.IsNullOrEmpty(txttawreed.Text) || String.IsNullOrEmpty(txtprice.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('يجب ادخال اسم العميل والتاريخ والعدد والسعر والتحصيل ')", true);

            }
            else
            {
                int f = 0;
                bool first = Int32.TryParse(txtcount.Text, out f);
                double l = 0;
                bool last = double.TryParse(txtprice.Text, out l);
                double price = Convert.ToDouble(txttawreed.Text);
                int itemid = Convert.ToInt32(DropDownList1.SelectedItem.Value);
              
                int? lastraseed = cx.المخزن.FirstOrDefault(x => x.الكود == itemid).رصيد_اخر_المده;
                if (lastraseed == null || lastraseed <= 0 || lastraseed<Convert.ToInt32(f))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('عفوا لا يوجد رصيد فى المخزن')", true);

                }
                else
                {

                    cx.المبيعات.Add(new المبيعات()
                    {

                        رقم__كود_الصنف = Convert.ToInt32(DropDownList1.SelectedItem.Value),
                        التاريخ = Convert.ToDateTime(txtdate.Text),
                        العدد = f,
                        السعر = l,
                        الاجمالى = Convert.ToDouble(txttotal.Text),

                        وارد = Convert.ToDouble(txttawreed.Text)
                    });
                    cx.SaveChanges();
                    lastraseed -= f;
                    المخزن store = cx.المخزن.FirstOrDefault(x => x.الكود == itemid);
                    store.رصيد_اخر_المده = lastraseed;
                    cx.Entry(store).State = System.Data.Entity.EntityState.Modified;
                    cx.SaveChanges();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('تم بيع الصنف بنجاح')", true);
                    //if (price < Convert.ToDouble(txttotal.Text))
                    //{
                        cx.العملاء.Add(new العملاء()
                        {

                            رقم_كود_الصنف = Convert.ToInt32(DropDownList1.SelectedItem.Value),
                            التاريخ = Convert.ToDateTime(txtdate.Text),
                            المدفوع = price,
                            المتبقي = Convert.ToDouble(txtraseed.Text),
                            اسم_العميل = txtclient.Text,
                            اجمالى_المبلغ = Convert.ToDouble(txttotal.Text)

                        });
                        cx.SaveChanges();
                        cx.logs.Add(new log()
                        {
                            اسم_صاحب_العمليه = Session["userName"].ToString(),
                            التاريخ = DateTime.Now,
                            التفاصيل = DropDownList1.SelectedItem.Text + " بيع صنف",
                            نوع_العمليه = "بيع  "

                        });
                        cx.SaveChanges();

                    //}
 //                   else
 //                   {
 //cx.logs.Add(new log()
 //                   {
 //                       اسم_صاحب_العمليه = Session["userName"].ToString(),
 //                       التاريخ = DateTime.Now,
 //                       التفاصيل = DropDownList1.SelectedItem.Text + " بيع صنف",
 //                       نوع_العمليه = "بيع  "

 //                   });
 //                   cx.SaveChanges();
 //                   }
                   
                }
                
               
            }
            
            //int? itemCount = cx.المخزن.FirstOrDefault(x => x.الكود == itemid).رصيد_أول_المده;
            //if (itemCount == null)
            //{
            //    itemCount = 0;
            //}
            //itemCount += f;
            //المخزن store = cx.المخزن.FirstOrDefault(x => x.الكود == itemid);
            //store.رصيد_أول_المده = itemCount;
            //cx.Entry(store).State = System.Data.Entity.EntityState.Modified;

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
            //if (Convert.ToDouble(txttawreed.Text) < (Convert.ToDouble(txttotal.Text)))
            //{
            //    tdtxtclient.Visible = true;
            //    lblclient.Visible = true;
            //}
            //else
            //{
                //tdtxtclient.Visible = false;
                //lblclient.Visible = false;
            //}

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtdate.Text = Calendar1.SelectedDate.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString();

        }

        protected void txtcount_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtprice.Text) && !String.IsNullOrEmpty(txtcount.Text))
            {
                double price = (Convert.ToDouble(txtprice.Text) * Convert.ToInt32(txtcount.Text));
                txttotal.Text = price.ToString();
            }
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

        protected void txtraseed_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txttotal_TextChanged(object sender, EventArgs e)
        {

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("theSales.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            txtsearch.Visible = true;
            GridView1.Visible = true;
            divadditem.Visible = false;
            btnback.Visible = true;
            divtotalday.Visible = false;
            ShowDatabyClient();
            btnexceldownload.Visible = true;
        }

    
    protected void ShowDatabyClient()
    {
            ViewState["click"] = "1";
            double? tot = 0;
            double? tawtotal = 0;
            double? rased = 0;
            double? rasedyomy = 0;
            dt = new DataTable();
        con = new SqlConnection(cs);
        con.Open();



            adapt = new SqlDataAdapter(" SELECT [id] ,[اسم العميل] ,[اجمالى المبلغ],[المدفوع] ,[المتبقي] ,المخزن.[اسم الصنف],العملاء.التاريخ FROM[dbo].[العملاء],المخزن where العملاء.[رقم كود الصنف]=المخزن.الكود   and [اسم العميل] like " + "N'" + "%" + txtsearch.Text + "%" + "' ", con);

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
                rasedyomy = tot + tawtotal - rased;
                lblrasedyomy.Visible = true;
                txtrasedyomy.Visible = true;
                txtrasedyomy.Text = rasedyomy.ToString();
                //GridView2.Visible = true;
                //GridView2.DataSource = dt;
                //GridView2.DataBind();
              GridView1.Visible = true;
            }
            else
            {
                txtrasedyomy.Text = "0";
                txtalltotal.Text = "0";
                txttawtotal.Text = "0";
                txtrasedd.Text = "0";

            }

            GridView1.DataBind();
           // GridView1.Visible = false;
            con.Close();




        }
        protected void ShowDatabyItem()
        {
            ViewState["click"] = 2;
            double? tot = 0;
            double? tawtotal = 0;
            double? rased = 0;
            double? rasedyomy = 0;
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();



            adapt = new SqlDataAdapter(" SELECT [id] ,المخزن.[اسم الصنف] ,المبيعات.التاريخ ,[العدد] ,[السعر] ,[الاجمالى] ,[وارد]FROM [dbo].[المبيعات],المخزن where المبيعات.[رقم  كود الصنف]=المخزن.الكود and [اسم الصنف] like  " + "'" + "%" + txtitemsearch0.Text + "%" + "' ", con);

            adapt.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i].Field<double?>("الاجمالى") != null)
                    {
                        tot += dt.Rows[i].Field<double?>("الاجمالى");
                    }

                    if (dt.Rows[i].Field<double?>("وارد") != null)
                    {
                        tawtotal += dt.Rows[i].Field<double?>("وارد");
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
                rasedyomy = tot + tawtotal - rased;
                lblrasedyomy.Visible = true;
                txtrasedyomy.Visible = true;
                txtrasedyomy.Text = rasedyomy.ToString();
            //    GridView2.Visible = true;
            //    GridView2.DataSource = dt;
            //    GridView2.DataBind();
              GridView1.Visible = true;
            }
            else
            {
                txtrasedyomy.Text = "0";
                txtalltotal.Text = "0";
                txttawtotal.Text = "0";
                txtrasedd.Text = "0";

            }

            GridView1.DataBind();
            //GridView1.Visible = false;
            con.Close();




        }
        protected void ShowDatabydate()
        {
            ViewState["click"] = 3;
            double? tot = 0;
            double? tawtotal = 0;
            double? rased = 0;
            double? rasedyomy = 0;
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();
            var x = Calendar2.SelectedDate.Date.ToString("yyyy-MM-dd hh:MM:ss");
            string xx = x.Substring(0, 10);
                  
            adapt = new SqlDataAdapter(" SELECT [id] ,المخزن.[اسم الصنف] ,المبيعات.التاريخ ,[العدد] ,[السعر] ,[الاجمالى] ,[وارد]FROM [dbo].[المبيعات],المخزن where المبيعات.[رقم  كود الصنف]=المخزن.الكود and convert(nvarchar(50), المبيعات.التاريخ ,126) like  " + "'" + "%" +x.Substring(0,10)+ "%" + "' ", con);
                    adapt.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i].Field<double?>("الاجمالى") != null)
                    {
                        tot += dt.Rows[i].Field<double?>("الاجمالى");
                    }

                    if (dt.Rows[i].Field<double?>("وارد") != null)
                    {
                        tawtotal += dt.Rows[i].Field<double?>("وارد");
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
                rasedyomy = tot + tawtotal - rased;
                lblrasedyomy.Visible = true;
                txtrasedyomy.Visible = true;
                txtrasedyomy.Text = rasedyomy.ToString();
                //GridView2.Visible = true;
                //        GridView2.DataSource = dt;
                //        GridView2.DataBind();
                GridView1.Visible = true;
            }
            else
            {
                txtrasedyomy.Text = "0";
                txtalltotal.Text = "0";
                txttawtotal.Text = "0";
                txtrasedd.Text = "0";

            }

            GridView1.DataBind();
            //GridView1.Visible = false;
                    con.Close();
            var returnedDate = Calendar2.SelectedDate.Date;
            var ret = returnedDate.ToString().Substring(0, 10);
            divtotalday.Visible = true;
            double ?value = 0;
            var stringResults = cx.المبيعات.Select(d => d.التاريخ!=null);
            List<المبيعات> monthProcessed =
(from m in cx.المبيعات.AsEnumerable()
where m.التاريخ.ToString().Substring(0, 10) == ret
 select m).ToList();
            foreach (var item in monthProcessed)
            {
                value += item.الاجمالى;
            }
            var totalDay = cx.المبيعات.Where(y => y.التاريخ.ToString().Substring(0,10)==ret).Sum(y => y.الاجمالى);
         //   txtdaytotal.Text = value.ToString();
                }

        protected void ShowDatabymonthDate()
        {
            ViewState["click"] = 4;
            double? tot = 0;
            double? tawtotal = 0;
            double? rased = 0;
            double? rasedyomy = 0;
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();
            var x = Calendar2.SelectedDate.Date.ToString("yyyy-MM-dd hh:MM:ss");
            string xx = x.Substring(0, 10);

            adapt = new SqlDataAdapter(" SELECT [id] ,المخزن.[اسم الصنف] ,المبيعات.التاريخ ,[العدد] ,[السعر] ,[الاجمالى] ,[وارد]FROM [dbo].[المبيعات],المخزن where المبيعات.[رقم  كود الصنف]=المخزن.الكود and convert(nvarchar(50), المبيعات.التاريخ ,126) like  " + "'" + "%" + txtmonth.Text + "%" + "' ", con);
            adapt.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i].Field<double?>("الاجمالى") != null)
                    {
                        tot += dt.Rows[i].Field<double?>("الاجمالى");
                    }

                    if (dt.Rows[i].Field<double?>("وارد") != null)
                    {
                        tawtotal += dt.Rows[i].Field<double?>("وارد");
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
                rasedyomy = tot + tawtotal - rased;
                lblrasedyomy.Visible = true;
                txtrasedyomy.Visible = true;
                txtrasedyomy.Text = rasedyomy.ToString();
                //GridView2.Visible = true;
                //GridView2.DataSource = dt;
                //GridView2.DataBind();
                GridView1.Visible = true;
            }
            else
            {
                txtrasedyomy.Text = "0";
                txtalltotal.Text = "0";
                txttawtotal.Text = "0";
                txtrasedd.Text = "0";

            }

            GridView1.DataBind();
            //GridView1.Visible = false;
            con.Close();
            var returnedDate = Calendar2.SelectedDate.Date;
            var ret = returnedDate.ToString().Substring(0, 10);
            divtotalday.Visible = true;
            double? value = 0;
            var stringResults = cx.المبيعات.Select(d => d.التاريخ != null);
            List<المبيعات> monthProcessed =
(from m in cx.المبيعات.AsEnumerable()
 where m.التاريخ.ToString().Substring(0, 10) == ret
 select m).ToList();
            foreach (var item in monthProcessed)
            {
                value += item.الاجمالى;
            }
            var totalDay = cx.المبيعات.Where(y => y.التاريخ.ToString().Substring(0, 10) == ret).Sum(y => y.الاجمالى);
            //   txtdaytotal.Text = value.ToString();
        }



        protected void btnSearch0_Click(object sender, EventArgs e)
        {
            ShowDatabydate();
            divtotalday.Visible = true;
            btnexceldownload.Visible = true;

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            btnexceldownload.Visible = true;

            GridView1.EditIndex = -1;
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
            if (deleteButton.Text == "Delete" || deleteButton2.Text == "مسح")
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
            GridView1.EditIndex = e.NewEditIndex;
            btnexceldownload.Visible = true;

            ShowDatabyClient();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
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
            btnexceldownload.Visible = true;

            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            ShowDatabyClient();
         
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowDatabyClient();
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            GridView1.DataBind();
            btnexceldownload.Visible = true;

        }

        protected void GridView2_DataBound(object sender, EventArgs e)
        {
           
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            ShowDatabydate();
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            ShowDatabydate();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Change the index number as per your gridview design
                e.Row.Cells[4].Enabled = false;
                e.Row.Cells[5].Enabled = false;
                e.Row.Cells[6].Enabled = false;


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

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            con = new SqlConnection(cs);

            cx.logs.Add(new log()
            {
                اسم_صاحب_العمليه = Session["userName"].ToString(),
                التاريخ = DateTime.Now,
                التفاصيل = GridView2.Rows[e.RowIndex].Cells[5].Text.ToString() + " مسح صنف من المبيعات",
                نوع_العمليه = "مسح  "

            });
            cx.SaveChanges();
            int id1 = Convert.ToInt32(GridView2.Rows[e.RowIndex].Cells[4].Text.ToString());
            con.Open();
            cmd = new SqlCommand("delete from المبيعات where id='" + id1 + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView2.DataBind();
            GridView2.Visible = true;
            ShowDatabydate();
            
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            ShowDatabydate();
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView2.Rows[e.RowIndex];
            TextBox textid = (TextBox)row.Cells[4].Controls[0];
            int id1 = Convert.ToInt32(textid.Text);

            TextBox textclientName = (TextBox)row.Cells[5].Controls[0];
            //   TextBox textitemName = (TextBox)row.Cells[7].Controls[0];
            TextBox textprice = (TextBox)row.Cells[8].Controls[0];
            TextBox textcount = (TextBox)row.Cells[7].Controls[0];
            TextBox texttotal = (TextBox)row.Cells[9].Controls[0];
            TextBox texttawreed = (TextBox)row.Cells[10].Controls[0];
          

            con = new SqlConnection(cs);
            cx.logs.Add(new log()
            {
                اسم_صاحب_العمليه = Session["userName"].ToString(),
                التاريخ = DateTime.Now,
                التفاصيل = GridView2.Rows[e.RowIndex].Cells[5].Text.ToString() + "   تعديل صنف من المبيعات",
                نوع_العمليه = "تعديل  "

            });
            cx.SaveChanges();
            con.Open();
            //updating the record  
            SqlCommand cmd = new SqlCommand("Update [dbo].[المبيعات] set [العدد]=N'" + textcount.Text + "',[الاجمالى]='" + texttotal.Text + "',[وارد]='" + texttawreed.Text + "',[السعر]='" + textprice.Text + "' where id=" + id1, con);
            cmd.ExecuteNonQuery();
            con.Close();
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView2.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            ShowDatabydate();
         
        }

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {
            GridView2.DataBind();
        }

        protected void btnback3_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("login.aspx");
        }

        protected void btnSearchitem_Click(object sender, EventArgs e)
        {
            txtsearch.Visible = true;
            GridView1.Visible = true;
            divadditem.Visible = false;
            btnback.Visible = true;
            divtotalday.Visible = false;
            btnexceldownload.Visible = true;

            ShowDatabyItem();
        }

        protected void btnback2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("login.aspx");
        }

        protected void btnmonthSearch_Click(object sender, EventArgs e)
        {
            btnexceldownload.Visible = true;

            ShowDatabymonthDate();
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
            string sFileName = "مبيعات-" + System.DateTime.Now.Date + ".xls";
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
            mytable.Columns.Add(new System.Data.DataColumn("اسم الصنف", System.Type.GetType("System.String")));

            mytable.Columns.Add(new System.Data.DataColumn("التاريخ",
              System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("العدد", System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("السعر",
                 System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("الاجمالى",
               System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("اجمالى الوارد",
    System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("اجمالى المنصرف",
   System.Type.GetType("System.String")));

            mytable.Columns.Add(new System.Data.DataColumn("الرصيد اليومى/الشهرى",
    System.Type.GetType("System.String")));

            // REMOVE PAGING TO HELP EXPORT ENTIRE GRIDVIEW TO EXCEL.
            if (ViewState["click"].ToString() =="1")
            {
                ShowDatabyClient();
            }
            if (ViewState["click"].ToString() == "2")
            {
                ShowDatabyItem();
            }
            if (ViewState["click"].ToString() == "3")
            {
                ShowDatabydate();
            }
            if (ViewState["click"].ToString() == "4")
            {
                ShowDatabymonthDate();
            }
           
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
                mytable.Rows.Add(dr);

                iRowCnt += 1;
            }
            dr2 = mytable.NewRow();
            dr2[0] = "";
            dr2[1] = "";
            dr2[2] = "";
            dr2[3] = "";
            dr2[4] = "الاجمالى :" + txtalltotal.Text;
            dr2[5] = "اجمالى الوارد :" + txttawtotal.Text;
            dr2[6] = "اجمالى المنصرف :" + txtrasedd.Text;
            dr2[7] = "الرصيد اليومى/الشهرى :" + txtrasedyomy.Text;
            mytable.Rows.Add(dr2);
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

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnexceldownload.Visible = true;
            btnback.Visible = true;
        }

        protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            btnexceldownload.Visible = true;
            btnback.Visible = true;
        }

        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public List<المخزن> FetchEmailList(string item )
        {
            var st = new المخزن();
            var fetchEmail = cx.المخزن.Select(x=>x)
            .Where(m => m.اسم_الصنف.ToLower().StartsWith(item.ToLower()));
            return fetchEmail.ToList();
        }
    }
}