using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Day17
{
    public struct D3Cube
    {
        public Vector3 Location { get; set; }
        public bool IsActive { get; set; }

        public D3Cube(bool isActive, float x, float y, float z = 0)
        {
            Location = new Vector3(x, y, z);
            IsActive = isActive;
        }

        public D3Cube(Vector3 vector)
        {
            Location = vector;
            IsActive = false;
        }

        public Vector3[] GetNeighbours()
        {
            var xOptions = new[] {Location.X - 1, Location.X + 1, Location.X};
            var yOptions = new[] {Location.Y - 1, Location.Y + 1, Location.Y};
            var zOptions = new[] {Location.Z - 1, Location.Z + 1, Location.Z};

            var neighbours = (
                from x in xOptions
                from y in yOptions
                from z in zOptions
                select new Vector3(x, y, z)).ToList();

            return neighbours.ToArray();
        }
    }
}