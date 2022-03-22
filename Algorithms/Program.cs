using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {

        #region String Algorithms
        static Boolean IsUpperCase(string s)
        {
            return s.All(char.IsUpper);
        }

        static Boolean IsLowerCase(string s)
        {
            return s.All(char.IsLower);
        }

        static Boolean IsPasswordComplex(string s)
        {
            return s.Any(char.IsUpper) && s.Any(char.IsLower) && s.Any(char.IsDigit);
        }

        static string NormalizeString(string input)
        {
            return input.ToLower().Trim().Replace(",", "");
        }

        static void ParseContents(string s)
        {
            Console.WriteLine("Option 1");

            foreach (char c in s)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine("Option 2");

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                Console.WriteLine(c);
            }
        }

        static Boolean IsAtEvenIndex(String s, char item)
        {
            if (String.IsNullOrEmpty(s))
            {
                return false;
            }

            for (int i = 0; i < s.Length / 2 + 1; i = i + 2)
            {
                if (s[i] == item)
                {
                    return true;
                }
            }

            return false;
        }

        static String Reverse1(String input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            StringBuilder reversed = new StringBuilder(input.Length);

            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed.Append(input[i]);
            }

            return reversed.ToString();
        }

        static String Reverse2(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            char[] arr = input.ToCharArray();
            Array.Reverse(arr);
            return new String(arr);
        }

        static String ReverseEachWord(string sentence)
        {
            if (string.IsNullOrEmpty(sentence))
            {
                return sentence;
            }

            string[] words = sentence.Split(" ");

            StringBuilder reversedSentence = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                if (i != 0)
                    reversedSentence.Append(" ");
                reversedSentence.Append(Reverse1(words[i]));
            }

            return reversedSentence.ToString();
        }

        #endregion

        #region Array Algorithms

        static Boolean LinearSearch(int[] input, int n)
        {
            foreach (int current in input)
            {
                if (current == n)
                    return true;
            }

            return false;
        }

        static Boolean BinarySearch(int[] inputArray, int item)
        {
            int min = 0;
            int max = inputArray.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (item == inputArray[mid])
                {
                    return true;
                }
                else if (item < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return false;
        }

        static int[] FindEvenNums(int[] arr1, int[] arr2)
        {
            ArrayList result = new ArrayList();

            foreach (int num in arr1)
            {
                if (num % 2 == 0)
                {
                    result.Add(num);
                }
            }

            foreach (int num in arr2)
            {
                if (num % 2 == 0)
                {
                    result.Add(num);
                }
            }

            return (int[])result.ToArray(typeof(int));
        }

        static int[] Reverse(int[] input)
        {
            int[] reversed = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                reversed[i] = input[input.Length - i - 1];
            }

            return reversed;
        }

        static void ReverseInPlace(int[] input)
        {
            for (int i = 0; i < input.Length / 2; i++)
            {
                int temp = input[i];
                input[i] = input[input.Length - i - 1];
                input[input.Length - i - 1] = temp;
            }
        }

        static void RotateToLeft(int[] input)
        {
            int first = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                input[i - 1] = input[i];
            }
            input[input.Length - 1] = first;
        }

        #endregion

        #region Queue and Stack Algorithms

        static void printBinary(int n)
        {
            if (n <= 0)
            {
                return;
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            for (int i = 0; i < n; i++)
            {
                int current = queue.Dequeue();
                Console.WriteLine(current);
                queue.Enqueue(current * 10);
                queue.Enqueue(current * 10 + 1);
            }

            Console.WriteLine();
        }

        static void printNextGreaterElement(int[] arr)
        {
            if (arr.Length == 0)
            {
                return;
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(arr[0]);
            int current = stack.Peek();

            for (int i = 1; i < arr.Length; i++)
            {
                while (arr[i] > current && stack.Count != 0)
                {
                    Console.WriteLine(stack.Pop() + " -> " + arr[i]);
                    if (stack.Count != 0)
                        current = stack.Peek();
                }
                stack.Push(arr[i]);
                stack.TryPeek(out current);
            }

            while (stack.Count != 0)
            {
                Console.WriteLine(stack.Pop() + " -> " + "-1");
            }
        }

        //Example
        /*int[] arr = new int[] { 15, 8, 4, 10 };

        printNextGreaterElement(arr);*/

        #endregion

        #region Hash-based algorithms

        static List<int> findMissingElements(int[] first, int[] second)
        {
            List<int> missingElements = new List<int>();
            HashSet<int> secondArrayItems = new HashSet<int>();

            foreach (int item in second)
            {
                secondArrayItems.Add(item);
            }

            foreach (int item in first)
            {
                if (!secondArrayItems.Contains(item))
                {
                    missingElements.Add(item);
                }
            }

            return missingElements;
        }

        // Example
        // findMissingElements(new int[] { 1, 2, 3, 4 }, new int[] { 2, 4 }).ForEach(Console.WriteLine);

        static void displayFreqOfEachElement(int[] arr)
        {
            Dictionary<int, int> freqDictionary = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (freqDictionary.ContainsKey(arr[i]))
                {
                    freqDictionary[arr[i]]++;
                }
                else
                {
                    freqDictionary[arr[i]] = 1;
                }
            }

            foreach (KeyValuePair<int, int> x in freqDictionary)
            {
                Console.WriteLine(x.Key + " : " + x.Value);
            }
        }

        // Example
        //displayFreqOfEachElement(new int[] { 3, 0, 2, 4, 7, 3, 4, 5, 7, 6, 7 });

        #endregion

        #region Tree Algorithms

        class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }

            public int Data { get; set; }
        }

        class BinarySearchTree
        {
            public static Node Insert(Node root, int value)
            {
                if (root == null)
                {
                    root = new Node();
                    root.Data = value;
                }
                else
                {
                    if (value < root.Data)
                    {
                        root.Left = Insert(root.Left, value);
                    }
                    else if (value > root.Data)
                    {
                        root.Right = Insert(root.Right, value);
                    }
                }

                return root;
            }

            public static Boolean isItemInTree(Node root, int item)
            {
                if (root == null)
                {
                    return false;
                }
                else if (item < root.Data)
                {
                    return isItemInTree(root.Left, item);
                }
                else if (item > root.Data)
                {
                    return isItemInTree(root.Right, item);
                } else
                {
                    return true;
                }
            }
        }

        // Example

        /*Node rootNode = new Node();
        rootNode.Data = 4;

        BinarySearchTree.Insert(rootNode, 2);
        BinarySearchTree.Insert(rootNode, 3);
        BinarySearchTree.Insert(rootNode, 5);
        BinarySearchTree.Insert(rootNode, 6);
        BinarySearchTree.Insert(rootNode, 4);*/

        class BinaryTree
        {
            public static void preOrderTraversal(Node root)
            {
                if (root == null)
                {
                    return;
                }

                Console.Write(root.Data + " ");
                preOrderTraversal(root.Left);
                preOrderTraversal(root.Right);
            }

            public static void inOrderTraversal(Node root)
            {
                if (root == null)
                {
                    return;
                }

                inOrderTraversal(root.Left);
                Console.Write(root.Data + " ");
                inOrderTraversal(root.Right);
            }

            public static void postOrderTraversal(Node root)
            {
                if (root == null)
                {
                    return;
                }

                postOrderTraversal(root.Left);
                postOrderTraversal(root.Right);
                Console.Write(root.Data + " ");
            }

            // Example

            //          4
            //      1       3
            //    8   9   6  
            /*Node rootNode = new Node();
            rootNode.Data = 4;

            Node nodeOne = new Node();
            nodeOne.Data = 1;

            Node nodeThree = new Node();
            nodeThree.Data = 3;

            Node nodeEight = new Node();
            nodeEight.Data = 8;

            Node nodeNine = new Node();
            nodeNine.Data = 9;

            Node nodeSix = new Node();
            nodeSix.Data = 6;

            rootNode.Left = nodeOne;
            rootNode.Right = nodeThree;
            nodeOne.Left = nodeEight;
            nodeOne.Right = nodeNine;
            nodeThree.Left = nodeSix;

            BinaryTree.preOrderTraversal(rootNode);
            Console.WriteLine();

            BinaryTree.inOrderTraversal(rootNode);
            Console.WriteLine();

            BinaryTree.postOrderTraversal(rootNode);*/

        }

        #endregion

        static void Main(string[] args)
        {
            Node rootNode = new Node();
            rootNode.Data = 4;

            BinarySearchTree.Insert(rootNode, 2);
            BinarySearchTree.Insert(rootNode, 3);
            BinarySearchTree.Insert(rootNode, 5);
            BinarySearchTree.Insert(rootNode, 6);
            BinarySearchTree.Insert(rootNode, 4);

            Console.WriteLine(BinarySearchTree.isItemInTree(rootNode, 6));
            Console.WriteLine(BinarySearchTree.isItemInTree(rootNode, 8));
        }
    }
}
