using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace DataStructures
{

    // Spell checkers, dictionaries
    // Complilers
    // Code editors

    //Set interface doesnt allow any repeating data structures to be stored in it.

    // Store Key Value pairs
    //                     0(1)
    //              Insert  LookUp  Delete
    public class HashTables 
    {
        private class Entry
        {
            public int Key { get; set; }
            public string Value { get; set; }
            public Entry(int k, string value)
            {
                this.Key = k;
                this.Value = value;
            }
        }
        private int Hash(int key)
        {
            return key % entries.Length;
        }

        private LinkedList<Entry>[] entries = new LinkedList<Entry>[5]; //array of linkedlists where each list holds 2 fields key and value
        public void Put(int k, string value)
        {
            var index = Hash(k);
            if (entries[index] == null)
                entries[index] = new LinkedList<Entry>();
            // if it is not empty it means we already have some data there so we need to put new one in the end of the list
            foreach (var element in entries[index])
            {
                if (element.Key == k) // if we are putting something with the same key just update the value stored there
                    element.Value = value;
                return;  // since we dont want our updated value to be added second time, it will happen if go forward in code
            }
            var entry = new Entry(k, value);
            entries[index].AddLast(entry);
        }

        public string get(int key)
        {
            var index = Hash(key);
            if (entries[index] != null)
            {
                foreach (var element in entries[index])
                {
                    if (element.Key == key)
                    {
                        return element.Value;
                    }
                }
            }
            return null;
        }
        public void remove(int key)
        {
            var index = Hash(key);
            var bucket = entries[index];
            if (bucket==null)
                throw new ArgumentNullException();
            foreach (var element in bucket)
            {
                if (element.Key==key)
                {
                    bucket.Remove(element);
                    return;
                }
            }
            throw new ArgumentOutOfRangeException();  // means there is no key like this
        }

        // We go through each characarter of the string if dicionary has it then we increase this keys value by 1
        // otherwise we add the value to the dictionary with value 1 
        public string findFirstNonrepeatingChar(string input)
        {
            
            Dictionary<string, int> MyBook = new Dictionary<string, int>();
            int count = 1;
            string result;

            for (int i = 0; i < input.Length; i++)
            {
                if (MyBook.ContainsKey(input[i].ToString()))
                {
                    MyBook[input[i].ToString()]++;
                }

                else
                {
                    MyBook.Add(input[i].ToString(), count);
                }
            }

            foreach (var pair in MyBook)
            {
                if (pair.Value == 1)
                {
                   return result = pair.Key;
                }  
            }
            return null; 
        }
        public string FirstRepeatedCharacter(string input)
        {
            Dictionary<string, int> MyBook = new Dictionary<string, int>();
            int count = 1;
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (MyBook.ContainsKey(input[i].ToString()))
                {
                    MyBook[input[i].ToString()]++;
                    result = input[i].ToString();
                }
                else
                {
                    MyBook.Add(input[i].ToString(), count);
                }
            }
            return result;
        }




        //Hash Functions - Function that gets a value and maps it to another value (key value to an index value)
        // Example we need store some number as key for each employee name we have in the company and we only have 100 employees
        //    myBook.Add(123456,"Leo") of cource its bad to create array that would fit this key value when we only have 100 employees
         // So instead, we use Hash algorthim which takes key value and does % on size of the array(100,since its number of employees we have)

        public static int HashFunction (int number)
        {
            return number % 100; // assuming 100 is the size of array
        }

        // if our key value is string type, we still can use hashFunctionbecause any chacter is saved as number since we are dealing with computer memory

        // GetHashCode function converts any datastructure to a hash code(used for cryptography)

        public static int HashFucntionString (string key)
        {
            int number=0;
            foreach (var ch in key.ToCharArray())
            {
                number += ch; // implicit casting from character to integer
            }
            return number % 100;
        }

        // Collision or accident is when our HashFunction generated 2 exactly same hash codes for 2 different objects
        //    In this case we have 2 solutions, first will be to use Chaining 
        // Chanining is when List is used to store objects so when collision happens we simply add the second hashcode at the end of the list
    }
    
}
