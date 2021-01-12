using System;

namespace DataStructures
{
    /// <summary>
    /// Big O notation = peformace description:  LookUp                  Insert                    Delete
    ///                                             ByIndex - o(n)           Begining/End o(1)     Begining o(1)
    ///                                             By Value - o(n)          Middle       o(n)     Middle/End o(n)
    /// </summary>             
    public class myList
    {
        private Node first;
        private Node last;
        public int count = 0;
        private class Node
        {
            public int value;
            public Node next;
            public Node(int item)
            {
                this.value = item;
            }
        }

        public void addLast(int item)
        {
            Node node = new Node(item);
            //check if list is empty if yes than head and tail point to new added value
            if (first == null)
                first = last = node;
            // if we already have something in the list than we should add new item after the last node
            else
            {
                last.next = node;

                // we should refernce our tail to point to new last item in the list
                last = node;
            }
        }
        public void addFirst(int item)
        {
            Node node = new Node(item);
            if (first == null)
                first = last = node;
            else
            {
                node.next = first;
                first = node;
            }
        }

        public void removeFirst()
        {
            if (first != null)
            { // [10 -> 20 -> 30]
                var second = first.next;
                first.next = null;
                // [10 20 -> 30]
                first = second;
                // [20 30]
            }
            // Scenario when we only have 1 item in the list
            if (first == last)
            {
                first = last = null;
                return;
            }
            else
            {
                System.Console.WriteLine($"There is no items in the list");
            }

        }

        public void RemoveLast()
        { 
            // So in order to remove the last item we need to make item which goes before it as the last one
            // [10 -> 20 -> 30]
            // previous -> 20 , this is done by using getPrevious method
            // last -> 20
            if (first==last)
            {
                first = last = null;
                return;
            }
            if(first!=null)
            {
              
                var previous = getPrevious(last);
                last = previous;
                last.next = null;
            }
        }
        private Node getPrevious(Node node)
        {
            var current = first;
            while (current != node)
            {
                if (current.next == node) break;
                current = current.next;
            }
            return null;
        }

        public int size()
        {
            if (first == null)
            {
                throw new ArgumentNullException();
            }
            if (first == last)
            {
                return 1;
            }
            int count = 0;
            var current = first;
            while (current != last)
            {
                current = current.next;
                count++;
            }
            var total = count + 1;
            return total;
        }
        public int[] toArray()
        {
            var array = new int[size()];
            var current = first;
            int index = 0;
            while (current!=null)
            {
              array[index++]= current.value;
              current = current.next;
              count++;
            }
            return array;
        }
        public void Reverse()
        {
            var newArray = toArray();
            for (int i = count-1; i >= 0; i--)           
                Console.WriteLine("Reversed array order {0}", newArray[i]);
                Console.ReadLine();

        }
        public int KthNode(int k)
        {
            if (k < 1 || k > size())
                throw new ArgumentOutOfRangeException();

            var firstPointer = NotArrayReverse();
            var secondPointer = first.next;
            int distance = k - 1;
            int index = 0;
            while (index!=distance)
            {
                secondPointer = secondPointer.next;
                index++;
            }
            firstPointer = secondPointer;
            while(secondPointer!=null)
            {
                secondPointer = secondPointer.next;
            }
            return firstPointer.value;

        }

        private Node NotArrayReverse()
        {
            // [10 -> 20 ->30] main idea is to get to the middle and reference previos node instead of next
            // but we also need to keep track of the next node. With each iteration we move our p c n and when c doesnt reference anything we stop
            //  p     c    n
            // n=c.next
            // c.next = p
            // [10 <- 20  30]

            var previous = first;
            var current = first.next;
           
            while(current !=null)
            {
                var n = current.next;
                current.next = previous;
                previous = current; // to move refernce 1 step forward
                current = n;// after line above and this we have [10 <- 20 <- 30]             [10 <- 20 <- 30]
                                                      //           p    c     n    ----->            p      c     n
            }
            // Since head and tails are still referencing first and last we need 
            // to point them to the new order
            last = first;
            last.next = null;
            first = previous;
            return first;
            
        }
        public bool Contains(int item)
        {
            if (first == null)
            {
                System.Console.WriteLine("The list is empty");
            }
            int index = 0;
            var current = first;
            while (current != null)
            {
                if (current.value == item)
                {
                    return true;
                }
                current = current.next;
                index++;
            }
            return false;
        }

        public int indexOf(int item)
        {
            if (first==null)
            {
                System.Console.WriteLine("The list is empty");
            }
            int index = 0;
            var current = first;
            while(current!=null)
            {
                if (current.value==item)
                {
                    return index;
                }
                current = current.next;
                index++;
            }
            return -1;
        }
    }
}
