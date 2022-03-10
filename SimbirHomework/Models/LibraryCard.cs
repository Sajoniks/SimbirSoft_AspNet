using System;

namespace SimbirHomework.Models
{
    /// <summary>
    /// 2.1.1 Агрегатор LibraryCard
    /// </summary>
    public class LibraryCard
    {
        public int Id { get; set; }
        public HumanDto Reader { get; set; }
        public BookDto Book { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}