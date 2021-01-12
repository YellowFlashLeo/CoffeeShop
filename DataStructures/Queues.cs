using System;
using System.Collections;

namespace DataStructures
{
    //First In First Out (FIFO)

    // Printers use this concept
    //Operating systems
    // Web services wait in ques to be executed

    //                                    O(1) all operations thats why they are helpful
    ///enqueue (puts item at the back of the que)     dequeue(removes item from the front)  peek(gets item at the front withot removing it)  isEmpty   isFull
    ///
    public class Queues
    {
        int[] values { get; set; }
        int count = 0;
        private int rear;
        private int front;

        public Queues(int _length)
        {
            values=new int[_length];
        }
        public bool isEmpty()
        {
            if (values.Length == 0) return true;
            else
            {
                return false;

            }
        }
        public bool isFull()
        {
            if (values.Length == count) return true;
            return false;
        }

        public int Peek()
        {     
            return front;
        }
        /// <summary>
        /// Circular array concept
        /// If we have size of the array as 5 [0->4]
        /// [0,0,30,40,50]
        ///             R, so if we decide to add another item then R goes ro the right and we get error
        ///  So the solution is to make R point to the begining.
        ///  5 -> 0    Left number % Length or (rear +1) % Length
        ///  6 -> 1
        ///  7 -> 2
        ///  8 -> 3 
        ///  9 -> 4
        ///  
        /// 10 -> 0
        /// 11 -> 1
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(int item)
        {
            if (values.Length==count)
                throw new ArgumentOutOfRangeException();           
            values[rear] = item;
            rear = (rear + 1) % values.Length;
            count++;
        }
        public int Dequeue()
        {
            if(values.Length==0)
                Console.WriteLine($"There is nothing to remove");
            //[10,20,30]
            var result = values[front]; //10
            // [0,20,30]
            values[front] = 0;
            front = (front + 1) % values.Length;
            count--;
              
            return result;
        }
        public static void Reverser(Queue queue)
        {
            // idea is  [10,20,30]
            // we remvove items 1 by 1 from que and put them in the stack
            // then from the stack back to the que since when we remove from stack we take from the end (reversed already)
            Stack supportStack = new Stack();
            //[10,20,30]
            while (queue.Count != 0)
                supportStack.Push(queue.Dequeue());
            // stack [30,20,10]
            while (supportStack.Count != 0)
            {
                queue.Enqueue(supportStack.Pop());
            }
            // que [30,20,10] = REVERSED
            var result = queue.ToArray();
            foreach (var element in result)
            {
                Console.WriteLine($"{element.ToString()}");
            }

        }
    }
}
