﻿using CustomAttribute;
using JsonFileProvider;

namespace CustomProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var x = new FileProvider();
            var customManager = new CustomItemManager();

            CustomItem item = new();
            Console.WriteLine(item);

            customManager.ReadFromFile(item);
            Console.WriteLine(item);

            item.SecondItemProp = 2345;
            item.FifthItemProp = "set new string to json";
            item.SixthItemProp = 222222222;
            customManager.WriteToFile(item);

            CustomItem item2 = new();
            Console.WriteLine(item2);

            customManager.ReadFromFile(item);
            Console.WriteLine(item);
        }
    }
}
