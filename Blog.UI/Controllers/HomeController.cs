using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.BL;
using Blog.Entities.Entities;

namespace Blog.UI.Controllers
{
    public class HomeController : Controller
    {


        private IPostService _postService;

        public HomeController(IPostService srv) {
            _postService = srv;
        }

        public ActionResult Index()
        {

            IList<Post> posts =  _postService.GetAllPosts();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
