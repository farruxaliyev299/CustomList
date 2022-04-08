using System;
using CustomList.Models;

namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(5);
            list.Add(100);
            list.Add(56);

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}


            list.Clear();
            list.Add(125);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }




        }
    }

}
