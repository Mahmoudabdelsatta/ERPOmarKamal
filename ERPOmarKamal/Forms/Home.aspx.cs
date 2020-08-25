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
    public partial class Home : System.Web.UI.Page
    {
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;
        SqlCommand cmd;
        string cs = ConfigurationManager.ConnectionStrings["omarKamalEntitiescon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"]=="" || Session["userName"]==null)
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnback2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("login.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
          
           
        }

        protected void btnback3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int num = random.Next(10000);
            con = new SqlConnection(cs);
            con.Open();
            //updating the record  
            SqlCommand cmd = new SqlCommand("BACKUP DATABASE omarKamal TO DISK ='E:/publish/SQLBACKUP/omar"+ num + ".Bak' WITH FORMAT", con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}