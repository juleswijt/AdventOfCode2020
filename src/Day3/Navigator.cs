namespace Day3
{
    public class Navigator
    {
        public int CountTrees(int[][] values, int xCounter, int yCounter)
        {
            var xIndex = 0;
            var yIndex = 0;
            var trees = 0;

            while (yIndex + yCounter < values.Length)
            {
                yIndex += yCounter;
                xIndex += xCounter;
                
                var line = values[yIndex];

                if (xIndex >= line.Length)
                {
                    xIndex -= line.Length;
                }

                if (line[xIndex] == 1)
                {
                    trees++;
                }
            }

            return trees;
        }

        public long CountTreesForCombinations(int[][] values)
        {
            var combinations = new[] {new[] {1, 1}, new[] {3, 1}, new[] {5, 1}, new[] {7, 1}, new[] {1, 2}};

            long productOfTrees = 1;
            foreach (var combination in combinations)
            {
                productOfTrees *= CountTrees(values, combination[0], combination[1]);
            }

            return productOfTrees;
        }
    }
}