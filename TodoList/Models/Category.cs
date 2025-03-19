using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
	public class Category
	{
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}