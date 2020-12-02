namespace Day2
{
    public class PasswordCombination
    {
        public int First { get; set; }
        public int Second { get; set; }
        public char Character { get; set; }
        public string Password { get; set; }

        public PasswordCombination(string input)
        {
            var exploded = input.Split(" ");

            First = int.Parse(exploded[0].Split("-")[0]);
            Second = int.Parse(exploded[0].Split("-")[1]);

            Character = exploded[1][0];
            Password = exploded[2];
        }
    }
}