using System;
using System.Collections;

namespace DataStructures
{// Main idea is that Que gets items so that [10,20,30,40] when deque is used we get [ 20,30,40]
    // Stacks are opposite [10,20,30,40] when pop is used [10,20,30]
    // Push = puts in the end of the array           // Enque = puts in the end of the array
    // Pop= removes from the end of the array        // deque = removes from the begining of the array
    // Thats why we need second stack , so if we pop items from first stack and push the to second [30,20,10]
    // So after we have 2 stack we can pop items from there and it will remove items from que in the correct order
    public class QueuWithTwoStacks
    {
        private Stack stack1 = new Stack();
        private Stack stack2 = new Stack();

        public void enque(int item)
        {
            stack1.Push(item);
        }
        public int deque()
        {
            if (stack1.Count == 0 && stack2.Count == 0)  // means the que is empty
                throw new ArgumentNullException();

            if (stack2.Count==0)  // we can only put values from 1 Stack to second if it is empty otherwise we mess the order of items inside
                while(stack1.Count!=0)
                    stack2.Push(stack1.Pop());
            int result = int.Parse((string)stack2.Pop());
            return result;
        }
    }
}
