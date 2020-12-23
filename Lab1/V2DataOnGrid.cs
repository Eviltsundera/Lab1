using System.Numerics;
using System;

namespace Lab1
{
    class V2DataOnGrid : V2Data
    {
        public Grid1D[] Grid2D { get; set; }
        public Complex[,] FieldOnGrid { get; set; }

        
        public V2DataOnGrid(string info, double freq, Grid1D X, Grid1D Y) : base(info, freq)
        {
            Grid2D = new Grid1D[2];
            Grid2D[0] = X;
            Grid2D[1] = Y;

            FieldOnGrid = new Complex[Grid2D[0].Num, Grid2D[1].Num];
        }

        public void InitRandom(double minValue, double maxValue)
        {
            Random rnd = new Random();
            
            for (int i = 0; i < Grid2D[0].Num; ++i)
            {
                for (int j = 0; j < Grid2D[1].Num; j++)
                {
                    FieldOnGrid[i, j] = new Complex(rnd.NextDouble() * (maxValue - minValue) + minValue,
                        rnd.NextDouble() * (maxValue - minValue) + minValue);
                }
            }
        }

        public override Complex[] NearAverage(float eps)
        {
            double average = 0;
            for (int i = 0; i < Grid2D[0].Num; ++i)
            {
                for (int j = 0; j < Grid2D[1].Num; j++)
                {
                    average += FieldOnGrid[i, j].Real;
                }
            }

            average /= Grid2D[0].Num * Grid2D[1].Num;

            int counter = 0;
            
            for (int i = 0; i < Grid2D[0].Num; ++i)
            {
                for (int j = 0; j < Grid2D[1].Num; j++)
                {
                    if (Math.Abs(average - FieldOnGrid[i, j].Real) < eps)
                    {
                        ++counter;
                    }
                }
            }

            Complex[] answer = new Complex[counter];
            counter = 0;
            
            for (int i = 0; i < Grid2D[0].Num; ++i)
            {
                for (int j = 0; j < Grid2D[1].Num; j++)
                {
                    if (Math.Abs(average - FieldOnGrid[i, j].Real) < eps)
                    {
                        answer[counter] = FieldOnGrid[i, j];
                        ++counter;
                    }
                }
            }

            return answer;
        }

        public override string ToLongString()
        {
            string answer = this.ToString();

            for (int i = 0; i < Grid2D[0].Num; ++i)
            {
                for (int j = 0; j < Grid2D[1].Num; ++j)
                {
                    answer += $"Point({i * Grid2D[0].Step}, {j * Grid2D[1].Step}) Field = {FieldOnGrid[i, j]}\n";
                }
            }

            return answer;
        }

        public override string ToString()
        {
            return $"V2DataOnGrid\n" + base.ToString() + "\n" +$"OX GridData: Step = {Grid2D[0].Step}, Number of Nodes = {Grid2D[0].Num}\n" +
                   $"OY GridData: Step = {Grid2D[1].Step}, Number of Nodes = {Grid2D[1].Num}\n";
        }
        
        public static explicit operator V2DataCollection(V2DataOnGrid obj) {
            V2DataCollection res = new V2DataCollection(obj.Info, obj.FieldFrequency);

            for (int i = 0; i < obj.Grid2D[0].Num; i++) {
                for (int j = 0; j < obj.Grid2D[1].Num; j++) {
                    Vector2 vec = new Vector2((float)i * obj.Grid2D[0].Step, (float)j * obj.Grid2D[1].Step);
                    Complex field = obj.FieldOnGrid[i, j];
                    res.DataItems.Add(new DataItem(vec, field));
                }
            }

            return res;
        }
    }
}