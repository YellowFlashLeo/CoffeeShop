using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class Stacks
    {
        /// Stack of books LIFO Last In First Out
        /// Usually used as wrapper around obejcts
        /// Can be used in programs to undo things
        /// Navigation is also based on Stack concept
        /// 
                                        // O(1) all operations thats why they are helpful
        ///push     (puts item on top of stack)     pop(removes item from the top)  peek(gets item on the top withot removing it)  isEmpty
        ///
        int count = 0;
        int[] values { get; set; }
        public Stacks(int length)
        {
            values = new int[length];
        }

        public void Push(int item)
        {
            if (values.Length == count)
                throw new StackOverflowException();
            values[count] = item;
            count++;
        }
        public int Pop()
        {
            if (count==0)
            {
                Console.WriteLine($"Sorry but there is nothing in the stack to be removed");
            }
            var result = values[count];
            values[count] = 0;
            count--;
            return result;
        }
        public int Peek()
        {
            if (count == 0)
                throw new ArgumentNullException();

            int result = values[count-1];
            return result;
        }
        public bool isEmpty()
        {
            if (values.Length==0)
            {
                return true;
            }
            return false;
        }

        public string Reverser (string input)
        {
            Stack stack = new Stack();
            string output = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
                output += stack.Pop();  // no need to Convert to String 
            }
            return output; 
        }


        public bool Balancer (string input)
        {
            // Opening bracket we need to push on the top of the stack
            // Regular symbol or number or letter should be ignored
            // Closing bracket, then we need to pop last item of the stack 
            // So that if stack is empty it means that expression is balanced or there were no brackets

            // then we add other type of brackets scenario
            
            if (input == null)
                throw new ArgumentNullException();

            Stack<char> stack = new Stack<char>();
            foreach (char ch in input.ToCharArray())
            {
                if (isLeftBracket(ch))
                {
                    stack.Push(ch);
                }
                if (isRightBracket(ch))
                {
                    if (stack.Count == 0) return false;
                    // top will get pushed bracket type 
                   var top= stack.Pop();

                    if (Compare(top, ch)) return false;
                }
            }
            if (stack.Count==0)
            {
                return true; // means that top gave opposite bracket of the same type
            }
            else
            {
                return false;
            }            
        }
        private bool isLeftBracket(char ch)
        {
            return ch == '(' || ch == '<' || ch == '[' || ch == '{'; // it returns true if any of the conditions are met
        }
        private bool isRightBracket(char ch)
        {
            return ch == ')' || ch == '>' || ch == '}' || ch == ']';
        }
        private bool  Compare (char left, char right)
        {
            return (right == ')' && left != '(') ||
                   (right == '}' && left != '{') ||
                   (right == ']' && left != '[') ||
                   (right == '>' && left != '<');
        }
    }
}
