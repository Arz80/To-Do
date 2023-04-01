using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    [DisplayColumn("Задача")]
    public class ToDoTask
    {
        [Key]
        [Display(Name = "Номер")]
        public int Id { get; set; }

        [Display(Name = "Наименование задачи")]
        [Required]
        public string? Name { get; set; }
        [Display(Name = "Описание задачи")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        
        [Required]
        public int StatusId { get; set; }
        [Display(Name = "Статус")]
        public virtual Status? Status { get; set; }
        [Required]
        public int PriorityId { get; set; }
        [Display(Name = "Приоритет")]
        public virtual Priority? Priority { get; set; }


    }
}
