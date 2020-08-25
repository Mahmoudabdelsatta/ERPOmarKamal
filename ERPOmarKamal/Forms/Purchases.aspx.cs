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
    public partial class Purchases : System.Web.UI.Page
    {
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
            int f = 0;
            bool first = Int32.TryParse(txtcount.Text, out f);
            double l = 0;
            bool last = double.TryParse(txtprice.Text, out l);
            cx.المشتريات.Add(new المشتريات()
            {
              
                رقم_كود_الصنف = Convert.ToInt32(DropDownList1.SelectedItem.Value),
                التاريخ = Convert.ToDateTime(txtdate.Text),
                العدد = f,
                السعر = l,
                الاجمالى = Convert.ToDouble(txttotal.Text),

            });
            cx.SaveChanges();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('تم اضافة الصنف بنجاح')", true);
            int itemid = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            int? itemCount = cx.المخزن.FirstOrDefault(x => x.الكود == itemid).رصيد_أول_المده;
            if (itemCount==null)
            {
                itemCount = 0;
            }
            itemCount += f;
            المخزن store = cx.المخزن.FirstOrDefault(x => x.الكود == itemid);
            store.رصيد_أول_المده = itemCount;
            cx.Entry(store).State = System.Data.Entity.EntityState.Modified;
            cx.SaveChanges();
            string s = Session["userName"].ToString();
            cx.SaveChanges();
            cx.logs.Add(new log()
            {
                اسم_صاحب_العمليه = Session["userName"].ToString(),
                التاريخ = DateTime.Now,
                التفاصيل = DropDownList1.SelectedItem.Text+"اضافة صنف للشراء ",
                نوع_العمليه = "اضافه "

            });
            cx.SaveChanges();
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
                double price = (Convert.ToDouble(txtprice.Text) * Convert.ToInt32(txtcount.Text));
                txttotal.Text = price.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Purchases.aspx");
        }
        protected void ShowData()
        {
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();
            if (!String.IsNullOrEmpty(txtsearch.Text))
            {
                List<int> idds = new List<int>();
                var ids = cx.المخزن.Where(x => x.اسم_الصنف.Contains(txtsearch.Text.ToLower().Trim()));
                if (ids != null)
                {

                    foreach (var id in ids)
                    {
                        adapt = new SqlDataAdapter(" SELECT [id]  ,المخزن.[اسم الصنف],[المشتريات].[التاريخ],[العدد],[السعر],[الاجمالى]FROM [dbo].[المشتريات],المخزن where المشتريات.[رقم كود الصنف]=المخزن.الكود and [رقم كود الصنف] =" + id.الكود + " ", con);
                        adapt.Fill(dt);
                    }


                    //adapt = new SqlDataAdapter(" SELECT [id]  ,المخزن.[اسم الصنف],[المشتريات].[التاريخ],[العدد],[السعر],[الاجمالى]FROM [dbo].[المشتريات],المخزن where المشتريات.[رقم كود الصنف]=المخزن.الكود and [رقم كود الصنف] =" + ids + " ", con);
                    //adapt.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    con.Close();
                }
            }
            else
            {
                

                    adapt = new SqlDataAdapter(" SELECT [id]  ,المخزن.[اسم الصنف],[المشتريات].[التاريخ],[العدد],[السعر],[الاجمالى]FROM [dbo].[المشتريات],المخزن where المشتريات.[رقم كود الصنف]=المخزن.الكود", con);
                    adapt.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                GridView1.DataBind();
                    con.Close();
                
            }
            
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            txtsearch.Visible = true;
            GridView1.Visible = true;
            divadditem.Visible = false;
            btnback.Visible = true;
            ShowData();
        }

        protected void btnPay2_Click(object sender, EventArgs e)
        {
            divsearch.Visible = true;
            divadditem.Visible = false;
            divpay.Visible = false;
            btnback.Visible = true;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Change the index number as per your gridview design
                e.Row.Cells[4].Enabled = false;
                e.Row.Cells[5].Enabled = false;
                e.Row.Cells[6].Enabled = false;


            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            con = new SqlConnection(cs);


            cx.logs.Add(new log()
            {
                اسم_صاحب_العمليه = Session["userName"].ToString(),
                التاريخ = DateTime.Now,
                التفاصيل = GridView1.Rows[e.RowIndex].Cells[5].Text+"مسح صنف من المشتريات",
                نوع_العمليه = "مسح  "

            });
            cx.SaveChanges();
            int id1 = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[4].Text.ToString());
            con.Open();
            cmd = new SqlCommand("delete from المشتريات where id='" + id1 + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            GridView1.Visible = true;
            ShowData();
            string s = Session["userName"].ToString();
            cx.SaveChanges();
       
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            ShowData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            ShowData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            TextBox textid = (TextBox)row.Cells[4].Controls[0];
            int id1 = Convert.ToInt32(textid.Text);

            TextBox textclientName = (TextBox)row.Cells[5].Controls[0];
            //   TextBox textitemName = (TextBox)row.Cells[7].Controls[0];
            TextBox textprice = (TextBox)row.Cells[8].Controls[0];
            TextBox textcount = (TextBox)row.Cells[7].Controls[0];
            TextBox texttotal = (TextBox)row.Cells[9].Controls[0];

            cx.logs.Add(new log()
            {
                اسم_صاحب_العمليه = Session["userName"].ToString(),
                التاريخ = DateTime.Now,
                التفاصيل = GridView1.Rows[e.RowIndex].Cells[5].Text+" تعديل  صنف من المشتريات",
                نوع_العمليه = "تعديل  "

            });
            cx.SaveChanges();

            con = new SqlConnection(cs);
            con.Open();
            //updating the record  
            SqlCommand cmd = new SqlCommand("Update [dbo].[المشتريات] set [العدد]=N'" + textcount.Text + "',[الاجمالى]='" + texttotal.Text + "',[السعر]='" + textprice.Text + "' where id=" + id1, con);
            cmd.ExecuteNonQuery();
            con.Close();
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            ShowData();
        
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {

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
    }
}