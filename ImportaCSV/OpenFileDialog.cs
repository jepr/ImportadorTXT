using System;

namespace ImportaCSV
{
    internal class OpenFileDialog
    {
        public string Filter { get; internal set; }
        public string Title { get; internal set; }

        internal object ShowDialog()
        {
            throw new NotImplementedException();
        }

        internal object OpenFile()
        {
            throw new NotImplementedException();
        }
    }
}