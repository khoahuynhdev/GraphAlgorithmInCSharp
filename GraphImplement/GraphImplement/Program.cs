using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplement
{
    class Program
    {
        static void Main(string[] args)
        {
            //BT01();

            //BT023();

            BT04();
        }

        public static void BT01()
        {
            Graph gr = new Graph();
            Console.WriteLine(gr.ReadGraph("BACDOTHIVOHUONG.INP"));
            gr.PrintGraph();
            int[] arr = gr.Degree();
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            gr.WriteGraph("BACDOTHIVOHUONG.OUT");
            //Console.WriteLine(gr.CheckEdge(0, 2));
        }
        public static void BT023()
        {
            AdjListGraph adj = new AdjListGraph();
            Console.WriteLine(adj.ReadGraph("BACVAOBACRA.INP"));
            //adj.PrintGraph();
            int[] outArr = adj.DegreeOut();
            int[] inArr = adj.DegreeIn();
            for (int i = 0; i < adj.Size; i++)
            {
                Console.WriteLine("{0} {1}", inArr[i], outArr[i]);
            }
            adj.WriteGraph("BACVAOBACRA.OUT");
        }
        public static void BT04()
        {
            EdgeListGraph ed = new EdgeListGraph();
            ed.ReadGraph("DANHSACHCANH.INP");
        }
    }
}
