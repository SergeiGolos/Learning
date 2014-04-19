using System.Security.Policy;
using Xunit;

namespace AggregateFunction
{
    public class RecursiveAggregateSum
    {
        public static int Aggregate(int from, int to)
        {
            return from > to
                ? 0
                : Aggregate(from + 1, to) + from;
        }

        [Fact]
        public void VerifyAggregate()
        {
            var result = Aggregate(1, 3);
            Assert.Equal(6, result);
        }
        
    }
}