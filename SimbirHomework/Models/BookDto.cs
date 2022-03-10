using System.ComponentModel.DataAnnotations;

namespace SimbirHomework.Models
{
    /// <summary>
    /// 1.2.2.2 Класс книги
    /// </summary>
    public class BookDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public HumanDto Author { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Title { get; set; }
    }
}