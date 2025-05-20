using System;
using System.Collections.Generic;

namespace RecursiveExpressionTree
{
    abstract class ExprNode
    {
        public abstract double Evaluate();
    }

    class ValueNode : ExprNode
    {
        public double Value;
        public ValueNode(double value) => Value = value;
        public override double Evaluate() => Value;
    }

    class OperatorNode : ExprNode
    {
        public char Operator;
        public ExprNode Left, Right;

        public OperatorNode(char op, ExprNode left, ExprNode right)
        {
            Operator = op;
            Left = left;
            Right = right;
        }

        public override double Evaluate()
        {
            double l = Left.Evaluate();
            double r = Right.Evaluate();
            return Operator switch
            {
                '+' => l + r,
                '-' => l - r,
                '*' => l * r,
                '/' => l / r,
                _ => throw new Exception("Unknown operator")
            };
        }
    }

    class ExpressionParser
    {
        private Queue<char> tokens;

        public ExprNode Parse(string expr)
        {
            tokens = new Queue<char>(expr.Replace(" ", ""));
            return ParseExpression();
        }

        private ExprNode ParseExpression()
        {
            if (tokens.Peek() == '(')
            {
                tokens.Dequeue(); // remove '('
                ExprNode left = ParseExpression();
                char op = tokens.Dequeue(); // operator
                ExprNode right = ParseExpression();
                tokens.Dequeue(); // remove ')'
                return new OperatorNode(op, left, right);
            }
            else
            {
                string number = "";
                while (tokens.Count > 0 && char.IsDigit(tokens.Peek()))
                    number += tokens.Dequeue();
                return new ValueNode(double.Parse(number));
            }
        }
    }

    class Program
    {
        static void Main()
        {
            string expression = "((2+3)*(4-1))";
            var parser = new ExpressionParser();
            var tree = parser.Parse(expression);
            Console.WriteLine($"Expression: {expression}");
            Console.WriteLine($"Result: {tree.Evaluate()}");
        }
    }
}
