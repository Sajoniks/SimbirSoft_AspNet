using System;
using System.ComponentModel.DataAnnotations;

namespace SimbirHomework.Models
{
    /// <summary>
    /// 1.2.2.1 Класс человека
    /// </summary>
    public class HumanDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        
        [DataType(DataType.Date)]
        [Required]
        public DateTime Birthday { get; set; }
    }
}