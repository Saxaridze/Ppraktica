using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace ATM
{
    [Table(Name = "Выдача")]
    public class Выдача
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public int ID_читатель { get; set; }
        [Column]
        public int ID_книги { get; set; }
        [Column]
        public DateTime Дата_выдачи { get; set; }
        [Column]
        public DateTime Дата_возврата { get; set; }
    }
    [Table(Name = "Читатель")]
    public class Читатель
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID_билета { get; set; }
        [Column]
        public string Фамилия { get; set; }
        [Column]
        public string Имя { get; set; }
        [Column]
        public string Отчество { get; set; }
        [Column]
        public DateTime Дата_рождения { get; set; }
        [Column]
        public string Адрес { get; set; }
        [Column]
        public string Телефон { get; set; }
        [Column]
        public DateTime Дата_выдачи_билета { get; set; }
        [Column]
        public DateTime Срок_действия_билета { get; set; }
    }
    [Table(Name = "Издание_произведения")]
    public class Издание_произведения
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID_издания_произведения { get; set; }
        [Column]
        public int Произведение { get; set; }
        [Column]
        public int Издание { get; set; }
    }
    [Table(Name = "Издание")]
    public class Издание
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public string Название { get; set; }
        [Column]
        public string Характеристика { get; set; }
        [Column]
        public int Объем { get; set; }
        [Column]
        public string Год { get; set; }
        [Column]
        public int Издательство { get; set; }
    }
    [Table(Name = "Произведение")]
    public class Произведение
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public string Название { get; set; }
        [Column]
        public int Год { get; set; }
    }
    [Table(Name = "Издательство")]
    public class Издательство
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public string Название { get; set; }
        [Column]
        public int Город { get; set; }
        [Column]
        public string Адрес { get; set; }
        [Column]
        public string Телефон { get; set; }
        [Column]
        public string Факс { get; set; }
    }
    [Table(Name = "Город")]
    public class Город
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public string Название { get; set; }
        [Column]
        public string Страна { get; set; }
    }
    [Table(Name = "Категория_произведения")]
    public class Категория_произведения
    {
        [Column(IsDbGenerated = false, IsPrimaryKey = false)]
        public int ID_категории { get; set; }
        [Column]
        public int ID_произведения { get; set; }
    }
    [Table(Name = "Автор_произведения")]
    public class Автор_произведения
    {
        [Column(IsDbGenerated = false, IsPrimaryKey = false)]
        public int ID_произведения { get; set; }
        [Column]
        public int ID_автора { get; set; }
    }
    [Table(Name = "Автор")]
    public class Автор
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public string Фамилия { get; set; }
        [Column]
        public string Имя { get; set; }
        [Column]
        public string Отчество { get; set; }
        [Column]
        public DateTime Дата_рождения { get; set; }
        [Column]
        public string Биография { get; set; }
    }
    [Table(Name = "Категория")]
    public class Категория
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public string Название { get; set; }
    }
}
