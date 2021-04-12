using System;
using System.Collections.Generic;
using System.Text;

namespace postfixCalculator {
    class Stack {

        private class Node {
            //field
            private object data;
            private Node next;

            //properties
            public object Data {
                get { return data; }
                set { data = value; }
            }//end property

            public Node Next {
                get { return next; }
                set { next = value; }
            }//end property

            //CONSTRUCTOR
            public Node(object newData = null) {
                data = newData;
            }//end construcor
        }
        //fields
        private Node _head = null;
        private int _count = 0;
        private Node _bottom = null;

        //property
        public int Count {
            get { return _count; }
            private set { _count = value; }
        }

        #region methods
        public void Push(object newData) {
            //put the new data in a node
            Node newNode = new Node(newData);
            //increase the count
            _count += 1;

            //if head is null make the new data the head
            if (_head == null) {
                _head = newNode;
                _bottom = newNode;
            //else it will push the old head and make the new data the head
            } else {
                _head.Next = newNode;
                _head = newNode;
            }
        }

        public object Pop() {
            Node newNode = _bottom;
            if (_head == _bottom) {
                _head = null;
                _bottom = null;
                return newNode.Data;
            } else if (_head != null) {
                while (newNode.Next != _head) {
                newNode = newNode.Next;
                }
                
                _head = newNode;
                newNode = newNode.Next;
                _head.Next = null;
                _count -= 1;
                return newNode.Data;
            } else {
                throw new Exception("head was null");
            }

        }

        public object Peek() {
            //if the head is not null return the data to the user
            if (_head != null) return _head.Data;
            //if head was null you throw a exception
            throw new Exception("head was null");
        }

        public void Clear() {
            //clear the entire stack
            _head = null;
            _bottom = null;
        }

        public override string ToString() {
            Node newNode = _bottom;
            string tempString = "";
            
            if (_head == _bottom) {
                tempString = _head.Data.ToString();
                tempString += " <--- Top";
                return tempString;
            } else if (_head != null) {
                while (newNode != _head) {
                    tempString += newNode.Data.ToString();
                    tempString += " ";
                    newNode = newNode.Next;
                }
                tempString += _head.Data.ToString();
                tempString += " <--- Top";
                return tempString;
            } else {
                throw new Exception("head was null");
            }
        }
        #endregion
    }
}
