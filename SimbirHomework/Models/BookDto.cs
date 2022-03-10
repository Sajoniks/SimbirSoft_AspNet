namespace SimbirHomework.Models
{
    /// <summary>
    /// 1.2.2 Класс книги
    /// </summary>
    public class BookDto
    {
        public int Id { get; set; }
        public HumanDto Author { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
    }
}