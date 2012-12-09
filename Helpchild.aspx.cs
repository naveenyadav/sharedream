using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Zero.ShareDream;

namespace Zero.ShareDream
{
    public partial class Helpchild : System.Web.UI.Page
    {
        private database d;
        private long uid;
        protected void Page_Load(object sender, EventArgs e)
        {
            d = new database();
            uid = Convert.ToInt64(Request.QueryString["uid"]);
            if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
             {
                 Child child = d.GetChildByID(uid);
                 if (child != null)
                 {

                     Page.Title = child.ChildName;
                     
                     HtmlMeta meta = new HtmlMeta();
                     meta.Name = "Description";
                     meta.Content = child.ChildName + " " + child.ChildCountry + " " + child.ChildStory;
                     MetaPlaceHolder.Controls.Add(meta);

                     HtmlMeta metaImage1 = new HtmlMeta();
                     metaImage1.Attributes.Add("property", "og:image:type");
                     metaImage1.Content = "image/png";
                     MetaPlaceHolder2.Controls.Add(metaImage1);

                    

                     HtmlMeta metaImage3 = new HtmlMeta();
                     metaImage3.Attributes.Add("property", "og:image:height");
                     metaImage3.Content = "148";
                     MetaPlaceHolder3.Controls.Add(metaImage3);

                     HtmlMeta metaImage4 = new HtmlMeta();
                     metaImage4.Attributes.Add("property", "og:image:width");
                     metaImage4.Content = "148";
                     MetaPlaceHolder4.Controls.Add(metaImage4);

                     HtmlMeta metaImage5 = new HtmlMeta();
                     metaImage5.Attributes.Add("property", "og:url");
                     metaImage5.Content = HttpContext.Current.Request.Url.AbsoluteUri;
                     MetaPlaceHolder5.Controls.Add(metaImage5);
                     HtmlMeta metatitle = new HtmlMeta();
                     metaImage5.Attributes.Add("property", "og:title");
                     metaImage5.Content = child.ChildName + ", Age:" + child.ChildAge + ", City:" + child.ChildCity + ", Country:" + child.ChildCountry ;
                     Metatitle.Controls.Add(metaImage5);
                     
                     
                    
                     meta.Content = child.ChildName + " " + child.ChildCountry + " " + child.ChildStory;
                     string saveToFolder = "http://localhost:11834/Photos//" + child.FileName;
                     HtmlMeta metaImage2 = new HtmlMeta();
                     metaImage2.Attributes.Add("property", "og:image");
                     metaImage2.Content = saveToFolder;
                     MetaPlaceHolder2.Controls.Add(metaImage2);
                     LBFacebook.Text = "<a name=\"fb_share\"  share_url='http://www.sharedream.in/Help.aspx?uid=" + uid +"' ></a>";
                     LBTwitter.Text = " <a href=\"https://twitter.com/share\" class=\"twitter-share-button\" data-url=\"http://www.sharedream.in/Help.aspx?uid=" + uid + "\" data-via=\"ceo_zerobuddy\">Tweet</a>";
                     LID.Text = "";
                     LChildName.Text = child.ChildName.ToString();
                     LChildAge.Text = child.ChildAge.ToString();
                     Label1.Text = child.ChildStory;
                     IChildPic1.ImageUrl = "~/profilePic.aspx?cid=" + uid;
                     RepHelp.DataSource = d.GetAllhelpByChildID(uid);
                     RepHelp.DataBind();
                     if (RepHelp.Items.Count > 0)
                     {
                         LKind.Text = "<h1>Kind of Help (" + RepHelp.Items.Count + ")</h1>";
                     }
                 }
             }
        }
        protected void repAlert_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
               


            }
        }
        protected void BSubmit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TBName.Text) &&
               !String.IsNullOrEmpty(TBEmail.Text) &&
               !String.IsNullOrEmpty(TBHelp.Text) &&
               !String.IsNullOrEmpty(TBMobileNo.Text)
               )
            {
                Help help = new Help();
                help.HelperName = System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(TBName.Text);
                help.HelperEmail = TBEmail.Text;
                help.HelperMobileNo = Convert.ToInt64(TBMobileNo.Text);
                help.HelperHelp = TBHelp.Text;
                help.CreateDate = DateTime.Now;
                help.HelpChildID = uid;
                d.SaveHelp(help);
                TBEmail.Text = "";
                TBName.Text = "";
                TBEmail.Text = "";
                TBMobileNo.Text = "";
                TBHelp.Text = "";
                RepHelp.DataSource = d.GetAllhelpByChildID(uid);
                RepHelp.DataBind();
                if (RepHelp.Items.Count > 0)
                {

                    LKind.Text = "<h1>Kind of Help (" + RepHelp.Items.Count + ")</h1>";
                   
                }
            }
        }
             /*
                if (child != null)
                {
                   
                }*/
               
            
        }
    }
