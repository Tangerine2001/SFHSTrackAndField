using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
namespace SFHSTrackAndField
{
    public partial class Login : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection("server=localhost; userid=root; password=tang; database=schoolmembers");

        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlDataReader reader;
                MySqlCommand validate = new MySqlCommand("select * from users where Email='" + email.Text + "'", con);

                reader = validate.ExecuteReader();
                if (reader.Read() && reader.GetString("Pass") == Helper.Encrypt(password.Text))
                {
                    Player.establishUserIdentity(reader);
                    con.Close();
                    Helper.loggedIn = true;
                    Server.Transfer("Default.aspx", false);
                }
                else
                {
                    invalidEmail.Text = " *Emaill address not found or password is incorrect.";
                }
            }
        }
    }
}