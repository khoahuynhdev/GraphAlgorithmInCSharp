using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplement
{
    class EdgeListGraph
    {
        public int Vertexs { get; set; }
        public int Edges { get; set; }

        public List<int[]> EdgeList { get; set; }

        public EdgeListGraph()
        {

        }

        public bool ReadGraph(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read)))
                {
                    string[] tmp = sr.ReadToEnd().Split('\n');
                    Edges = int.Parse(tmp[0].Split(' ')[1]);
                    Vertexs = int.Parse(tmp[0].Split(' ')[0]);
                    EdgeList.Add(tmp[1].Split(' ').Select(x => int.Parse(x)).ToArray());
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
