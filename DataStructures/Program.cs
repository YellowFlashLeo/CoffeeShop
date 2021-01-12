using System;

namespace DataStructures
{
    class Program
    {  
        static void Main(string[] args)
        {
            var check = new Stacks(4);
            string result = check.Reverser("Leo");
            Console.WriteLine($"{result}");
            //var table = new HashTables();
            //string input = "a green apple";
            //string result = table.findFirstNonrepeatingChar(input);
            //string result2 = table.FirstRepeatedCharacter(input);
            //Console.WriteLine(result);
            //Console.WriteLine(result2);
            //var tree = new BinaryTree();
            //tree.insert(10);
            //tree.insert(22);
            //tree.traversePreOrder();
        }
    }
}
