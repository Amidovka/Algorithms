using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class CustomLinkedList
    {
        Node head;

        public class Node
        {
            public int data;

            public Node next;

            public Node(int d) { data = d; next = null; }
        }

        public void deleteBackHalf()
        {
            if (head == null || head.next == null)
            {
                head = null;
            }
            Node slow = head;
            Node fast = head;
            Node prev = null;

            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            prev.next = null;
        }

        public void deleteKthNodeFromEnd(int k)
        {
            if (head == null || head.next == null)
            {
                head = null;
            }

            int length = this.lengthOfList();
            Node nodeToDelete = head;
            Node prev = nodeToDelete;

            int i = 0;
            while (i != length - k && nodeToDelete != null)
            {
                prev = nodeToDelete;
                nodeToDelete = nodeToDelete.next;
                i++;
            }

            if (k == length)
            {
                head = head.next;
            } else if (k > length || k <= 0)
            {
                return;
            }

            prev.next = nodeToDelete.next;
        }

        public int lengthOfList()
        {
            Node current = head;
            int count = 0;

            while (current != null)
            {
                count++; 
                current = current.next;
            }

            return count;
        }

        public void displayContents()
        {
            Node current = head;

            while (current != null)
            {
                Console.Write(current.data + "->");
                current = current.next;
            }   
        }

        public Boolean hasCycle()
        {
            HashSet<Node> setOfNodes = new HashSet<Node>();

            Node current = head;

            while (current != null)
            {
                if (!setOfNodes.Contains(current))
                {
                    setOfNodes.Add(current);
                } else
                {
                    return true;
                }
                current = current.next;
            }

            return false;
        }

        /*static void Main(string[] args)
        {
            //CustomLinkedList linkedList = new CustomLinkedList();
            CustomLinkedList noCycleLinkedList = new CustomLinkedList();
            Node firstNode = new Node(3);
            Node secondNode = new Node(4);
            Node thirdNode = new Node(5);
            Node fourthNode = new Node(6);

            //linkedList.head = firstNode;
            noCycleLinkedList.head = firstNode;
            firstNode.next = secondNode;
            secondNode.next = thirdNode;
            thirdNode.next = fourthNode;

            Console.WriteLine(noCycleLinkedList.hasCycle());

            CustomLinkedList cycleLinkedList = new CustomLinkedList();
            cycleLinkedList.head = firstNode;
            *//*firstNode.next = secondNode;
            secondNode.next = thirdNode;*//*
            thirdNode.next = secondNode;

            Console.WriteLine(cycleLinkedList.hasCycle());
        }*/
    }
}
