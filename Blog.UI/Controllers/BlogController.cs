using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.BL;
using Blog.Entities.Entities;
using MongoDB.Bson;

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

        [HttpPost]
        public ActionResult Post(ObjectId postId, Comment comment) {
            Post post = _postService.GetOnePost(postId);
            if (post == null) { return new HttpNotFoundResult(); }
            if (TryValidateModel(comment)) {
                _postService.SaveComment(postId, comment);
                return RedirectToAction("post", new { id = post.Url });
            }
            return View(post);
        }

        [Authorize]
        public ActionResult add() {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(Post post) {
            if (ModelState.IsValid) {
                post.Url = post.Title.ToUrl();
                post.Author = User.Identity.Name;
                post.Date = DateTime.Now;

                _postService.Save(post);

                return RedirectToAction("Index");
            }

            return View();
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
                post.Url = post.Title.ToUrl();
                post.Author = User.Identity.Name;
                post.Date = DateTime.Now;

                _postService.Save(post);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(String id) {
            Post post = _postService.GetOnePost(id);
            if (post == null) { return new HttpNotFoundResult(); }
            _postService.Delete(post);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteComment(String id, ObjectId commentID) {
            Post post = _postService.GetOnePost(id);
            if (post == null) { return new HttpNotFoundResult(); }
            _postService.DeleteComment(post,commentID);
            return RedirectToAction("post", new { id=id });
        }

       


    }
}
