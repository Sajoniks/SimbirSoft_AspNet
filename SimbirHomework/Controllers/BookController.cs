#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimbirHomework.Models;

namespace SimbirHomework.Controllers
{
    /// <summary>
    /// 1.4. Контроллер книги
    /// </summary>
    [Route("api/books")]
    public class BookController : Controller
    {
        internal class OrderAlgo<TKey>
        {
            public Func<BookDto, TKey> Algo { get; }
            public OrderAlgo(Func<BookDto, TKey> selector)
            {
                Algo = selector;
            }
        }

        // Правила сортировки
        private static readonly Dictionary<string, OrderAlgo<string>> OrderAlgos = new Dictionary<string, OrderAlgo<string>>()
        {
            {nameof(BookDto.Author).ToLower(), new OrderAlgo<string>(b => $"{b.Author.Name} {b.Author.Surname} {b.Author.Patronymic}".Trim())},
            {nameof(BookDto.Genre).ToLower(), new OrderAlgo<string>(b => b.Genre)},
            {nameof(BookDto.Title).ToLower(), new OrderAlgo<string>(b => b.Title)}
        };
        

        /// <summary>
        /// 1.4.1 Получить список всех книг
        /// </summary>
        /// <param name="author">Если не Null, поиск книг заданного автора</param>
        /// <param name="orderBy">Ключ сортировки</param>
        /// <returns>Список книг</returns>
        [HttpGet]
        [Route("")]
        public IActionResult GetBooks(int? author, string? orderBy)
        {
            var books = MockDb.Books;

            if (author != null)
            {
                try
                {
                    books = books.Where(b => b.Author.Id == author);
                }
                catch (InvalidOperationException e)
                {
                    return Json(MockDb.Books);
                }
            }

            // 2.2.2 Сортировка по разным ключам
            if (orderBy != null)
            {
                try
                {
                    books = books.OrderBy(OrderAlgos[orderBy].Algo);
                }
                catch (KeyNotFoundException)
                {
                    // No sort
                }
            }

            return Json(books);
        }

        /// <summary>
        /// 1.4.2 Добавление новой книги
        /// </summary>
        /// <param name="book">Книга которую добавить</param>
        /// <param name="authorId">Id автора книги</param>
        /// <returns>Вызов GetBooks</returns>
        [HttpPost]
        [Route("new")]
        public IActionResult PostBook(BookDto book, int authorId)
        {
            book.Author = MockDb.GetHuman(authorId);
            MockDb.AddBook(book);
            
            return RedirectToAction("GetBooks");
        }

        /// <summary>
        /// Открыть форму добавления информации о книге
        /// </summary>
        /// <returns>Форма добавления данных о книге</returns>
        [HttpGet]
        [Route("new")]
        public IActionResult PostBook()
        {
            return View();
        }
        
        /// <summary>
        /// 1.4.3 Удаление книги
        /// </summary>
        /// <param name="id">Id книги на удаление</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteBook(int id)
        {
            MockDb.DropBook(id);
            return RedirectToAction("GetBooks");
        }
    }
}