using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Patterns
{
    public class SingleResponsibilityPrinciple
    {
        private static Journal _journal = new Journal();
        private static Persistence _persistence = new Persistence();
        public SingleResponsibilityPrinciple() 
        {
            DefaultMethod();
            BetterMethod();
        }

        public void DefaultMethod()
        {
            _journal.AddEntry("I cried today.");
            _journal.AddEntry("I ate a bug.");
            Console.WriteLine(_journal);
        }

        public void BetterMethod()
        {
            var filename = @"E:\system design\static files\journal.txt";
            _persistence.SaveToFile(_journal, filename);
            Process.Start(filename);
        }
    }

    public class Journal
    {
        private readonly List<string> _entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            _entries.Add($"{++count}: {text}");
            return count; //memento
        }

        public void RemoveEntry(int index)
        {
            _entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _entries);
        }

    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string fileName, bool overWrite = false)
        {
            if (overWrite || !File.Exists(fileName))
                File.WriteAllText(fileName, j.ToString());
        }
    }
}
