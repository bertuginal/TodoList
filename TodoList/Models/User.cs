using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username cannot be empty!")]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters!")]
        [DisplayName("Username*")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be empty!")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters!")]
        [DataType(DataType.Password)]
        [DisplayName("Password*")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password cannot be empty!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match!")]
        [DisplayName("Confirm Password*")]
        public string ConfirmPassword { get; set; }

        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}