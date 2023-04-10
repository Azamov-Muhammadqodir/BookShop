using BookShop.Domain.States;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public BookCategoryEnum? Category { get; set; }

    }
}
