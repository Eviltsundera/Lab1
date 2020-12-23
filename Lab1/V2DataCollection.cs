using System.Numerics;
using System;
using System.Collections.Generic;

namespace Lab1
{
    class V2DataCollection : V2Data
    {
        public List<DataItem> DataItems { get; set; }
        
        public V2DataCollection(string x, double y) : base(x, y) 
        {
            DataItems = new List<DataItem>();
        }

        public void InitRandom(int nItems, float xmax, float ymax, double minValue, double maxValue)
        {
            Random rnd = new Random();

            for (int i = 0; i < nItems; ++i)
            {
                float x = (float)rnd.NextDouble() * xmax;
                float y = (float)rnd.NextDouble() * ymax;
                Vector2 vec = new Vector2(x, y);
                
                Complex z = new Complex(rnd.NextDouble() * (maxValue - minValue) + minValue,
                    rnd.NextDouble() * (maxValue - minValue) + minValue);
                
                DataItems.Add(new DataItem(vec, z));
            }
        }

        public override Complex[] NearAverage(float eps)
        {
            double average = 0;
            for (int i = 0; i < DataItems.Count; ++i)
            {
                average += DataItems[i].Field.Real;
            }

            average /= DataItems.Count;

            int counter = 0;
            
            for (int i = 0; i < DataItems.Count; ++i)
            {
                if (Math.Abs(average - DataItems[i].Field.Real) < eps)
                {
                    ++counter;
                }
            }
            
            Complex[] answer = new Complex[counter];
            counter = 0;
            
            for (int i = 0; i < DataItems.Count; ++i)
            {
                if (Math.Abs(average - DataItems[i].Field.Real) < eps)
                {
                    answer[counter] = DataItems[i].Field;
                    ++counter;
                }
            }

            return answer;
        }

        public override string ToString()
        {
            return $"V2DataCollection\n" + base.ToString() + $"\nNumber of elements: {DataItems.Count}\n";
        }

        public override string ToLongString()
        {
            string answer = this.ToString();

            for (int i = 0; i < DataItems.Count; ++i)
            {
                answer += $"Point({DataItems[i].Coord.X}, {DataItems[i].Coord.Y}) Field = {DataItems[i].Field}\n";
            }

            return answer;
        }
    }
}