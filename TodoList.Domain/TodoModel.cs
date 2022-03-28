using System.ComponentModel.DataAnnotations;

namespace TodoList.Domain
{
    public class TodoModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public PostStatus Status { get; set; }
    }

    public enum PostStatus
    {
        InProgress,
        Finished
    }
}
