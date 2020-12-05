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
    }
}