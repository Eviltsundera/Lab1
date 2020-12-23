using System.Numerics;

namespace Lab1
{
    struct DataItem
    {
        public Vector2 Coord { get; set; }
        public Complex Field { get; set; }

        public DataItem(Vector2 point, Complex fld)
        {
            Coord = point;
            Field = fld;
        }

        public override string ToString()
        {
            return $"Point({Coord.X}, {Coord.Y}) Field: {Field}";
        }
    }
}