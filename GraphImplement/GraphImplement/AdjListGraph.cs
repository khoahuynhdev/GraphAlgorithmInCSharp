using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace GraphImplement
{
    public class AdjListGraph
    {
        public int Size { get; set; }

        public List<List<int>> Matrix { get; set; }

        public AdjListGraph()
        {

        }

        public bool ReadGraph(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read)))
                {
                    Size = int.Parse(sr.ReadLine());
                    Matrix = new List<List<int>>();
                    for (int i = 0; i < Size; i++)
                    {
                        Matrix.Add(sr.ReadLine().Split(' ').Select(c => int.Parse(c)).ToList());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public void PrintGraph()
        {
            foreach (var lst in Matrix)
            {
                foreach (var item in lst)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
        public int[] UndirectDeg()
        {
            return Matrix.Select(x => x.Count).ToArray();
        }
        public int[] DegreeOut()
        {
            int[] degs = Matrix.Select(x => x.Where(y => y != 0).Select(z => 1).Sum()).ToArray();
            return degs;
        }
        public int[] DegreeIn()
        {
            int[] arrIn = new int[Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    arrIn[i] += Matrix[j][i];
                }
            }
            return arrIn;
        }
        public bool WriteGraph(string path)
        {
            try
            {
                using (var sw = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                {
                    sw.WriteLine(Size);
                    int[] outArr = DegreeOut();
                    int[] inArr = DegreeIn();
                    for (int i = 0; i < Size; i++)
                    {
                        sw.WriteLine("{0} {1}", inArr[i], outArr[i]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

    }
}
