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
            this.data = new Tuple<string, int>[size];
            Queue thin = new Queue();
            thin.Enqueue(tree);
            int counter = 0;
            while (thin.Count != 0)
            {
                GenTree a = (GenTree) thin.Dequeue();
                if (a.Left != null) thin.Enqueue(a.Left);
                if (a.Right != null) thin.Enqueue(a.Right);
                this.data[counter] = Tuple.Create(a.Name, a.Suspicion);
                counter+=1;
            }
        }

        static void HeapSortConcrete(Tuple<string, int>[] myTuple, int dataLength, int i) {
            int val = i;
            int bigval = 2*i + 2;
            int smallerval = 2*i + 1;
            if (smallerval < dataLength && myTuple[smallerval].Item2 < myTuple[val].Item2) val = smallerval;
            if (bigval < dataLength && myTuple[bigval].Item2 < myTuple[val].Item2) val = bigval;
            if (val != i) 
            {
                Tuple<string, int> tupleToMove = myTuple[i];
                myTuple[i] = myTuple[val];
                myTuple[val] = tupleToMove;
                HeapSortConcrete(myTuple, dataLength, val);
            }
        }
        
        // TODO
        public void HeapSort()
        {
            var dataLength = this.data.Length;
            for (int i = dataLength / 2 - 1; i >= 0; i--)
            {
                HeapSortConcrete(this.data, dataLength, i);
            }
            for (int i = dataLength-1; i>=0; i--) 
            {
                Tuple<string, int> thefirst = this.data[0];
                this.data[0] = this.data[i];
                this.data[i] = thefirst;
                HeapSortConcrete(data, i, 0);
            }
        }

        // Utilitary method to print the array.
        public override string ToString()
        {
            return string.Join<Tuple<string, int>>(" | ", this.data);
        }
    }
}
