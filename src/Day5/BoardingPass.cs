using System;

namespace Day5
{
    public class BoardingPass
    {
        public int Row { get; set; }
        public int Seat { get; set; }
        public string Raw { get; set; }

        public int CalculateSeatId()
        {
            return Row * 8 + Seat;
        }

        public static BoardingPass Parse(string raw)
        {
            decimal rowStart = 0;
            decimal rowEnd = 127;
            decimal columnStart = 0;
            decimal columnEnd = 7;

            foreach (var direction in raw)
            {
                switch (direction)
                {
                    case 'F':
                    case 'B':
                    {
                        var rowDiff = (rowEnd - rowStart) / 2;
                        switch (direction)
                        {
                            case 'F':
                                rowEnd -= Math.Ceiling(rowDiff);
                                continue;
                            case 'B':
                                rowStart += Math.Ceiling(rowDiff);
                                continue;
                        }

                        break;
                    }
                    case 'R':
                    case 'L':
                    {
                        var columnDiff = (columnEnd - columnStart) / 2;
                        switch (direction)
                        {
                            case 'L':
                                columnEnd -= Math.Ceiling(columnDiff);
                                continue;
                            case 'R':
                                columnStart += Math.Ceiling(columnDiff);
                                continue;
                        }

                        break;
                    }
                }
            }

            return new BoardingPass {Row = (int) rowEnd, Seat = (int) columnEnd, Raw = raw};
        }
    }
}