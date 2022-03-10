using System;
using System.Collections.Generic;
using System.Linq;
using SimbirHomework.Models;

namespace SimbirHomework
{
    public class MockDb
    {
        /// <summary>
        /// 1.2.2.3 Статичный список людей
        /// </summary>
        private static List<HumanDto> _humans = new List<HumanDto>()
        {
            new HumanDto()
            {
                Id = 0,
                Name = "Bob",
                Surname = "Bobby",
                Patronymic = null,
                Birthday = DateTime.ParseExact("01.05.1994", "dd.MM.yyyy", null)
            },
            new HumanDto()
            {
                Id = 1,
                Name = "Ivan",
                Surname = "Ivanov",
                Patronymic = null,
                Birthday = DateTime.ParseExact("02.02.1993", "dd.MM.yyyy", null)
            },
            new HumanDto()
            {
                Id = 2,
                Name = "Garry",
                Surname = "Newman",
                Patronymic = null,
                Birthday = DateTime.ParseExact("05.05.1992", "dd.MM.yyyy", null)
            }
        };

        /// <summary>
        /// 1.2.2.3. Статичный список книг
        /// </summary>
        private static List<BookDto> _books = new List<BookDto>()
        {
            new BookDto()
            {
                Id = 0,
                Author = GetHuman(1),
                Genre = "Genre A",
                Title = "Book A"
            },
            new BookDto()
            {
                Id = 1, 
                Author = GetHuman(1),
                Genre = "Genre A",
                Title = "Book B"
            },
            new BookDto()
            {
                Id = 2,
                Author = GetHuman(0),
                Genre = "Genre B",
                Title = "Book C"
            }
        };

        /// <summary>
        /// 2.1.3 Статичный список LibraryCards 
        /// </summary>
        private static List<LibraryCard> _cards = new List<LibraryCard>();
        
        
        /*+-------------------------------------------------------------------------+*/
        /*|                            HumanDto-функции                             |*/
        /*+-------------------------------------------------------------------------+*/
        
        /// <summary>
        /// 1.2.2.3
        /// Статичный список людей
        /// </summary>
        public static IEnumerable<HumanDto> Humans => _humans;

        /// <summary>
        /// Добавить нового человека
        /// </summary>
        /// <param name="humanDto"></param>
        public static void AddHuman(HumanDto humanDto)
        {
            try
            {
                humanDto.Id = _humans.Max(s => s.Id) + 1;
            }
            catch (InvalidOperationException e)
            {
                humanDto.Id = 0;
            }
            
            _humans.Add(humanDto);
        }
        
        /// <summary>
        /// Найти человека по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static HumanDto GetHuman(int id)
        {
            return Humans.FirstOrDefault(h => h.Id == id);
        }

        /// <summary>
        /// Удалить человека
        /// </summary>
        /// <param name="id"></param>
        public static void DropHuman(int id)
        {
            try
            {
                _humans.Remove(
                    _humans.First(h => h.Id == id)
                );

                _books.Remove(
                    _books.FirstOrDefault(b => b.Author.Id == id)
                );
            }
            catch (InvalidOperationException e)
            {
                
            }
        }
        
        
        /*+-------------------------------------------------------------------------+*/
        /*|                            BookDto-функции                              |*/
        /*+-------------------------------------------------------------------------+*/
        
        /// <summary>
        /// 1.2.2.3. Статичный список книг
        /// </summary>
        public static IEnumerable<BookDto> Books => _books;

        /// <summary>
        /// Добавить новую книгу
        /// </summary>
        /// <param name="book"></param>
        public static void AddBook(BookDto book)
        {
            try
            {
                book.Id = _books.Max(b => b.Id) + 1;
            }
            catch (InvalidOperationException e)
            {
                book.Id = 0;
            }
            
            _books.Add(book);
        }

        public static BookDto GetBook(int bookId)
        {
            return Books.FirstOrDefault(b => b.Id == bookId);
        }

        /// <summary>
        /// Удалить книгу
        /// </summary>
        /// <param name="bookId"></param>
        public static void DropBook(int bookId)
        {
            _books.Remove(
                _books.FirstOrDefault(b => b.Id == bookId)
            );
        }
        
        
        /*+-------------------------------------------------------------------------+*/
        /*|                         LibraryCard-функции                             |*/
        /*+-------------------------------------------------------------------------+*/

        /// <summary>
        /// 2.1.3 Список 
        /// </summary>
        public static IEnumerable<LibraryCard> LibraryCards => _cards;
        
        /// <summary>
        /// Взять книгу
        /// </summary>
        /// <param name="by">Кем</param>
        /// <param name="book">Какую</param>
        public static void RequestBook(HumanDto by, BookDto book)
        {
            var booked = _cards.FirstOrDefault(c => c.Reader.Id == by.Id && c.Book.Id == book.Id );
            if (booked != null) throw new InvalidOperationException("Book already requested");

            var request = new LibraryCard()
            {
                Book = GetBook(book.Id),
                Reader = GetHuman(by.Id)
            };

            try
            {
                request.Id = _cards.Max(c => c.Id) + 1;
            }
            catch (InvalidOperationException e)
            {
                request.Id = 0;
            }

            _cards.Add(request);
        }
    }
}