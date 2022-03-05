using System;

namespace SimbirHomework.Models
{
    /// <summary>
    /// 2.2.1 Класс человека
    /// </summary>
    public class HumanDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
    }
}