using System;
using System.Collections;

namespace OwnList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Create the list.
            OwnList<int> ownList = new OwnList<int>();

            // Add elements.
            Console.WriteLine("Adding elements");

            ownList.Add(0);
            ownList.Add(1);
            ownList.Add(2);
            ownList.Add(3);
            ownList.Add(4);
            ownList.Add(5);
            ownList.Add(6);
            ownList.Add(7);
            ownList.Add(8);
            ownList.Add(9);

            // Here is resizing appears.
            ownList.Add(10);
            ownList.Add(11);
            ownList.Add(12);

            Console.WriteLine("List:");
            ownList.PrintList();

            Console.WriteLine("Elements count:");
            Console.WriteLine(ownList.Count);

            // Adding the range to list.
            Console.WriteLine("Adding range of elements ({ 1, 2, 3, 4, 5, 6 } array)");
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
            ownList.AddRange(arr);

            Console.WriteLine("List:");
            ownList.PrintList();

            Console.WriteLine("Elements count:");
            Console.WriteLine(ownList.Count);

            // Removing some elements.
            Console.WriteLine("Removing elements");

            ownList.Remove(6);
            ownList.Remove(3);
            ownList.PrintList();
            Console.WriteLine(ownList.Count);

            ownList.RemoveAt(0);
            ownList.RemoveAt(0);
            ownList.RemoveAt(0);

            Console.WriteLine("List:");
            ownList.PrintList();

            Console.WriteLine("Elements count:");
            Console.WriteLine(ownList.Count);

            // Sort the list.
            ownList.Sort();

            Console.WriteLine("List:");
            ownList.PrintList();

            // Foreach performance.
            Console.WriteLine("Foreach:");
            foreach (var item in ownList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            // Indexator work.
            Console.WriteLine("Indexator work");
            ownList[2] = 100;

            Console.WriteLine("List:");
            ownList.PrintList();

            // Iterator.
            Console.WriteLine("Iterator:");
            IEnumerator ie = ownList.GetEnumerator();
            while (ie.MoveNext())
            {
                Console.WriteLine(ie.Current);
            }

            ie.Reset();
            Console.WriteLine("\n\n\n\n\n");
            /////////////////////////////////////////////////////////////////// String list ///////////////////////////////////////////////////////////////////////////////////////
            // Create the list.
            OwnList<string> ownListStr = new OwnList<string>();

            // Add elements.
            Console.WriteLine("Adding elements");

            ownListStr.Add("0");
            ownListStr.Add("1");
            ownListStr.Add("2");
            ownListStr.Add("3");
            ownListStr.Add("4");
            ownListStr.Add("5");
            ownListStr.Add("6");
            ownListStr.Add("7");
            ownListStr.Add("8");
            ownListStr.Add("9");

            // Here is resizing appears.
            ownListStr.Add("10");
            ownListStr.Add("11");
            ownListStr.Add("12");

            Console.WriteLine("List:");
            ownListStr.PrintList();

            Console.WriteLine("Elements count:");
            Console.WriteLine(ownListStr.Count);

            // Adding the range to list.
            Console.WriteLine("Adding range of elements ({ 1, 2, 3, 4, 5, 6 } array)");
            string[] arr2 = new string[] { "1", "2", "3", "4", "5", "6" };
            ownListStr.AddRange(arr2);

            Console.WriteLine("List:");
            ownListStr.PrintList();

            Console.WriteLine("Elements count:");
            Console.WriteLine(ownListStr.Count);

            // Removing some elements.
            Console.WriteLine("Removing elements");

            ownListStr.Remove("6");
            ownListStr.Remove("3");
            ownListStr.PrintList();
            Console.WriteLine(ownListStr.Count);

            ownListStr.RemoveAt(0);
            ownListStr.RemoveAt(0);
            ownListStr.RemoveAt(0);

            Console.WriteLine("List:");
            ownListStr.PrintList();

            Console.WriteLine("Elements count:");
            Console.WriteLine(ownListStr.Count);

            // Sort the list.
            ownListStr.Sort();

            Console.WriteLine("List:");
            ownListStr.PrintList();

            // Foreach performance.
            Console.WriteLine("Foreach:");
            foreach (var item in ownListStr)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            // Indexator work.
            Console.WriteLine("Indexator work");
            ownListStr[2] = "100";

            Console.WriteLine("List:");
            ownListStr.PrintList();

            // Iterator.
            Console.WriteLine("Iterator:");
            IEnumerator ie2 = ownList.GetEnumerator();
            while (ie.MoveNext())
            {
                Console.WriteLine(ie.Current);
            }

            ie.Reset();
            Console.ReadLine();
        }
    }
}
