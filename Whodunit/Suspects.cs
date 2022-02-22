using System;
using System.IO;
using System.Collections.Generic;

namespace CurseCase
{
    public class Suspects
    {
        private Tuple<string, int>[] data;
        public Tuple<string, int>[] Data
        {
            get => data;
            set => data = value;
        }

        // TODO
        public Suspects(GenTree tree, int size)
        {
            throw new NotImplementedException();
        }

        // TODO
        public void HeapSort()
        {
            throw new NotImplementedException();
        }

        // Utilitary method to print the array.
        public override string ToString()
        {
            return string.Join<Tuple<string, int>>(" | ", this.data);
        }
    }
}
