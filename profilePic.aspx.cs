using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zero.ShareDream;

namespace Zero.ShareDream
{
    public partial class profilePic : System.Web.UI.Page
    {
        private database d;
        private Account acnt;
        private Child child;
        protected void Page_Load(object sender, EventArgs e)
        {
            long childid = Convert.ToInt64(Request.QueryString["cid"]);

            d = new database();
            child = d.GetChildByID(childid);
            
            if (child != null && child.ChildPic1ID !=null)
            {
                Response.Clear();
               Response.ContentType = "png";
                Response.BinaryWrite(child.ChildPic1ID.ToArray());
            }
            else
            {
                Response.Redirect("~/Images/nav_bg.png");
            }

        }

    }
}