﻿using System.Threading.Tasks;
using Fluid.Values;

namespace Fluid.Ast.BinaryExpressions
{
    public class MultiplyBinaryExpression : BinaryExpression
    {
        public MultiplyBinaryExpression(Expression left, Expression right) : base(left, right)
        {
        }

        public override async Task<FluidValue> EvaluateAsync(TemplateContext context)
        {
            var leftValue = await Left.EvaluateAsync(context);
            var rightValue = await Right.EvaluateAsync(context);

            if (leftValue is NumberValue && rightValue is NumberValue)
            {
                return new NumberValue(leftValue.ToNumberValue() * rightValue.ToNumberValue());
            }

            return NilValue.Instance;
        }
    }
}
