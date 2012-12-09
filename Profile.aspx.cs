using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Zero.ShareDream;

namespace Zero.ShareDream
{
    public partial class Profile : System.Web.UI.Page
    {
        private database d;
        private Account acnt;
        protected void Page_Load(object sender, EventArgs e)
        {

            d = new database();
            if (d.CurrentUser != null)
            {
                acnt = d.GetAccountByAccountID(d.CurrentUser.AccountID);

            }
            else
            {
                Response.Redirect("http://localhost:11834/Default.aspx");
            }
            if (acnt != null)
            {
                long uid = Convert.ToInt64(Request.QueryString["uid"]);
                if (uid != null)
                {
                    Child child = d.GetChildByID(uid);
                    if (child != null)
                    {
                        TBAddress.Text = child.ChildAddress;
                        TBAge.Text = child.ChildAge.ToString();
                        TBCareNumber.Text = child.CareNumber.ToString();
                        TBCity.Text = child.ChildCity;
                        TBCountry.Text = child.ChildCountry;
                        TBName.Text = child.ChildName;
                        TBStory.Text = child.ChildStory;



                    }
                    else
                    {
                        TBCareNumber.Text = acnt.MobileNo.ToString();
                    }
                }





            }
        }
        


        protected void BSubmit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TBName.Text) &&
                !String.IsNullOrEmpty(TBAge.Text) &&
                !String.IsNullOrEmpty(TBCity.Text) &&
                !String.IsNullOrEmpty(TBCountry.Text) &&
                !String.IsNullOrEmpty(TBAddress.Text) &&
                !String.IsNullOrEmpty(TBCareNumber.Text) &&
                !String.IsNullOrEmpty(TBStory.Text)
                )
            {
                string mimetype = "";
                Child child = new Child();
                child.ChildName = System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(TBName.Text);
                child.ChildAge = Convert.ToInt16(TBAge.Text);
                child.ChildCity = TBCity.Text;
                child.ChildCountry = TBCountry.Text;
                child.ChildAddress = TBAddress.Text;
                child.CareNumber = Convert.ToInt64(TBCareNumber.Text);
                child.ChildStory = TBStory.Text;
                child.CreateDate = DateTime.Now;
                if (FUpload.PostedFile != null)
                {
                    HttpPostedFile File = FUpload.PostedFile;

                    string saveToFolder = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"].ToString() + "Photos";
                    Guid guidName = Guid.NewGuid();
                    byte[] uploadedImage = new byte[File.InputStream.Length];
                    string uploadedFileName = File.FileName.Substring(File.FileName.LastIndexOf("\\") + 1);
                    string extension = uploadedFileName.Substring(uploadedFileName.LastIndexOf(".") + 1);
                    switch (extension.ToLower())
                    {
                        case "jpg":
                            mimetype = "JPG";
                            break;
                        case "gif":
                            mimetype = "gif";
                            break;
                        case "jpeg":
                            mimetype = "jpeg";
                            break;
                        default:
                            // _view.ShowMessage("We only accept .png, .jpg, and .gif!");
                            return;
                    }

                    string fullFileName = saveToFolder + "\\" + guidName.ToString() + "__O." + extension;
                    File.SaveAs(fullFileName);
                    if (File.ContentLength / 1000 < 4000)
                    {
                        File.InputStream.Read(uploadedImage, 0, uploadedImage.Length);
                        child.ChildPic1ID = uploadedImage;
                        child.FileName = guidName.ToString() + "__O." + extension;
                    }
                    else
                    {
                        // _view.ShowMessage("The file you uploaded is larger than the 4mb limit.  Please reduce the size of your file and try again.");
                    }
                }
                child.AccountID = d.CurrentUser.AccountID;
                d.SaveChild(child);
                TBName.Text = "";
                TBAge.Text = "";
                TBCity.Text = "";
                TBCountry.Text = "";
                TBAddress.Text = "";
                TBStory.Text = "";
                TBAddress.Text = "";
                TBCareNumber.Text = "";
            }

        }
    }
}