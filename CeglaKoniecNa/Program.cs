using System;
using System.Diagnostics;
using System.Linq;

namespace CeglaKoniecNa
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tNo\t\t| Result");
            Console.WriteLine($"\tExercise 1\t| {SumIntsInString("5 62 ar 11")}");
            Console.WriteLine($"\tExercise 2\t| {Factorial(6)}");
            Console.WriteLine($"\tExercise 3\t| {ClosestToZero( new int[] { 5, 62, 11, 6, -2, 3, 6, 7, 8 } )}");
            Console.WriteLine();
            Console.WriteLine($"\tExercise 4\t| ");
            Dividers(100);
            Console.WriteLine();
            Console.WriteLine($"\tExercise 5\t| {FindOddElement(new int[] { 2,3,6,7,1,2,1,7,6,5,3 })}");

            Console.ReadKey();
        }

        private static void AddToTree(Node treeElem, int arg)
        {
            if (arg == treeElem.value)
            {
                treeElem.count++;
                return;
            }

            if(arg < treeElem.value)
            {
                if (treeElem.less == null)
                {
                    treeElem.less = new Node { value = arg, count = 1, parent = treeElem };
                }
                else
                {
                    AddToTree(treeElem.less, arg);
                }
            }
            else
            {
                if (treeElem.more == null)
                {
                    treeElem.more = new Node { value = arg, count = 1, parent = treeElem };
                }
                else
                {
                    AddToTree(treeElem.more, arg);
                }
            }
        }

        public static void Dividers(int v)
        {
            for (int i=1; i<=v; i++)
            {
                if (i % 15 == 0)
                {
                    Console.WriteLine($"\tNumber: {i}\t| Three");
                    continue;
                }
                if (i % 5 == 0)
                {
                    Console.WriteLine($"\tNumber: {i}\t| Two");
                    continue;
                }
                if (i % 3 == 0)
                {
                    Console.WriteLine($"\tNumber: {i}\t| One");
                    continue;
                }
                Console.WriteLine($"\tNumber: {i}\t|");

            }
        }

        public static int ClosestToZero(int[] array)
        {
            if (array.Length == 1) return array[0];

            var closestNegative = int.MinValue;
            var closestPossitive = int.MaxValue;

            for(int i = 0; i<array.Length; i++)
            {
                var arg = array[i];
                if (arg == 0) return 0;
                if (arg > 0 && arg < closestPossitive)
                    closestPossitive = arg;
                if (arg < 0 && arg > closestNegative)
                    closestNegative = arg;
            }

            if (Math.Abs(closestNegative) < closestPossitive)
                return closestNegative;

            return closestPossitive;
        }

        public static int Factorial(int n, int v=1)
        {
            if (n < 0) throw new ArgumentException("Factorial argument cannot be negative");
            if (n < 2) return v;
            return Factorial(n - 1, v * n);
        }

        public static int SumIntsInString(string v)
        {
            return v.Split(' ').Sum(x => { int i; int.TryParse(x, out i); return i; } );
        }
        public static int FindOddElement(int[] table)
        {
            var root = new Node
            {
                value = Convert.ToInt32(table.Average()),
            };

            for (int i = 0; i < table.Length; i++)
            {
                AddToTree(root, table[i]);
            }

            return ResovleTree(root) ?? throw new ArgumentException("There is no odd element in the table");

        }

        private static int? ResovleTree(Node elem)
        {
            if (elem.count % 2 == 1)
                return elem.value;

            if (elem.less != null)
            {
                var r = ResovleTree(elem.less);
                if (r != null)
                    return r;
            }

            if (elem.more != null)
            {
                var r = ResovleTree(elem.more);
                if (r != null)
                    return r;
            }

            return null;

        }

        [DebuggerDisplay("value = {value} count = {count}")]
        class Node
        {
            public int value;
            public int count;
            public Node less;
            public Node more;
            public Node parent;
            public bool IsLeaf => less == null && more == null;
        }
    }
}
