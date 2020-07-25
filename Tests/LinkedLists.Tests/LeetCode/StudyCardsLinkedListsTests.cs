using DataStructures;
using LinkedLists.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LinkedLists.Tests.LeetCode
{
  public  class StudyCardsLinkedListsTests
    {
      readonly  StudyCardsLinkedList sut = null;

        public StudyCardsLinkedListsTests()
        {
            sut = new StudyCardsLinkedList();
        }

        [Fact]
        public void Test_MyLinkedList()
        {
            MyLinkedList linkedList = new MyLinkedList(); // Initialize empty LinkedList
            linkedList.AddAtHead(1);
            linkedList.AddAtTail(3);
            linkedList.AddAtIndex(1, 2);  // linked list becomes 1->2->3
          Assert.Equal(2,  linkedList.Get(1));            // returns 2
            linkedList.DeleteAtIndex(1);  // now the linked list is 1->3
           Assert.Equal(3, linkedList.Get(1));            // returns 3
        }

        //["MyLinkedList","addAtHead","deleteAtIndex","addAtHead","addAtHead","addAtHead","addAtHead","addAtHead","addAtTail","get","deleteAtIndex","deleteAtIndex"]
        //[[],[2],[1],[2],[7],[3],[2],[5],[5],[5],[6],[4]]
        [Fact]
        public void Test_MyLinkedList2()
        {
            MyLinkedList linkedList = new MyLinkedList(); // Initialize empty LinkedList
            linkedList.AddAtHead(2);
            linkedList.DeleteAtIndex(1);
            linkedList.AddAtHead(2);
            linkedList.AddAtHead(7);
            linkedList.AddAtHead(3);
            linkedList.AddAtHead(2);
            linkedList.AddAtHead(5);

            linkedList.AddAtTail(5);
            Assert.Equal(2, linkedList.Get(5));             
            linkedList.DeleteAtIndex(6);  
            linkedList.DeleteAtIndex(4);   
        }

        [Fact]
        public void Test_MyLinkedList1()
        {
            MyLinkedList linkedList = new MyLinkedList(); // Initialize empty LinkedList
            linkedList.AddAtHead(1);
            
            linkedList.DeleteAtIndex(0);  // now the linked list is 1->3
   
        }
        //["MyLinkedList","addAtHead","addAtHead","addAtHead","addAtIndex","deleteAtIndex","addAtHead","addAtTail","get","addAtHead","addAtIndex","addAtHead"]
        //[[],                  [7],     [2],          [1],     [3,0],          [2]          [6],         [4],      [4],     [4],        [5,0],       [6]]

        //[null,null,null,null,null,null,null,null,4,null,null,null]
        [Fact]
        public void Test_MyLinkedList3()
        {
            MyLinkedList linkedList = new MyLinkedList(); // Initialize empty LinkedList
            linkedList.AddAtHead(7);
             linkedList.AddAtHead(2);
            linkedList.AddAtHead(1);
             linkedList.AddAtIndex(3,0);
            linkedList.DeleteAtIndex(2);
            linkedList.AddAtHead(6);
            linkedList.AddAtTail(4);
            Assert.Equal(4, linkedList.Get(4));
            linkedList.AddAtHead(4);
            linkedList.AddAtIndex(5,0);
            linkedList.AddAtHead(6);
 
        }
    }
}
