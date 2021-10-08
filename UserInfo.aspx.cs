using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodCartApplicationDemo
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            saveUserDetails();
            Session.Clear();
        }

        private void saveUserDetails()
        {
            Session.Clear();
        }
    }
}