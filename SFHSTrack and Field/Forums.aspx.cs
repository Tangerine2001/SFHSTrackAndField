using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace SFHSTrackAndField
{
    public partial class Forums : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection("server=localhost; userid=root; password=tang; database=schoolmembers");

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Helper.loggedIn)
            {
                LoadPost();
                postMessageButton.Visible = true;
                div_post_display_panel.Visible = true;
                forumPostPage.Visible = false;
            } else
            {
                postMessageButton.Visible = false;
                div_post_display_panel.Visible = false;
                forumPostPage.Visible = false;
            }
        }
        public void LoadPost()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from forumposts", con);
            con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {


                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string id = ds.Tables[0].Rows[i]["PostID"].ToString();
                    string author = ds.Tables[0].Rows[i]["SenderID"].ToString();
                    string title = ds.Tables[0].Rows[i]["PostSubject"].ToString();
                    string postmsg = ds.Tables[0].Rows[0]["PostBody"].ToString();
                    HtmlGenericControl divpost = new HtmlGenericControl("div");
                    divpost.Attributes.Add("class", "div_post_display");
                    divpost.Attributes.Add("id", id);
                    /* Post Authro */
                    HtmlGenericControl lblauthor = new HtmlGenericControl("label");
                    lblauthor.Attributes.Add("class", "divauthor");
                    lblauthor.InnerText = "Author :" + Player.firstName + " " + Player.lastName;
                    /* Post Title (H2) */
                    HtmlGenericControl h2 = new HtmlGenericControl("h2");
                    h2.InnerText = title.ToString();
                    /* Post Message */
                    HtmlGenericControl divpostmsg = new HtmlGenericControl("div");
                    divpostmsg.Attributes.Add("class", "divpostmsg");
                    if (postmsg.Length > 200)
                    {
                        divpostmsg.InnerText = postmsg.Substring(0, 200) + "....";
                    }
                    if (postmsg.Length < 200 && postmsg.Length > 100)
                    {
                        divpostmsg.InnerText = postmsg.Substring(0, 100) + "....";
                    }
                    if (postmsg.Length < 100)
                    {
                        divpostmsg.InnerText = postmsg;
                    }
                    HtmlGenericControl divreader = new HtmlGenericControl("div");
                    divreader.Attributes.Add("class", "divreader");
                    divpost.Controls.Add(divreader);

                    /* Post Read More */
                    HtmlGenericControl btnReadMore = new HtmlGenericControl("a");
                    btnReadMore.Attributes.Add("class", "btnreadmore");
                    btnReadMore.InnerText = "Read More";
                    divreader.Controls.Add(btnReadMore);

                    divpost.Controls.Add(lblauthor);
                    divpost.Controls.Add(h2);
                    divpost.Controls.Add(divpostmsg);
                    divpost.Controls.Add(divreader);
                    div_post_display_panel.Controls.Add(divpost);
                }
            }
            con.Close();
        }

        protected void postMessageButton_Click(object sender, EventArgs e)
        {
            postMessageButton.Visible = false;
            div_post_display_panel.Visible = false;
            forumPostPage.Visible = true;
        }

        protected void confirmPostButton_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into forumposts(SenderID, PostSubject, PostBody) values ('" + Player.UserID + "','" + subjectBox.Text + "', '" + bodyBox.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Server.Transfer("Forums.aspx", false);
        }
    }
}