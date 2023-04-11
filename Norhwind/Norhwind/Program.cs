using Norhwind.Northwind;

namespace Norhwind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NorthWindContext db = new NorthWindContext();
            db.Add();
            
        }
    }
}