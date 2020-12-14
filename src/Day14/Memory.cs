namespace Day14
{
    public class Memory : Step
    {
        public string Binary { get; set; }
        public int Position { get; }

        public Memory(string binary, int position)
        {
            Binary = binary;
            Position = position;
        }
    }
}