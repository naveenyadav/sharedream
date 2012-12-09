using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Zero.ShareDream;

namespace Zero.ShareDream
{
    public class database
    {
        public DonationDataContext GetContext()
        {
            string connString = "";
            try
            {
                connString = System.Configuration.ConfigurationManager.ConnectionStrings["DataSourceConnectionString"].ConnectionString;
            }
            catch{}
            DonationDataContext fdc = new DonationDataContext(connString);
            return fdc;
        }
        //----------------------------------------------------------------------------------------
        public Account GetAccountByID(string Email)
        {
            Account account = null;
            using (DonationDataContext dc = GetContext())
            {
                account = (from a in dc.Accounts
                           where a.Email == Email
                           select a).FirstOrDefault();
            }
            return account;
        }
        public Account GetAccountByAccountID(long acntID)
        {
            Account account = null;
            using (DonationDataContext dc = GetContext())
            {
                account = (from a in dc.Accounts
                           where a.AccountID == acntID
                           select a).FirstOrDefault();
            }
            return account;
        }
        //--Get child by child ID.--------------------------------------------------------------------------------------
        public Child GetChildByID(long childID)
        {
            Child child = null;
            using (DonationDataContext dc = GetContext())
            {
                child = (from a in dc.Childs
                           where a.ChildID == childID
                           select a).FirstOrDefault();
            }
            return child;
        }
        //---------------------------------------------------------------------------------------------------------------
        public Help GetHelpByID(long helpID)
        {
            Help help = null;
            using (DonationDataContext dc = GetContext())
            {
                help = (from a in dc.Helps
                         where a.HelpID == helpID
                         select a).FirstOrDefault();
            }
            return help;
        }
        //-----Get Child by account ID------------------------------------------------------------------------------------
        public List<Child> GetAllChildByAccountID(long accountID)
        {
            List<Child> result = new List<Child>();
            using (DonationDataContext dc = GetContext())
            {
                IEnumerable<Child> childs = (from a in dc.Childs where a.AccountID == accountID
                                                 orderby a.ChildName
                                                 select a);
                result = childs.ToList();
            }
            return result;
        }
        //-----Get Child by account ID------------------------------------------------------------------------------------
        public List<Help> GetAllhelpByChildID(long childID)
        {
            List<Help> result = new List<Help>();
            using (DonationDataContext dc = GetContext())
            {
                IEnumerable<Help> helps = (from a in dc.Helps
                                             where a.HelpChildID == childID
                                             orderby a.CreateDate
                                             select a);
                result = helps.ToList();
            }
            return result;
        }
        //-----Get Child by account ID------------------------------------------------------------------------------------
        public List<Notify> GetAllNotifyByAccountID(long accountID)
        {
            List<Notify> result = new List<Notify>();
            using (DonationDataContext dc = GetContext())
            {
                IEnumerable<Notify> notifys = (from a in dc.Notifies
                                           where a.AccountID == accountID
                                           orderby a.CreateDate
                                           select a);
                result = notifys.ToList();
            }
            return result;
        }
        public List<Child> GetAllChildren()
        {
            List<Child> result = new List<Child>();
            using (DonationDataContext dc = GetContext())
            {
                IEnumerable<Child> childss = (from a in dc.Childs
                                               orderby a.CreateDate
                                               select a);
                result = childss.ToList();
            }
            return result;
        }
        //--------Search Childs----------------------------------------------------------------------------------
        public List<Child> SearchNameChilds(string name, int category)
        {
            List<Child> result = new List<Child>();
            if (category == 1)
            {
               using (DonationDataContext dc = GetContext())
                {
                    IEnumerable<Child> childs = from a in dc.Childs
                                                where (a.ChildName).Contains(name)
                                                select a;
                    result = childs.ToList();
                }
                return result;
            }
            else if (category == 2)
            {
                using (DonationDataContext dc = GetContext())
                {
                    IEnumerable<Child> childs = from a in dc.Childs
                                                where (a.ChildCity).Contains(name)
                                                select a;
                    result = childs.ToList();
                }
                return result;
            }
            else if (category == 3)
            {
                using (DonationDataContext dc = GetContext())
                {
                    IEnumerable<Child> childs = from a in dc.Childs
                                                where (a.ChildCountry).Contains(name) 
                                                select a;
                    result = childs.ToList();
                }
                return result;
            }
            else
                return null;
        }
        
        //---------------------------------------------------------------------------------------------
        public void SaveAccount(Account account)
        {
            using (DonationDataContext dc = GetContext())
            {
                if (account.AccountID > 0)
                {
                    dc.Accounts.Attach(account, true);
                }
                else
                {
                    account.CreateDate = DateTime.Now;
                    dc.Accounts.InsertOnSubmit(account);
                }
                dc.SubmitChanges();
            }
        }
        //-----------------------------------------------------------------------------------------------
        public void SaveChild(Child child)
        {
            using (DonationDataContext dc = GetContext())
            {
                if (child.ChildID > 0)
                {
                    dc.Childs.Attach(child, true);
                }
                else
                {
                    child.CreateDate = DateTime.Now;
                    dc.Childs.InsertOnSubmit(child);
                }
                dc.SubmitChanges();
            }
        }
        //-----------------------------------------------------------------------------------------------
        public void SaveHelp(Help help)
        {
            using (DonationDataContext dc = GetContext())
            {
                if (help.HelpID > 0)
                {
                    dc.Helps.Attach(help, true);
                }
                else
                {
                    help.CreateDate = DateTime.Now;
                    dc.Helps.InsertOnSubmit(help);
                }
                dc.SubmitChanges();
            }
        }
        //---------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        public void SaveNotify(Notify notify)
        {
            using (DonationDataContext dc = GetContext())
            {
                if (notify.NotifyID > 0)
                {
                    dc.Notifies.Attach(notify, true);
                }
                else
                {
                    notify.CreateDate = DateTime.Now;
                    dc.Notifies.InsertOnSubmit(notify);
                }
                dc.SubmitChanges();
            }
        }
        public bool LoggedIn
        {
            get
            {
                if (ContainsInSession("LoggedIn"))
                {
                    if ((bool)GetFromSession("LoggedIn"))
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                SetInSession("LoggedIn", value);
            }
        }
        public Account CurrentUser
        {
            get
            {
                if (ContainsInSession("CurrentUser"))
                {
                    return GetFromSession("CurrentUser") as Account;
                }

                return null;
            }
            set
            {
                SetInSession("CurrentUser", value);
            }
        }

        public bool ContainsInSession(string key)
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session[key] != null)
                return true;
            return false;
        }
        private void SetInSession(string key, object value)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return;
            }
            HttpContext.Current.Session[key] = value;
        }

        private object GetFromSession(string key)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return null;
            }
            return HttpContext.Current.Session[key];
        }
        
    }
}