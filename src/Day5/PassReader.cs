using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    public class PassReader
    {
        public int[] Scan(string[] rawPasses)
        {
            var boardingPasses = new List<BoardingPass>();
            foreach (var rawPass in rawPasses)
            {
                decimal rowStart = 0;
                decimal rowEnd = 127;
                decimal columnStart = 0;
                decimal columnEnd = 7;
                foreach (var direction in rawPass)
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

                boardingPasses.Add(new BoardingPass {Row = (int) rowEnd, Seat = (int) columnEnd, Raw = rawPass});
            }

            return boardingPasses.Select(pass => pass.CalculateSeatId()).ToArray();
        }

        public int GetMySeat(string[] rawPasses)
        {
            var seatIds = Scan(rawPasses);
            var ids = seatIds
                .Where(seatId => !seatIds.Contains(seatId + 1) || !seatIds.Contains(seatId - 1))
                .ToArray();
            
            foreach (var id in ids)
            {
                if (ids.Contains(id + 2))
                {
                    return id + 1;
                }

                if (ids.Contains(id - 2))
                {
                    return id - 1;
                }
            }

            return 0;
        }
    }
}