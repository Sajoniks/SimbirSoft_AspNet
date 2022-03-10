using System;
using System.ComponentModel.DataAnnotations;

namespace SimbirHomework.Models
{
    /// <summary>
    /// 2.1.1 Агрегатор LibraryCard
    /// </summary>
    public class LibraryCard
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public HumanDto Reader { get; set; }
        [Required]
        public BookDto Book { get; set; }
        [Required]
        public DateTimeOffset Time { get; set; }
    }
}