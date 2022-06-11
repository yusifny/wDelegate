using System;

namespace Delegate.Models
{
    public class Medicine
    {
        private static int _id;
        public int Id { get; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Medicine(string name, double price, int count)
        {
            _id++;
            Id = _id;
            Name = name;
            Price = price;
            Count = count;
        }

        public void Sell()
        {
            Count--;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Id{_id}\n Name{Name}\n Price{Price}\n Count{Count}\n Deleted {IsDeleted}");
        }
    }
}