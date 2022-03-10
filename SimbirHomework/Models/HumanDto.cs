using System;
using System.ComponentModel.DataAnnotations;

namespace SimbirHomework.Models
{
    /// <summary>
    /// 2.2.1 Класс человека
    /// </summary>
    public class HumanDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
    }
}