using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace Sandbox.LinkListExercise
{

    public struct Point
    {
        public static readonly Point Default = new Point { X = 0, Y = 0 };

        public int X { get; set; }
        public int Y { get; set; }
    }

    public class RealConsole : IConsole
    {
        public void WriteLine(string value)
        {
            foreach (var item in value)
            {
                Thread.Sleep(50);
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }

    public interface IConsole
    {
        public void WriteLine(string value);
    }

    public class Namable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Person : Namable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
    }

    public static class RunThing
    {
        public static Namable DoThing()
        {
            var foo = new Person
            {
                FirstName = "Matthew",
                LastName = "Puneky",
                SocialSecurityNumber = "333-33-3333"
            };

            var bar = new Namable
            {
                LastName = foo.LastName,
                FirstName = foo.FirstName
            };

            return bar;
        }
    }

    public class MyList<T>
    {
        private readonly IConsole _console;

        public MyList(
            IConsole console)
        {
            _console = console;
        }

        private readonly Head<T> _head = new Head<T>();

        public void Print()
        {
            var current = _head.NextNode;

            while (current != null)
            {
                _console.WriteLine(JsonConvert.SerializeObject(current.Data));
                current = current.NextNode;
            }
        }

        public string Stringify_All()
        {
            var current = _head.NextNode;

            var foo = string.Empty;

            while (current != null)
            {
                foo += JsonConvert.SerializeObject(current.Data);
                
                current = current.NextNode;
            }

            return foo;
        }

        public void Add(T obj)
        {
            var nodeToAdd = new Node<T>
            {
                Data = obj
            };

            if (_head.NextNode == null)
            {
                _head.NextNode = nodeToAdd;
                return;
            }

            var current = _head.NextNode;
             
            while (current.NextNode != null)
            {
                current = current.NextNode;
            }

            current.NextNode = nodeToAdd;
        }

        public int Length()
        {
            var current = _head.NextNode;

            var length = 0;

            while (current != null)
            {
                length++;
                current = current.NextNode;
            }

            return length;
        }

        public T FirstOrDefault(Func<T, bool> func)
        {
            var current = _head.NextNode;

            while (current != null && !func(current.Data))
            {
                current = current.NextNode;
            }

            if (current == null)
            {
                return default;
            }

            return current.Data;
        }

        public T FirstOrDefault()
        {
            var current = _head.NextNode;

            if (current == null)
            {
                return default;
            }

            return current.Data;
        }

        public void Delete(T data)
        {
            var nodeToDelete = _head.NextNode;

            if (nodeToDelete.Data == null)
            {
                return;
            }

            while (!nodeToDelete.Data.Equals(data))
            {
                nodeToDelete = nodeToDelete.NextNode;
            }

            var nodeToPointTo = nodeToDelete.NextNode;

            if (_head.NextNode.Data.Equals(nodeToDelete.Data))
            {
                _head.NextNode = nodeToDelete.NextNode;
                return;
            }

            var nodeToPointFrom = _head.NextNode;

            while (!nodeToPointFrom.NextNode.Data.Equals(nodeToDelete.Data))
            {
                nodeToPointFrom = nodeToPointFrom.NextNode;
            }

            nodeToPointFrom.NextNode = nodeToPointTo;
        }

        public MyList<T> Where(Func<T, bool> func)
        {
            var current = _head.NextNode;

            var myListToReturn = new MyList<T>(new RealConsole());

            if (current == null)
            {
                return null;
            }

            while (current != null)
            {
                if (func(current.Data))
                {
                    myListToReturn.Add(current.Data);
                }

                current = current.NextNode;
            }

            return myListToReturn;
        }

        public bool DoesIntersect<T>(MyList<T> a, MyList<T> b, out T foo)
        {
            var aLength = a.Length();

            var bLength = b.Length();

            for (var i = 0; i < aLength; i++)
            {
                
            }

            foo = default;
            return false;
        }
    }
}
