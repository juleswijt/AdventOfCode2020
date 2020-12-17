using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Day17
{
    public class Computer
    {
        public List<D3Cube> D3Cubes { get; set; } = new List<D3Cube>();
        public List<D4Cube> D4Cubes { get; set; } = new List<D4Cube>();

        public Computer(string input)
        {
            var rows = input.Split("\n");
            for (var yAxis = 0; yAxis < rows.Length; yAxis++)
            {
                for (var xAxis = 0; xAxis < rows[yAxis].Length; xAxis++)
                {
                    D3Cubes.Add(new D3Cube(rows[yAxis][xAxis] == '#', xAxis, yAxis));
                    D4Cubes.Add(new D4Cube(rows[yAxis][xAxis] == '#', xAxis, yAxis));
                }
            }
        }

        public long CountNumberOfD3Cubes()
        {
            for (var iteration = 0; iteration < 6; iteration++)
            {
                IterateCubes();
            }

            return D3Cubes.Count(x => x.IsActive);
        }

        public long CountNumberOfD4Cubes()
        {
            for (var iteration = 0; iteration < 2; iteration++)
            {
                IterateD4Cubes();
            }

            return D4Cubes.Count(x => x.IsActive);
        }

        private void IterateCubes()
        {
            var grid = new List<D3Cube>();
            foreach (var neighbour in D3Cubes
                .Where(c => c.IsActive)
                .Select(cube => cube.GetNeighbours())
                .SelectMany(neighbours => neighbours))
            {
                if (grid.Any(x => x.Location == neighbour))
                {
                    continue;
                }

                var current = D3Cubes.Any(c => c.Location == neighbour)
                    ? D3Cubes.FirstOrDefault(c => c.Location == neighbour)
                    : new D3Cube(neighbour);

                var activeNeighbours = D3Cubes
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

            D3Cubes = grid;
        }

        private void IterateD4Cubes()
        {
            var grid = new List<D4Cube>();
            foreach (var neighbour in D4Cubes
                .Where(c => c.IsActive)
                .Select(cube => cube.GetNeighbours())
                .SelectMany(neighbours => neighbours))
            {
                if (grid.Any(x => x.Location == neighbour))
                {
                    continue;
                }

                var current = D4Cubes.Any(c => c.Location == neighbour)
                    ? D4Cubes.FirstOrDefault(c => c.Location == neighbour)
                    : new D4Cube(neighbour);

                var activeNeighbours = D4Cubes
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

            D4Cubes = grid;
            PrintD4CubeState();
        }

        private void PrintCubeState()
        {
            foreach (var zAxis in D3Cubes.GroupBy(x => x.Location.Z))
            {
                Console.WriteLine($"z={zAxis.Key}");
                foreach (var yAxis in zAxis
                    .OrderBy(c => c.Location.Y)
                    .GroupBy(c => c.Location.Y))
                {
                    Console.WriteLine(yAxis.OrderBy(c => c.Location.X).Aggregate(string.Empty,
                                          (current, xAxis) => current + (xAxis.IsActive ? '#' : '.')) + " " +
                                      yAxis.Key);
                }

                Console.WriteLine("");
            }

            Console.WriteLine("-------");
        }

        private void PrintD4CubeState()
        {
            foreach (var state in D4Cubes.GroupBy(x => new {x.Location.W, x.Location.Z}))
            {
                Console.WriteLine($"w={state.Key.W}" + $"z={state.Key.Z}");
                {
                    Console.WriteLine();
                    foreach (var yAxis in state.OrderBy(c => c.Location.Y).GroupBy(c => c.Location.Y))
                    {
                        Console.WriteLine(yAxis.OrderBy(c => c.Location.X).Aggregate(string.Empty,
                                              (current, xAxis) => current + (xAxis.IsActive ? '#' : '.')) + " " +
                                          yAxis.Key);
                    }

                    Console.WriteLine("");
                }
            }

            Console.WriteLine("-------");
        }
    }
}