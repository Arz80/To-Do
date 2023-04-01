using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    [DisplayColumn("Статус")]
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Статус задачи")]
        [Required]
        public string? Name { get; set; }
    }
}
