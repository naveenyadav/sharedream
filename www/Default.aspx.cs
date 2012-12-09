using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zero.ShareDream
{
    public partial class _Default : System.Web.UI.Page
    {
        private database d;
        protected void Page_Load(object sender, EventArgs e)
        {
            d = new database();

            RepChild.DataSource = d.GetAllChildren();
                RepChild.DataBind();
            
        }
        protected void repAlert_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Image imgID = e.Item.FindControl("IChildPic1") as Image;
                Label lid = e.Item.FindControl("LID") as Label;
                LinkButton ledit = e.Item.FindControl("LBEdit") as LinkButton;
                LinkButton LBHelp = e.Item.FindControl("LBHelp") as LinkButton;
                LinkButton LBName = e.Item.FindControl("LChildName") as LinkButton;
                LBHelp.PostBackUrl = "~/Help.aspx?uid=" + lid.Text;
                LBName.PostBackUrl = "~/Help.aspx?uid=" + lid.Text;
                ledit.PostBackUrl = "~/Profile.aspx?uid=" + lid.Text;
                imgID.ImageUrl = "~/profilePic.aspx?cid=" + lid.Text;


            }
        }
    }
}
