using System;
using System.Globalization;

namespace DataStructures
{

    /// <summary>
    /// Big O notation = peformace description:  LookUp                  Insert                    Delete
    ///                                             ByIndex - o(1)           Begining/End o(n)     Begining/Middle/End o(n)
    ///                                             By Value - o(n)          Middle       o(n)
    /// </summary>                
    public class Array
    {
        private int[] numbers { get; set; }
        private int count;
        private int max=0;
        public Array(int length)
        {
            numbers = new int[length];
        }
        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                System.Console.WriteLine(numbers[i]);
            }
            Console.ReadLine();
        }


        /// <summary>
        /// main Idea is that we want to start from the last item in the array and decrement up to the index
        /// While decreenting we want to make 4th memory location to have value of the 3rd
        /// Third to have value of the second and so on up to when we hit index memory location where we should add the value
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void InsertAt(int index,int value)
        {
            if (index >= count || index < 0)
                throw new ArithmeticException();

            for (int i = count; i > index; i--)
                numbers[i] = numbers[i - 1];
            numbers[index] = value;

        }
        /// <summary>
        /// main ideas is that we want to start from index up to the end of the array
        /// with each increment of the loop we want to make 4th memory location to hold value of the 5th
        /// 5th memory location should hold value of the 6th and so on
        /// we also need to delete last item from the array since its going to be copy of the previous memory location
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index >=count || index <0)
                throw new ArithmeticException();

                for (int i = index; i < count; i++)
                numbers[i] = numbers[i+1];
                count--;
        }

        public void Max()
        {
            for (int i = 0; i < count; i++)
            {
                if (numbers[i]>=max)
                {
                    max = numbers[i];
                }
            }
            Console.WriteLine("Max value in the array is {0}",max);
        }
        public void Reverse()
        {
            for (int i = count-1; i >= 0; i--)
                Console.WriteLine("Reversed array order {0}",numbers[i]);
            Console.ReadLine();
        }
        public int IndexOf(int value)
        {
            for (int i = 0; i < count; i++)
            {
                if (numbers[i] == value)
                    return i;         
            }
            return -1;
        }

        public void Insert(int input)
        {
            if (numbers.Length==count)
            {
               int[] newNumbers = new int[2 * count];
                for (int i = 0; i < count; i++)
                    numbers[i] = newNumbers[i];
                numbers = newNumbers;

            }
            numbers[count] = input;
            count++;
        }
    }
}
