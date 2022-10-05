﻿namespace FileSystemSearch
{
    public static class FilterSetting
    {
        private static string FileType { get; set; }
        private static int NameLength { get; set; }
        private static int GetUserInput()
        {
            Console.WriteLine("Enter filtering parameter from 1 till 5, where: \n" +
                              "1 - File \n" +
                              "2 - Folder \n" +
                              "3 - File type \n" +
                              "4 - Creation date \n" +
                              "5 - Size");

            var input = Convert.ToInt32(Console.ReadLine());

            if (input == 3)
            {
                Console.WriteLine("Enter file type like: .txt");
                FileType = Console.ReadLine();
            }

            if (input == 5)
            {
                Console.WriteLine("Enter max name length:");
                NameLength = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine();

            return input;
        }

        public static Predicate<SearchedItem> GetFilter()
        {
            var userInput = GetUserInput();
            switch (userInput)
            {
                case 1: return x => !x.IsFolder;
                case 2: return x => x.IsFolder;
                case 3: return x => x.FileType == FileType;
                case 4: return x => x.Date < DateTime.Now;
                case 5: return x => x.NameLength < NameLength;
                default: return x => x.IsFolder || !x.IsFolder;
            }
        }
    }
}
