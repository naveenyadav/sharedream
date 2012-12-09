using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zero.ShareDream;
using Zero.ShareDream;

namespace Zero.ShareDream
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        private database d;
        protected void Page_Load(object sender, EventArgs e)
        {
            d = new database();
            if (d.LoggedIn == true)
            {
                PBefore.Visible = false;
                PAfterLogin.Visible = true;
            }
            else
            {
                PBefore.Visible = true;
                PAfterLogin.Visible = false;
            }

        }
        protected void LBSignup_Click(object sender, EventArgs e)
        {
            PSignup.Visible = true;
            PBeforeLogin.Visible = false;
        }
        protected void LBLogin_Click(object sender, EventArgs e)
        {
            PSignup.Visible = false;
            PBeforeLogin.Visible = true;
        }
        protected void BsignIn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TBEmail.Text) && !string.IsNullOrEmpty(TBPassword.Text))
            {
                Account acnt = d.GetAccountByID(TBEmail.Text);
                if (acnt != null)
                {
                    if (acnt.Password == TBPassword.Text)
                    {
                        
                        PBefore.Visible = false;
                        PAfterLogin.Visible = true;
                        d.LoggedIn = true;
                        d.CurrentUser = acnt;
                        Response.Redirect("~/ChildProfile.aspx");
                    }
                    else
                    {
                        LError.Text = "Incorrect Email Or Password.";
                        TBPassword.Text = "";

                    }
                }
            }
           
            
        }
        protected void LBSignOut_Click(object sender, EventArgs e)
        {
           
            PBefore.Visible = true;
            PAfterLogin.Visible = false;
            d.LoggedIn = false;
            d.CurrentUser = null;
            Response.Redirect("http://www.sharedream.in/Default.aspx");
        }
        protected void LBAdopted_Click(object sender, EventArgs e)
        {


            Response.Redirect("http://www.sharedream.in/ChildProfile.aspx");
        }
        protected void LCreate_Click(object sender, EventArgs e)
        {


            Response.Redirect("http://www.sharedream.in/Profile.aspx");
        }
        protected void BSignup_Click(object sender, EventArgs e)
        {
            if (
                !string.IsNullOrEmpty(Signup_TBName.Text) &&
                !string.IsNullOrEmpty(Signup_TBEmail.Text) &&
                !string.IsNullOrEmpty(Signup_TBPassword.Text) &&
                !string.IsNullOrEmpty(TBAddress.Text) &&
                !string.IsNullOrEmpty(Signup_Mobile.Text) &&
                !string.IsNullOrEmpty(Signup_City.Text)
                )
            {
                Account acnt = new Account();
                acnt.Name = Signup_TBName.Text;
                acnt.Email = Signup_TBEmail.Text;
                acnt.Password = Signup_TBPassword.Text;
                acnt.MobileNo = Convert.ToInt64(Signup_Mobile.Text);
                acnt.Address = TBAddress.Text;
                acnt.CreateDate = DateTime.Now;
                acnt.CurrentCity = Signup_City.Text;
                d.SaveAccount(acnt);
            }
            Signup_TBName.Text = "";
            Signup_TBEmail.Text = "";
            Signup_Mobile.Text = "";
            Signup_City.Text = "";
            TBAddress.Text = "";
        }

    }
}
