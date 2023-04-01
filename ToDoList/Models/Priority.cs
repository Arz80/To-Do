using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    [DisplayColumn("Приоритет")]
    public class Priority
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Приоритет задачи")]
        [Required]
        public string? Name { get; set; }
    }
}
