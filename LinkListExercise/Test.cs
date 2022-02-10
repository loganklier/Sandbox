using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace Sandbox.LinkListExercise
{
    public class Test
    {
        public static void Main(string[] args)
        {
            int x = 1;

            string y = "butt";

            var productToAdd = new ProductDto
            {
                Id = 1,
                Name = "foo",
            };

            var productToAdd2 = new ProductDto
            {
                Id = x,
                Name = y,
            };

            var productToAdd3 = new ProductDto
            {
                Id = x,
                Name = y,
            };

            var myList = new List<ProductDto> { productToAdd, productToAdd2 };

            var myList2 = new List<ProductDto> { productToAdd3 };

            myList[1] = myList2[1];

            if(myList.Intersects(myList2, out var foo))
            {
                Console.WriteLine("Does intersect at " + JsonConvert.SerializeObject(foo));
            }
            else
            {
                Console.WriteLine("Does not intersect");
            }
        }

       
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public static class Extensions
    {

        public static bool Intersects<T>(this List<T> a, List<T> b, out T foo)
        {
            for (var i = 0; i < a.Count && i < b.Count; i++)
            {
                if (a.Contains(b.ElementAt(i)))
                {
                    foo = b.ElementAt(i);
                    return true;
                }
                if (b.Contains(a.ElementAt(i)))
                {
                    foo = a.ElementAt(i);
                    return true;
                }
            }

            foo = default;
            return false;
        }
         
        public static bool IsPalindrome<T>(this List<T> list)
        {
            var length = list.Count;

            if (length % 2 == 0)
            {
                for (var i = 0; i < length / 2; i++)
                {
                    if (!CheckSimilarity(list, i, length)) return false;
                }
            }
            else
            {
                for (var i = 0; i < (length - 1) / 2; i++)
                {
                    if (!CheckSimilarity(list, i, length)) return false;
                }
            }

            return true;
        }

        private static bool CheckSimilarity<T>(List<T> list, int i, int length)
        {
            var forwardItem = list.ElementAt(i);

            var backwardItem = list.ElementAt(length - 1 - i);

            return forwardItem.Equals(backwardItem);
        }
    }
}
