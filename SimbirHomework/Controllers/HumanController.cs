#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimbirHomework.Models;

namespace SimbirHomework.Controllers
{
    /// <summary>
    /// 3. Контроллер человека
    /// </summary>
    [Route("api/humans")]
    public class HumanController : Controller
    {
        /// <summary>
        /// 1.3.1 Список всех людей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IActionResult GetHumans(string? query = null, bool? authors = null)
        {
            var humans = MockDb.Humans;
            
            try
            {
                // Фильтр по поисковой фразе
                if (!String.IsNullOrWhiteSpace(query))
                {
                    query = query.Trim();
                    
                    humans = humans.Where(h =>
                        {
                            var fullName = $"{h.Name} {h.Surname} {h.Patronymic}".Trim();
                            return fullName.Contains(query, StringComparison.InvariantCultureIgnoreCase);
                        }
                    );
                }

                // Только авторы?
                if (authors != null && authors.Value)
                {
                    // Авторы
                    var books = MockDb.Books.Select(b => b.Author.Id);
                    // Только те чьи ID есть в полученной коллекции
                    humans = humans.Where(h => books.Contains(h.Id));
                }
            }
            catch (InvalidOperationException e)
            {
                // log
                return Json(MockDb.Humans);
            }

            return Json(humans);
        }

        /// <summary>
        /// 1.3.2 Добавить нового человека
        /// </summary>
        /// <param name="human">Человек</param>
        /// <returns></returns>
        [HttpPost]
        [Route("new")]
        public IActionResult PostHuman(HumanDto human)
        {
            MockDb.AddHuman(human);
            return RedirectToAction("GetHumans");
        }

        /// <summary>
        /// Get-вариант PostHuman для вывода формы добавления человека
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("new")]
        public IActionResult PostHuman()
        {
            return View();
        }

        /// <summary>
        /// 1.3.3. Удалить человека
        /// </summary>
        /// <param name="id">Id человека</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteHuman(int id)
        {
            MockDb.DropHuman(id);
            return RedirectToAction("GetHumans");
        }
    }
}