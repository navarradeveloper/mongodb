using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.UI.Controllers
{
    public class BaseController : Controller
    {

        #region Properties

        protected int CurrentPage {
            get {
                int result;
                if (Request.QueryString["p"] == null) {
                    result = 1;
                } else {
                    int.TryParse((String)Request.QueryString["p"], out result);
                }
                if (result < 1) { result = 1; }
                return result;
            }
        }

        #endregion

    }
}
