using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day18
{
    public class Expression
    {
        private static readonly Regex Regex =
            new Regex(@"[0-9]+|((([\*|\+]\s))?\((?:[^)(]+|\((?:[^)(]+|\([^)(]*\))*\))*\))|(([\+|\*])\s[0-9]+)");

        private static readonly Regex OuterParentheses = new Regex(@"([\+|\*]\s)?\((.+)\)");

        public char Operator { get; }
        public long Number { get; set; }
        public List<Expression> InnerExpressions { get; } = new List<Expression>();

        public Expression(char @operator = default)
        {
            Operator = @operator;
        }

        public Expression(long number, char @operator = default)
        {
            Operator = @operator;
            Number = number;
        }

        public long ProcessSum()
        {
            if (InnerExpressions.Count == 0)
            {
                return Number;
            }

            var value = 0L;
            foreach (var expression in InnerExpressions)
            {
                if (expression.Operator == default)
                {
                    value = expression.ProcessSum();
                    continue;
                }

                switch (expression.Operator)
                {
                    case '*':
                        value *= expression.ProcessSum();
                        continue;
                    case '+':
                        value += expression.ProcessSum();
                        break;
                }
            }

            return value;
        }

        public long ProcessAdvancedSum()
        {
            if (InnerExpressions.Count == 0)
            {
                return Number;
            }

            var expressions = new List<Expression>();
            var shifts = 1;
            for (var index = 0; index < InnerExpressions.Count; index++)
            {
                if (InnerExpressions[index].Operator == '+')
                {
                    expressions[index - shifts] =
                        new Expression(
                            InnerExpressions[index].ProcessAdvancedSum() +
                            expressions[index - shifts].ProcessAdvancedSum(),
                            expressions[index - shifts].Operator);
                    shifts++;
                    continue;
                }

                expressions.Add(InnerExpressions[index]);
            }

            var value = expressions.First(x => x.Operator == default).ProcessAdvancedSum();
            foreach (var expression in expressions.Skip(1))
            {
                value *= expression.ProcessAdvancedSum();
            }


            return value;
        }

        public static Expression Parse(string raw, char @operator = default)
        {
            var matches = Regex.Matches(raw);
            if (matches.Count == 1)
            {
                var match = matches.First().Value
                    .Split(" ")
                    .Select(x => x.Trim())
                    .ToArray();

                return match.Length == 1
                    ? new Expression(int.Parse(match[0]))
                    : new Expression(int.Parse(match[1]), match[0][0]);
            }

            var expression = new Expression(@operator);
            foreach (var match in matches)
            {
                var innerMatches = OuterParentheses.Matches(match.ToString()!);
                if (innerMatches.Count == 0)
                {
                    expression.InnerExpressions.Add(Parse(match.ToString()!));
                    continue;
                }

                var innerOperator = innerMatches[0].Groups[1].ToString();
                var innerValue = innerMatches[0].Groups[2].ToString();

                expression.InnerExpressions.Add(
                    Parse(innerValue, innerOperator.Length > 0 ? innerOperator[0] : default));
            }

            return expression;
        }
    }
}