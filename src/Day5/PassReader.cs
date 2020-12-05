using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    public class PassReader
    {
        public int[] ScanIds(string[] rawPasses)
        {
            return rawPasses
                .Select(BoardingPass.Parse)
                .Select(pass => pass.CalculateSeatId())
                .ToArray();
        }

        public int GetMySeat(string[] rawPasses)
        {
            var seatIds = ScanIds(rawPasses).OrderBy(x => x).ToArray();

            var previous = seatIds[0];
            foreach (var seatId in seatIds)
            {
                if (previous != seatId && previous != seatId - 1)
                {
                    return seatId - 1;
                }

                previous = seatId;
            }

            return 0;
        }
    }
}