using System;
using System.Collections.Generic;

namespace BinarySearchTreeLibrary.ConsoleTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BinarySearchTree<int> treeFirst = new BinarySearchTree<int>();

            treeFirst.Add(1);
            treeFirst.Add(2);
            treeFirst.Add(3);

            foreach (var item in treeFirst.InOrder())
            {
                Console.Write(item + " "); // 3 2 1
            }

            Console.WriteLine();

            int Compare(int x, int y)
            {
                if (x > y)
                {
                    return 1;
                }

                if (x < y)
                {
                    return -1;
                }

                return 0;
            }

            BinarySearchTree<int> treeSecond = new BinarySearchTree<int>(
                new int[] { 12, 4, 5, 6, 8, 9, 43, 2, 567, 8 },
                Compare);

            foreach (var item in treeSecond.PreOrder())
            {
                Console.Write(item + " "); // 12 43 567 4 5 6 8 9 8 2
            }

            Console.WriteLine();

            BinarySearchTree<string> treeThird = new BinarySearchTree<string>(
                new string[] { "a", "b", "c", "d", "e" },
                string.Compare);

            BinarySearchTree<string> treeForth = new BinarySearchTree<string>(new string[] { "a", "b", "c", "d", "e" });

            foreach (var item in treeThird.PostOrder())
            {
                Console.Write(item + " "); // e d c b a
            }

            Console.WriteLine();

            foreach (var item in treeForth.PostOrder())
            {
                Console.Write(item + " "); // e d c b a
            }

            Console.WriteLine();

            Console.WriteLine(treeForth.Contains("e")); // true

            Console.WriteLine(treeForth.Contains(null)); // false

            treeForth.Clear();

            Console.WriteLine(treeForth.Contains("e")); // false

            BinarySearchTree<Book> treeFifth = new BinarySearchTree<Book>();

            treeFifth.Add(new Book(3));
            treeFifth.Add(new Book(4));
            treeFifth.Add(new Book(5));
            treeFifth.Add(new Book(7));

            foreach (var item in treeFifth.PreOrder())
            {
                Console.WriteLine(item + " "); // 3 4 5 6
            }

            int BookCompare(Book x, Book y)
            {
                if (x.Cost > y.Cost)
                {
                    return -1;
                }

                if (x.Cost < y.Cost)
                {
                    return 1;
                }

                return 0;
            }

            BinarySearchTree<Book> treeSixth = new BinarySearchTree<Book>(Comparer<Book>.Create(BookCompare));

            treeSixth.Add(new Book(3));
            treeSixth.Add(new Book(4));
            treeSixth.Add(new Book(5));
            treeSixth.Add(new Book(7));

            foreach (var item in treeSixth.PreOrder())
            {
                Console.WriteLine(item + " "); // 3 4 5 7
            }

            int PointCompare(Point x, Point y)
            {
                if (x.X > y.X)
                {
                    return 1;
                }

                if (x.X < y.X)
                {
                    return -1;
                }

                return 0;
            }

            BinarySearchTree<Point> treeSeventh = new BinarySearchTree<Point>(
                new Point[] { new Point(3, 2), new Point(2, 3), new Point(4, 3) },
                PointCompare);

            foreach (var item in treeSeventh.PreOrder())
            {
                Console.WriteLine(item + " "); // X 3 4 2
            }

            Console.ReadKey();
        }
    }
}