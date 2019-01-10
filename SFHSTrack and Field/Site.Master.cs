using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SFHSTrackAndField
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Helper.loggedIn)
            {
                welcome.Visible = true;
                welcome.InnerText = ("Welcome " + Player.firstName);
                registerLink.Visible = false;
                loginLink.Visible = false;
            } else
            {
                welcome.Visible = false;
                registerLink.Visible = true;
                loginLink.Visible = true;
            }
                
        }
    }
}