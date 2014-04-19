using System;
using System.Collections.Generic;
using Xunit;

namespace AggregateFunction
{
    public class RecursiveAggregateReuse
    {
        public static int Aggregate(int from, int to, Func<int, int, int> fn, int defaultValue)
        {
            return (from > to)
                ? defaultValue
                : fn(Aggregate(from + 1, to, fn, defaultValue), from);
        }

        [Fact]
        public void VerifyAggregateOfSums()
        {
            var result = Aggregate(1, 3, (i, i1) => i + i1, 0);
            Assert.Equal(6, result);
        }

        [Fact]
        public void VerifyAggregateOfMultiples()
        {
            var result = Aggregate(1, 3, (i, i1) => i*i1, 1);
            Assert.Equal(6, result);
        }
    }
}