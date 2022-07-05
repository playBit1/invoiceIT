using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace invoiceIT.Db_Classes
{
    public class AppUtilities
    {

        public static bool IsEmpty<T>(List<T> list)
        { // This class checks to see if a passed list is empty ot not empty
            if (list == null)
            {
                return true; // the passed list is empty
            }
            // The Any method checks whether any of the element in a sequence satisfy a specific condition or not, i.e. contains elements or does not contain elements. In this case, if the passed list in not (!) empty, then false will be returned
            return !list.Any(); // i.e. false, the passed list is not empty
        }

        public static void ClearForm(ControlCollection frmCtrls)
        { // class begin

            foreach (Control frmCtrl in frmCtrls)
            {
                string ffield = (frmCtrl.GetType()).Name;

                switch (ffield)
                {
                    case "TextBox":
                        TextBox tbSource = (TextBox)frmCtrl;
                        tbSource.Text = "";
                        break;
                    case "RadioButtonList":
                        RadioButtonList rblSource = (RadioButtonList)frmCtrl;
                        rblSource.SelectedIndex = -1;
                        break;
                    case "DropDownList":
                        DropDownList ddlSource = (DropDownList)frmCtrl;
                        ddlSource.SelectedIndex = -1;
                        break;
                    case "ListBox":
                        ListBox lbsource = (ListBox)frmCtrl;
                        lbsource.SelectedIndex = -1;
                        break;
                }
                ClearForm(frmCtrl.Controls);
            }

        } // class end
    }
}