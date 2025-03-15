using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
	public class Note
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Title cannot be empty!")]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters!")]
        [DisplayName("Title*")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mission description cannot be empty!")]
        [MaxLength(1000, ErrorMessage = "Mission description is 1000 characters maximum!")]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters!")]
        [DisplayName("Note Description*")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Reminder")]
        public DateTime Reminder { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}