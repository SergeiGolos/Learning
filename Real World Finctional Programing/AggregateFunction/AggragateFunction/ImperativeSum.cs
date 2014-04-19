using Xunit;

namespace AggregateFunction
{
    public class ImperativeSum
    {
        public static int Aggragate(int from, int to)
        {
            var sum = 0;
            while (from <= to)
            {
                sum += from++;
            }
            return sum;
        }


        [Fact]
        public void VerifyAggregate()
        {
            var result = ImperativeSum.Aggragate(1, 3);
            Assert.Equal(6, result);
        }
        
    }    
}