using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SonOfCod.Models;
using SonOfCod.ViewModels;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SonOfCod.Controllers
{
    public class NewsLetterController : Controller
    {
        private readonly SonOfACodDbContext _db;
        private readonly UserManager<User> _userManager;


        public NewsLetterController(UserManager<User> userManager, SonOfACodDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.NewsLetters.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisNewsLetter = _db.NewsLetters.FirstOrDefault(newsLetters => newsLetters.NewsLetterId == id);
            return View(thisNewsLetter);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewsLetter newsLetter)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            newsLetter.User = currentUser;
            _db.NewsLetters.Add(newsLetter);
            _db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }
        public IActionResult Edit(int id)
        {
            var thisNewsLetter = _db.NewsLetters.FirstOrDefault(newsLetter => newsLetter.NewsLetterId == id);
            return View(thisNewsLetter);
        }
        [HttpPost]
        public IActionResult Edit(NewsLetter newsLetter)
        {
            _db.Entry(newsLetter).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }
        public ActionResult Delete(int id)
        {
            var thisNewsLetter = _db.NewsLetters.FirstOrDefault(newsLetter => newsLetter.NewsLetterId == id);
            return View(thisNewsLetter);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisNewsLetter = _db.NewsLetters.FirstOrDefault(newsLetter => newsLetter.NewsLetterId == id);
            _db.NewsLetters.Remove(thisNewsLetter);
            _db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }
    }
}
