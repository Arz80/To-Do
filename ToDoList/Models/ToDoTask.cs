using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    [DisplayColumn("Задача")]
    public class ToDoTask
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Наименование задачи")]
        [Required]
        public string? Name { get; set; }
        [Display(Name = "Описание задачи")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        [Display(Name = "Дата открытия")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? OpenDate { get; set; }
        [Display(Name = "Дата закрытия")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        [Display(Name = "Статус")]
        [Required]
        public List<string> status = new List<string>() {"Новая", "Открытая", "Закрытая"};
        [Required]
        [Display(Name = "Приоритет")]
        public List<string> Priority = new List<string>() { "Низкий", "Средний", "Высокий" };

    }
}
