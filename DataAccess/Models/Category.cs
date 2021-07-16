using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}
