using System;
using System.IO;
using System.Collections.Generic;

namespace CurseCase
{
    public class GenTree
    {
        private GenTree right;
        private GenTree left;
        private string name;
        private int suspicion;

        public GenTree Right => right;
        public GenTree Left => left;
        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Suspicion
        {
            get => suspicion;
            set => suspicion = value;
        }

        // TODO
        public GenTree(string name, int suspicion, GenTree left, GenTree right)
        {
            throw new NotImplementedException();
        }

        /**
         * \brief Takes the path of a .gen file and builds the GenTree from it
         */
        public GenTree(string path)
        {
            StreamReader reader = new StreamReader(path);

            string data = reader.ReadLine();
            string[] lines = data.Split('-');

            reader.Close();

            GenTree tree = Build(lines, 0);
            this.right = tree.right;
            this.left = tree.left;
            this.name = tree.name;
            this.suspicion = tree.suspicion;
        }

        private GenTree Build(string[] lines, int i)
        {
            if (i >= lines.Length)
                return null;

            string[] names = lines[i].Split(' ');
            string name = names[0];
            int suspicion = Int32.Parse(names[1]);

            return new GenTree(name, suspicion, Build(lines, 2 * i + 1), Build(lines, 2 * i + 2));
        }

        // TODO
        public void PrintTree()
        {
            throw new NotImplementedException();
        }

        // TODO
        public static bool ChangeName(GenTree root, string oldname, string newname)
        {
            throw new NotImplementedException();
        }

        // TODO
        public static bool FindPath(GenTree root, string name, List<string> path)
        {
            throw new NotImplementedException();
        }

        // TODO
        public static string LowestCommonDescendant(GenTree root, string PersonA, string PersonB)
        {
            throw new NotImplementedException();
        }

        // TODO
        public void ToDot()
        {
            throw new NotImplementedException();
        }
    }
}
