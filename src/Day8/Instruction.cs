namespace Day8
{
    public struct Instruction
    {
        public string Action { get; set; }
        public int Amount { get; set; }

        public Instruction(string action, int amount)
        {
            Action = action;
            Amount = amount;
        }

        public static Instruction Parse(string raw)
        {
            var parsed = raw.Split(" ");

            return new Instruction(parsed[0], int.Parse(parsed[1].Replace("+", "")));
        }

        public static bool operator ==(Instruction i1, Instruction i2)
        {
            return i1.Equals(i2);
        }

        public static bool operator !=(Instruction i1, Instruction i2)
        {
            return !i1.Equals(i2);
        }
    }
}