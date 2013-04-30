using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.BL;
using Blog.Entities.Entities;

namespace Blog.UI.Controllers
{
    public class BlogController : BaseController
    {
        private IPostService _postService;

        public BlogController(IPostService srv) {
            _postService = srv;
        }

        public ActionResult Index()
        {
            return View(_postService.GetAllPosts());
        }

        public ActionResult Post(String id) {
            Post post = _postService.GetOnePost(id);
            if (post == null) { return new HttpNotFoundResult(); }
            return View(post);
        }

        [HttpGet]
        public ActionResult Edit(String id) {
            Post post = _postService.GetOnePost(id);
            if (post == null) { return new HttpNotFoundResult(); }
            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(Post post) {
            if (ModelState.IsValid) {
                post.Url = post.Title.toUrl();
                post.Author = User.Identity.Name;
                post.Date = DateTime.Now;

                _postService.Create(post);

                return RedirectToAction("Index");
            }

            return View();
        }


    }
}
