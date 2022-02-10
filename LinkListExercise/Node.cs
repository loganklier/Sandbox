using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sandbox.LinkListExercise
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> NextNode { get; set; }
    }
}
