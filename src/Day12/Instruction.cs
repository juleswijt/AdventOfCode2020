using System;
using System.Linq;

namespace Day12
{
    public struct Instruction
    {
        public char Direction { get; set; }
        public int Steps { get; set; }

        public static Instruction Parse(string raw)
        {
            return new Instruction()
            {
                Direction = raw[0],
                Steps = int.Parse(new string(raw.Skip(1).ToArray()))
            };
        }

        public char UpdateFacing(char facing)
        {
            switch (Direction)
            {
                case 'L':
                {
                    for (var rot = 0; rot < Steps / 90; rot++)
                    {
                        facing = facing switch
                        {
                            'E' => 'N',
                            'N' => 'W',
                            'W' => 'S',
                            'S' => 'E',
                            _ => 'E'
                        };
                    }

                    return facing;
                }
                case 'R':
                {
                    for (var rot = 0; rot < Steps / 90; rot++)
                    {
                        facing = facing switch
                        {
                            'E' => 'S',
                            'N' => 'E',
                            'W' => 'N',
                            'S' => 'W',
                            _ => 'E'
                        };
                    }

                    return facing;
                }
                default:
                    throw new Exception();
            }
        }

        public Coordinate UpdateWayPoint(Coordinate coordinate)
        {
            switch (Direction)
            {
                case 'L':
                {
                    for (var rot = 0; rot < Steps / 90; rot++)
                    {
                        coordinate = new Coordinate(coordinate.Y, coordinate.X * -1);
                    }

                    return coordinate;
                }
                case 'R':
                {
                    for (var rot = 0; rot < Steps / 90; rot++)
                    {
                        coordinate = new Coordinate(coordinate.Y * -1, coordinate.X);
                    }

                    return coordinate;
                }
                default:
                    throw new Exception();
            }
        }
    }
}