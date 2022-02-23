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
            this.right = right;
            this.left = left;
            this.Name = name;
            this.Suspicion = suspicion;
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
            bool yessay = false;
            
            if (root.Name == oldname)
            {
                root.Name = newname;
                return true;
            }
            
            if (root.right != null && root.left != null)
            {
                if (ChangeName(root.right, oldname, newname)) yessay=true;
                if (ChangeName(root.left, oldname, newname)) yessay=true;
            }
            
            return yessay;
        }

        public static string FindParentName(GenTree myTree, string name)
        {
            List<string> treeNames = new List<string>();
            int namePosition = 0;
            Queue thicc = new Queue();
            thicc.Enqueue(myTree);
            while (thicc.Count != 0)
            {
                GenTree a = (GenTree) thicc.Dequeue();
                if (a.right!=null) thicc.Enqueue(a.right);
                if (a.left!=null) thicc.Enqueue(a.Left);
                treeNames.Add(a.Name);
                if (a.Name == name) namePosition = treeNames.Count/2;
            }
            return treeNames[namePosition-1];
        }

        // TODO
        public static bool FindPath(GenTree root, string name, List<string> path)
        {
            string parentName = name;
            while (parentName != root.Name)
            {
                bool exist = ChangeName(root, parentName, parentName);
                if (!exist) return false;
                parentName = FindParentName(root, parentName);
                path.Add(parentName);
            }
            path.Reverse();
            return true;
        }

        // TODO
        public static string LowestCommonDescendant(GenTree root, string PersonA, string PersonB)
        {
            List<string> DescendantA = new List<string>();
            List<string> DescendantB = new List<string>();
            FindPath(root, PersonA, DescendantA);
            FindPath(root, PersonB, DescendantB);
            DescendantA.Reverse();
            DescendantB.Reverse();
            string common = "";
            foreach (var valueA in DescendantA)
            {
                if (common!="") continue;
                foreach (var valueB in DescendantB)
                {
                    if (valueA == valueB) common = valueA;
                }
            }
            return common;  
        }

        private static void WriteToConsole(List<string> result)
        {
            foreach (var line in result)
            {
                Console.WriteLine(line);
            }
        }
        private List<string> GetLinesFromGentree(List<GenTree> treeNames)
        {
            List<string> result = new List<string>();

            result.Add("graph " + this.Name + " {");
            foreach (var name in treeNames)
            {
                if (name.left != null) result.Add(name.Name + " -- " + name.left.Name + ";");
                if (name.right != null) result.Add(name.Name + " -- " + name.right.Name + ";");
            }

            result.Add("}");
            return result;
        }
        private List<GenTree> GetTreeList()
        {
            List<GenTree> treeNames = new List<GenTree>();
            int namePosition = 0;
            Queue theThicc = new Queue();
            theThicc.Enqueue(this);
            while (theThicc.Count != 0)
            {
                GenTree a = (GenTree) theThicc.Dequeue();
                if (a.left != null) theThicc.Enqueue(a.Left);
                if (a.right != null) theThicc.Enqueue(a.right);
                treeNames.Add(a);
            }

            return treeNames;
        }
        private static void WriteToFile(List<string> result, string filename)
        {
            StreamWriter daStream = new StreamWriter(filename);
            foreach (var line in result)
            {
                daStream.WriteLine(line);
            }
            daStream.Close();
        }  
        // TODO
        public void ToDot()
        {
            var treeNames = GetTreeList();
            var result = GetLinesFromGentree(treeNames);
            WriteToConsole(result);
            WriteToFile(result,""+this.Name + ".dot");
            
        }
    }
}
