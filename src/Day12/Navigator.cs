using System.Linq;

namespace Day12
{
    public class Navigator
    {
        public Instruction[] Instructions { get; set; }

        public Navigator(string[] input)
        {
            Instructions = input.Select(Instruction.Parse).ToArray();
        }

        public int GetManhattanDistancePartOne()
        {
            var shipCoordinate = new Coordinate(0, 0);
            var facing = 'E';

            foreach (var instruction in Instructions)
            {
                if (instruction.Direction == 'L' || instruction.Direction == 'R')
                {
                    facing = instruction.UpdateFacing(facing);
                    continue;
                }

                var direction = instruction.Direction;
                if (instruction.Direction == 'F')
                {
                    direction = facing;
                }

                switch (direction)
                {
                    case 'E':
                        shipCoordinate.X += instruction.Steps;
                        break;
                    case 'W':
                        shipCoordinate.X -= instruction.Steps;
                        break;
                    case 'S':
                        shipCoordinate.Y += instruction.Steps;
                        break;
                    case 'N':
                        shipCoordinate.Y -= instruction.Steps;
                        break;
                }
            }

            return shipCoordinate.CalculateManhattanProduct();
        }

        public int GetManhattanDistancePartTwo()
        {
            var shipCoordinate = new Coordinate(0, 0);
            var wayPoint = new Coordinate(10, -1);
            
            foreach (var instruction in Instructions)
            {
                if (instruction.Direction == 'L' || instruction.Direction == 'R')
                {
                    wayPoint = instruction.UpdateWayPoint(wayPoint);
                    continue;
                }

                if (instruction.Direction == 'F')
                {
                    shipCoordinate.X += wayPoint.X * instruction.Steps;
                    shipCoordinate.Y += wayPoint.Y * instruction.Steps;
                    
                    continue;
                }

                switch (instruction.Direction)
                {
                    case 'E':
                        wayPoint.X += instruction.Steps;
                        break;
                    case 'W':
                        wayPoint.X -= instruction.Steps;
                        break;
                    case 'S':
                        wayPoint.Y += instruction.Steps;
                        break;
                    case 'N':
                        wayPoint.Y -= instruction.Steps;
                        break;
                }
            }

            return shipCoordinate.CalculateManhattanProduct();
        }
    }
}