using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title cannot be empty!")]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters!")]
        [DisplayName("Title*")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mission description cannot be empty!")]
        [MaxLength(160, ErrorMessage = "Mission description is 160 characters maximum!")]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters!")]
        [DisplayName("Task Description*")]
        public string Description { get; set; }

        [DisplayName("Created Date")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Status")]
        public bool IsCompleted { get; set; }

        [Required(ErrorMessage = "Completion time cannot be empty!")]
        [DisplayName("Completion Time*")]
        public DateTime EndedDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}