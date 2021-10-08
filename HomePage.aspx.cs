using FoodCartApplicationDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodCartApplicationDemo
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var list = Application["FoodItems"] as FoodItem[];
                dtList.DataSource = list;
                dtList.DataBind();
            }
        }

        protected void dtList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            dtList.SelectedIndex = e.Item.ItemIndex;
            var cart = Session["cart"] as List<FoodItem>;
            var allItems = Application["FoodItems"] as FoodItem[];
            cart.Add(allItems[dtList.SelectedIndex]);
            foreach (var item in cart)
            {
                Debug.WriteLine(item.ItemName);
            }
            Session["cart"] = cart;
            lblItemCount.Text = "Items basket Count : " + cart.Count;
        }

        protected void btnBill_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInfo.aspx");
        }
    }
}