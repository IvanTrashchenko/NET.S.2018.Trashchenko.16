using System;

namespace BinarySearchTreeLibrary.ConsoleTests
{
    public class Book : IComparable<Book>
    {
        public Book(int cost)
        {
            this.Cost = cost;
        }

        public int Cost { get; set; }

        public int CompareTo(Book other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (other == null)
            {
                return 1;
            }

            return this.Cost.CompareTo(other.Cost);
        }

        public override string ToString()
        {
            return $"Book of {nameof(this.Cost)}: {this.Cost}";
        }
    }
}
