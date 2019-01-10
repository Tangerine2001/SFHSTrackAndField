using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;
using System.Security;
namespace SFHSTrackAndField
{
    public partial class Register : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection("server=localhost; userid=root; password=tang; database=schoolmembers");

        protected void Page_Load(object sender, EventArgs e)
        {
            studentOrTeacher.Visible = true;
            registerPage.Visible = false;
            verifyCodePage.Visible = false;
            con.Open();
        }

        protected void email_TextChanged(object sender, EventArgs e)
        {

        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            MySqlCommand emailCheck = new MySqlCommand("select * from Users where Email = '" + email.Text + "'", con);
            MySqlDataReader read = emailCheck.ExecuteReader();
            if (read.Read())
            {
                emailCheckLabel.Text = "*Email is already in use, please try again. ";
                studentOrTeacher.Visible = false;
                registerPage.Visible = true;
            }
            else
            { 
                emailCheckLabel.Text = "";
                ViewState["code"] = Helper.GetCode(6);
                registerUser();
            }
        }
        protected void verifyBox_Click(object sender, EventArgs e)
        {
            VerifyUser();
        }

        protected void student_Click(object sender, EventArgs e)
        {
            registerPage.Visible = true;
            studentOrTeacher.Visible = false;
            ViewState["authLevel"] = 0;
        }

        protected void teacher_Click(object sender, EventArgs e)
        {
            registerPage.Visible = true;
            studentOrTeacher.Visible = false;
            ViewState["authLevel"] = 1;
        }
        public void registerUser()
        {
            Helper.SendMail("Code", "Use this code to verify your account: " + ViewState["code"].ToString(), email.Text);
            registerPage.Visible = false;
            verifyCodePage.Visible = true;
            studentOrTeacher.Visible = false;
        }
        public void VerifyUser()
        {
            if (Helper.VerifyCode(ViewState["code"].ToString(), codeBox.Text))
            {
                String now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                MySqlCommand insert = new MySqlCommand("insert into users(Email, Pass, FirstName, LastName, DateCreated, AuthenticationLevel) Values ('" + email.Text + "', '" + Helper.Encrypt(password.Text) + "', '" + firstName.Text + "', '" + lastName.Text + "', '" + now + "', '" + ViewState["authLevel"] + "')", con);
                insert.ExecuteNonQuery();
                Helper.changeLoggedInStatus();
                MySqlDataReader reader;
                MySqlCommand validate = new MySqlCommand("select * from users where Email='" + email.Text + "'", con);
                reader = validate.ExecuteReader();
                if(reader.Read())
                {
                    Player.establishUserIdentity(reader);
                }
                con.Close();
                verifyCodePage.Visible = false;
                verifyCodeText.InnerText = "";
                Server.Transfer("Default.aspx", false);
            }
            else
            {
                registerPage.Visible = false;
                verifyCodePage.Visible = true;
                studentOrTeacher.Visible = false;
                verifyCodeText.InnerText = "Incorrect code, please try again.";
            }
        }
    }
}