using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace stronka
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentUsersName = User.Identity.Name;

            if (Request.IsAuthenticated)
            {
                Label3.Text  = "Hej, " + User.Identity.Name + "!";

                AuthenticatedMessagePanel.Visible = true;
            }
            else
            {
                AuthenticatedMessagePanel.Visible = false;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            FormsAuthentication.Initialize();
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select * from tbl_data where username=@username and password=@password", con);
            cmd.Parameters.AddWithValue("@username", TextBox1.Text);
            cmd.Parameters.AddWithValue("@password", TextBox2.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
         //   int i = cmd.ExecuteNonQuery();
            con.Close();

            if (dt.Rows.Count > 0)
            {
                FormsAuthenticationTicket bilet = new FormsAuthenticationTicket(
        1,
        TextBox1.Text,
        DateTime.Now,
        DateTime.Now.AddMinutes(30),
        false,
        FormsAuthentication.FormsCookiePath); 
                HttpCookie cookie = new HttpCookie(
                FormsAuthentication.FormsCookieName,
                FormsAuthentication.Encrypt(bilet));
                Response.Cookies.Add(cookie);
                FormsIdentity ident = User.Identity as FormsIdentity;
                if (Request.Params["ReturnUrl"] != null) Response.Redirect(Request.Params["ReturnUrl"]);
            }
            else
            {
                Label3.Text = "Nazwa użytkownika bądź hasło jest nieprawidłowe";
                Label3.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            FormsAuthentication.Initialize();
            FormsAuthenticationTicket bilet = new FormsAuthenticationTicket(
       1,
       TextBox1.Text,
       DateTime.Now,
       DateTime.Now.AddMinutes(-1),
       false,
       FormsAuthentication.FormsCookiePath);
            HttpCookie cookie = new HttpCookie(
            FormsAuthentication.FormsCookieName,
            FormsAuthentication.Encrypt(bilet));
            Response.Cookies.Add(cookie);
        }
    }
}
