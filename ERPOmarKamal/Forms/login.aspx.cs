using ERPOmarKamal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPOmarKamal.Forms
{
    public partial class login : System.Web.UI.Page
    {
        private omarKamalEntities cx = new omarKamalEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool login = cx.logins.Any(x => x.اسم_المستخدم == txtuserName.Text.Trim().ToLower() && x.الرقم_السرى == txtPass.Text.Trim().ToLower());
            if (login)
            {
                Session["userName"] = txtuserName.Text;
                Response.Redirect("Home.aspx");
               
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('دخول خطأ. تأكد من اسم المستخدم والرقم السرى')", true);

            }
        }
    }
}