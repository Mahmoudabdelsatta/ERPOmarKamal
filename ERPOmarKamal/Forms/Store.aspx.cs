using ERPOmarKamal.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPOmarKamal.Forms
{
    public partial class Store : System.Web.UI.Page
    {
        System.Data.DataTable mytable = new System.Data.DataTable();
        System.Data.DataRow dr = null;
        private omarKamalEntities cx = new omarKamalEntities();
        string cs = ConfigurationManager.ConnectionStrings["omarKamalEntitiescon"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //    this.DataBind();
            //GridView1.DataBind();
                btnback.Visible = false;
            btnexceldownload.Visible = false;
            btnSearch.Visible = true;
            txtsearch.Visible = true;
            if (Session["userName"] == "" || Session["userName"] == null)
            {
                Response.Redirect("login.aspx");
            }

        }
        protected void ShowData()
        {
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();
            adapt = new SqlDataAdapter("SELECT [الكود] ,[التاريخ],[اسم الصنف],[الموديل],[رصيد أول المده],[رصيد اخر المده]FROM[dbo].[المخزن] where [اسم الصنف] like N" + "'" + "%" + txtsearch.Text.Trim().ToLower() + "%" + "' or  الموديل like N" + "'" + "%" + txtsearch.Text.Trim().ToLower() + "%" + "'", con);
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            GridView1.DataBind();
            con.Close();
            btnback.Visible = true;
            btnexceldownload.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtdate.Text = Calendar1.SelectedDate.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            txtsearch.Visible = true;
            GridView1.Visible = true;
            divadditem.Visible = false;
            btnback.Visible = true;
            btnexceldownload.Visible = true;
            ShowData();
        }

        protected void txtAdd_Click(object sender, EventArgs e)
        {
            int f = 0;
            bool first = Int32.TryParse(txtcountFirst.Text, out f);
            int l = 0;
            bool last = Int32.TryParse(txtCountLast.Text, out l);
            cx.المخزن.Add(new المخزن()
            {
                اسم_الصنف = txtItemName.Text,
                التاريخ = Convert.ToDateTime(txtdate.Text),
                الموديل = txtModel.Text,
                رصيد_أول_المده = f,
                رصيد_اخر_المده = l,

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
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('تم اضافة الصنف  للمخزن بنجاح')", true);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            con = new SqlConnection(cs);


            int id1 = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[4].Text.ToString());
            cx.logs.Add(new log()
            {
                اسم_صاحب_العمليه = Session["userName"].ToString(),
                التاريخ = DateTime.Now,
                التفاصيل = GridView1.Rows[e.RowIndex].Cells[6].Text + "مسح صنف جديد من المخزن",
                نوع_العمليه = "مسح صنف "

            });
            cx.SaveChanges();
            con.Open();
            cmd = new SqlCommand("delete from المخزن where الكود='" + id1 + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            GridView1.Visible = true;
            btnexceldownload.Visible = true;
            ShowData();

        }
        //private void BindView()
        //{
        //    GridView1.DataSource = ms.dTable("select * from المخزن");
        //    GridView1.DataBind();
        //}

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

            btnexceldownload.Visible = true;
            ShowData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            btnexceldownload.Visible = true;
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            TextBox textid = (TextBox)row.Cells[4].Controls[0];
            int id1 = Convert.ToInt32(textid.Text);
            TextBox textdate = (TextBox)row.Cells[5].Controls[0];
            TextBox textitemName = (TextBox)row.Cells[6].Controls[0];
            TextBox textModel = (TextBox)row.Cells[7].Controls[0];
            TextBox textcostfirst = (TextBox)row.Cells[8].Controls[0];
            TextBox textcostlast = (TextBox)row.Cells[9].Controls[0];
            cx.logs.Add(new log()
            {
                اسم_صاحب_العمليه = Session["userName"].ToString(),
                التاريخ = DateTime.Now,
                التفاصيل = GridView1.Rows[e.RowIndex].Cells[6].Text + "تعديل صنف داخل المخزن",
                نوع_العمليه = "تعديل صنف "

            });
            cx.SaveChanges();
            con = new SqlConnection(cs);
            con.Open();
            //updating the record  
            SqlCommand cmd = new SqlCommand("Update [dbo].[المخزن] set [اسم الصنف]=N'" + textitemName.Text + "',[الموديل]=N'" + textModel.Text + "',[التاريخ]='" + textdate.Text + "',[رصيد اخر المده]='" + textcostlast.Text + "',[رصيد أول المده]='" + textcostfirst.Text + "' where الكود=" + id1, con);
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Change the index number as per your gridview design
                e.Row.Cells[4].Enabled = false;



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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            btnexceldownload.Visible = true;
            GridView1.PageIndex = e.NewPageIndex;
           
            ShowData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            btnexceldownload.Visible = true;
            GridView1.EditIndex = -1;
            ShowData();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Store.aspx");
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            btnexceldownload.Visible = true;
            GridView1.DataBind();
        }

        protected void btnback2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("login.aspx");
        }



        public override void VerifyRenderingInServerForm(Control control)
        {

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
            string sFileName = "مخزن-" + System.DateTime.Now.Date + ".xls";
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
          mytable.Columns.Add(new System.Data.DataColumn("رصيد أول المده", System.Type.GetType("System.String")));
          mytable.Columns.Add(new System.Data.DataColumn("رصيد اخر المده",
               System.Type.GetType("System.String")));
            mytable.Columns.Add(new System.Data.DataColumn("الموديل",
               System.Type.GetType("System.String")));
            // REMOVE PAGING TO HELP EXPORT ENTIRE GRIDVIEW TO EXCEL.
            ShowData();
            GridView1.AllowPaging = false;
            GridView1.DataBind();

            foreach (GridViewRow row in GridView1.Rows)
            {
                dr = mytable.NewRow();
                dr[0] = GridView1.Rows[iRowCnt].Cells[6].Text;
                dr[1] = GridView1.Rows[iRowCnt].Cells[5].Text;
                dr[2] = GridView1.Rows[iRowCnt].Cells[8].Text;
                dr[3] = GridView1.Rows[iRowCnt].Cells[9].Text;
                dr[4] = GridView1.Rows[iRowCnt].Cells[7].Text;
                mytable.Rows.Add(dr);

                iRowCnt += 1;
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
        }
    }
}



     