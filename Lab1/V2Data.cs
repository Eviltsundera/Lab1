using System.Numerics;

namespace Lab1
{
    public abstract class V2Data
    {
        public string Info { get; set; }
        public double FieldFrequency { get; set; }

        public V2Data()
        {
            Info = "";
            FieldFrequency = 0;
        }

        public V2Data(string info, double freq)
        {
            Info = info;
            FieldFrequency = freq;
        }
        
        public abstract Complex[] NearAverage(float eps);
        public abstract string ToLongString();

        public override string ToString()
        {
            return $"{Info}\nField frequency is {FieldFrequency}";
        }
    }
}