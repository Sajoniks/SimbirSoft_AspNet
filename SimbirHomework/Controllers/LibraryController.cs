using System;
using Microsoft.AspNetCore.Mvc;
using SimbirHomework.Models;

namespace SimbirHomework.Controllers
{
    [Route("api/library")]
    public class LibraryController : Controller
    {
        [HttpGet]
        public IActionResult GetLibrary()
        {
            return Json(MockDb.LibraryCards);
        }

        [HttpPost]
        [Route("request")]
        public IActionResult RequestBook(LibraryCard card)
        {
            try
            {
                MockDb.RequestBook(card.Reader, card.Book);
                return RedirectToAction("GetLibrary", "Library");
            }
            catch (InvalidOperationException e)
            {
                return Json(e.Message);
            }
        }
    }
}