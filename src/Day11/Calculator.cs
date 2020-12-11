using System;
using System.Collections.Generic;
using System.Linq;

namespace Day11
{
    public class Calculator
    {
        public string[] SeatLayout { get; set; }

        public List<(int, int)> Directions { get; set; } = new List<(int, int)>
        {
            (-1, -1),
            (0, -1),
            (+1, -1),
            (+1, 0),
            (+1, +1),
            (0, +1),
            (-1, +1),
            (-1, 0)
        };

        public Calculator(string[] seatLayout)
        {
            SeatLayout = seatLayout;
        }

        public int CalculatePartOne()
        {
            var seatLayout = SeatLayout;

            var hasChanges = true;
            while (hasChanges)
            {
                hasChanges = HasNextRound(seatLayout, out var newSeatLayout);
                seatLayout = newSeatLayout.ToArray();
            }

            return seatLayout
                .Select(x => x.ToCharArray())
                .Sum(row => row.Count(x => x == '#'));
        }

        public int CalculatePartTwo()
        {
            var seatLayout = SeatLayout;

            var hasChanges = true;
            while (hasChanges)
            {
                hasChanges = HasNextRound(seatLayout, out var newSeatLayout, 5, true);
                seatLayout = newSeatLayout.ToArray();
            }

            return seatLayout
                .Select(x => x.ToCharArray())
                .Sum(row => row.Count(x => x == '#'));
        }

        private bool HasNextRound(string[] seatLayout, out List<string> newSeatLayout, int openSeats = 4,
            bool allEmptySeats = false)
        {
            newSeatLayout = new List<string>();

            var hasChanges = false;

            var rows = seatLayout.Select(x => x.ToCharArray()).ToArray();
            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var newSeatRow = new List<char>();

                var seats = rows[rowIndex];
                for (var seatIndex = 0; seatIndex < seats.Length; seatIndex++)
                {
                    if (seats[seatIndex] == '.')
                    {
                        newSeatRow.Add('.');
                        continue;
                    }

                    var adjacentSeats = 0;
                    foreach (var (directionX, directionY) in Directions)
                    {
                        var yAxis = rowIndex;
                        var xAxis = seatIndex;
                        while (true)
                        {
                            yAxis += directionY;
                            if (yAxis < 0 || yAxis >= rows.Length)
                            {
                                break;
                            }

                            xAxis += directionX;
                            if (xAxis < 0 || xAxis >= seats.Length)
                            {
                                break;
                            }

                            if (rows[yAxis][xAxis] == 'L')
                            {
                                break;
                            }
                            
                            if (rows[yAxis][xAxis] == '#')
                            {
                                adjacentSeats++;
                                break;
                            }

                            if (!allEmptySeats)
                            {
                                break;
                            }
                        }
                    }

                    if (adjacentSeats == 0)
                    {
                        if (seats[seatIndex] != '#')
                        {
                            hasChanges = true;
                        }

                        newSeatRow.Add('#');
                        continue;
                    }

                    if (adjacentSeats >= openSeats)
                    {
                        if (seats[seatIndex] != 'L')
                        {
                            hasChanges = true;
                        }

                        newSeatRow.Add('L');
                        continue;
                    }

                    newSeatRow.Add(seats[seatIndex]);
                }

                newSeatLayout.Add(new string(newSeatRow.ToArray()));
            }

            return hasChanges;
        }
    }
}