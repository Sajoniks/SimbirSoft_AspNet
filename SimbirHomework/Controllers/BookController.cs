using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimbirHomework.Models;

namespace SimbirHomework.Controllers
{
    /// <summary>
    /// 4. Контроллер книги
    /// </summary>
    [Route("api/books")]
    public class BookController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetBooks(int? author)
        {
            var books = MockDb.Books;
            if (author == null) return Json(books);
            
            try
            {
                books = books.Where(b => b.Author.Id == author);
            }
            catch (InvalidOperationException e)
            {
                return Json(MockDb.Books);
            }

            return Json(books);
        }

        [HttpPost]
        [Route("new")]
        public IActionResult PostBook(BookDto book, int authorId)
        {
            book.Author = MockDb.GetHuman(authorId);
            MockDb.AddBook(book);
            
            return RedirectToAction("GetBooks");
        }

        [HttpGet]
        [Route("new")]
        public IActionResult PostBook()
        {
            return View();
        }
        
        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteBook(int id)
        {
            MockDb.DropBook(id);
            return RedirectToAction("GetBooks");
        }
    }
}