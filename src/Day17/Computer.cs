using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Day17
{
    public class Computer
    {
        public List<ThreeDimensionalCube> Cubes { get; set; } = new List<ThreeDimensionalCube>();

        public Computer(string input)
        {
            var rows = input.Split("\n");
            for (var yAxis = 0; yAxis < rows.Length; yAxis++)
            {
                for (var xAxis = 0; xAxis < rows[yAxis].Length; xAxis++)
                {
                    Cubes.Add(new ThreeDimensionalCube(rows[yAxis][xAxis] == '#', xAxis, yAxis));
                }
            }
        }

        public long CountNumberOfThreeDimensionalCubes()
        {
            for (var iteration = 0; iteration < 6; iteration++)
            {
                IterateCubes();
            }

            return Cubes.Count(x => x.IsActive);
        }

        private void IterateCubes()
        {
            var grid = new List<ThreeDimensionalCube>();
            foreach (var cube in Cubes)
            {
                var neighbours = cube.GetNeighbours();
                foreach (var neighbour in neighbours)
                {
                    if (grid.Any(x => x.Location == neighbour))
                    {
                        continue;
                    }

                    var current = Cubes.Any(c => c.Location == neighbour)
                        ? Cubes.FirstOrDefault(c => c.Location == neighbour)
                        : new ThreeDimensionalCube(neighbour);

                    var activeNeighbours = Cubes
                        .Count(c =>
                            current.GetNeighbours().Contains(c.Location)
                            && c.Location != current.Location
                            && c.IsActive
                        );
                    if (activeNeighbours == 3 || (current.IsActive && activeNeighbours == 2))
                    {
                        current.IsActive = true;
                    }
                    else
                    {
                        current.IsActive = false;
                    }

                    grid.Add(current);
                }
            }

            Cubes = grid;

            PrintCubeState();
        }

        private void PrintCubeState()
        {
            foreach (var zAxis in Cubes.GroupBy(x => x.Location.Z))
            {
                Console.WriteLine($"z={zAxis.Key}");
                foreach (var yAxis in zAxis.GroupBy(c => c.Location.Y))
                {
                    Console.WriteLine(yAxis.OrderBy(c => c.Location.X).Aggregate(string.Empty,
                                          (current, xAxis) => current + (xAxis.IsActive ? '#' : '.')) + " " +
                                      yAxis.Key);
                }

                Console.WriteLine("");
            }

            Console.WriteLine("-------");
        }
    }
}