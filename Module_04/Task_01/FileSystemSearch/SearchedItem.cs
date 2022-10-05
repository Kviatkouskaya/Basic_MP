﻿namespace FileSystemSearch
{
    public class SearchedItem
    {
        public string Name { get; set; }
        public bool IsFolder { get; set; }
        public int NameLength { get; set; }
        public string FileType { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            var type = IsFolder ? "folder" : "file";
            return $"{Name}     {type}      {NameLength}    {Date}";
        }
    }
}
