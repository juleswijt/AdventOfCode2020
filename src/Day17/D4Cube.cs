using System.Linq;
using System.Numerics;

namespace Day17
{
    public struct D4Cube
    {
        public Vector4 Location { get; set; }
        public bool IsActive { get; set; }

        public D4Cube(bool isActive, float x, float y)
        {
            Location = new Vector4(x, y, 0, 0);
            IsActive = isActive;
        }

        public D4Cube(Vector4 vector)
        {
            Location = vector;
            IsActive = false;
        }

        public Vector4[] GetNeighbours()
        {
            var xOptions = new[] {Location.X - 1, Location.X + 1, Location.X};
            var yOptions = new[] {Location.Y - 1, Location.Y + 1, Location.Y};
            var zOptions = new[] {Location.Z - 1, Location.Z + 1, Location.Z};
            var wOptions = new[] {Location.W - 1, Location.W + 1, Location.W};

            var neighbours = (
                from x in xOptions
                from y in yOptions
                from z in zOptions
                from w in wOptions
                select new Vector4(x, y, z, w)).ToList();

            return neighbours.ToArray();
        }
    }
}