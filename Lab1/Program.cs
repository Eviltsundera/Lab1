using System;
using System.Numerics;

namespace Lab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            V2DataOnGrid OnGrid = new V2DataOnGrid("testing object", 32.9, new Grid1D((float)2.4, 7),
                                                                    new Grid1D((float)1.4, 5));
            
            OnGrid.InitRandom(1.0, 32.5);
            Console.Write(OnGrid.ToLongString());
            Console.Write("\n");

            V2DataCollection objCol = (V2DataCollection) OnGrid;
            Console.Write(objCol.ToLongString());
            Console.Write("\n");
            
            V2DataMainCollection MainCol = new V2DataMainCollection();
            MainCol.AddDefaults();
            Console.Write(MainCol.ToString());


            foreach (var item in MainCol) {
                Complex[] res = item.NearAverage((float) 0.1);
                foreach (var complex in res) {
                    Console.Write(complex.ToString());
                    Console.Write('\n');
                }
            }
        }
    }
}