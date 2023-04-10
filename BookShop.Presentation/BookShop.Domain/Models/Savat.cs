using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Models
{
    public class Savat
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public User? User { get; set; } = null;
        public Book? Book { get; set; } = null;

    }
}
