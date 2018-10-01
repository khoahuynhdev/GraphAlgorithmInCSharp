using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplement
{
    class Graph
    {
        public int Size { get; set; }
        public int[][] Matrix { get; set; }        

        public Graph()
        {

        }
        public bool ReadGraph(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read)))
                {
                    Size = int.Parse(sr.ReadLine());
                    Matrix = new int[Size][];                    
                    for (int i = 0; i < Matrix.Length; i++)
                    {
                        Matrix[i] = sr.ReadLine().Split(' ').Select(c => int.Parse(c)).ToArray();
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
            foreach (var arr in Matrix)
            {
                foreach (var item in arr)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
        public int[] Degree()
        {
            int[] degs = Matrix.Select(x => x.Where(y => y != 0).Select(z => 1).Sum()).ToArray();
            return degs;
        }
        public bool WriteGraph(string path)
        {
            try
            {
                using (var sw = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                {
                    sw.WriteLine(Size);
                    foreach (var item in this.Degree())
                    {
                        sw.Write(item + " ");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }
        public bool CheckEdge(int a, int b) => Matrix == null ? false : Matrix[a][b] == 1;
    }
}
