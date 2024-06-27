using MathNet.Numerics;
using TestTasks2024;

namespace TestsProject
{
    public class Task3Tests
    {
        private readonly Bogus.Faker _faker = new();

        [Fact]
        public void Test1()
        {
            var data = new List<double>() { 1, 2, 3, 4, 5 };
            var stdev = T3_StandardDeviation.StandardDeviation(data);
            Assert.Equal(1.4142, stdev.Round(4));
        }

        [Fact]
        public void Test2()
        {
            var data = new List<double>() { 4, 20, 12, 13, 11, 29, 30, 14, 5 };
            var stdev = T3_StandardDeviation.StandardDeviation(data);
            Assert.Equal(8.7939, stdev.Round(4));
        }

        [Fact]
        public void Test3()
        {
            var data = new List<double>() { 10, 12, 23, 23, 16, 23, 21, 16 };
            var stdev = T3_StandardDeviation.StandardDeviation(data);
            Assert.Equal(4.898979, stdev.Round(6));
        }

        [Fact]
        public void Test4()
        {
            var data = new List<double>() { 1, 2, 3, 4, 5 };
            var stdev = T3_StandardDeviation.StandardDeviation(data);
            var ctrl = T3_StandardDeviation.StandardDeviation_Accord(data);
            Assert.Equal(ctrl.Round(4), stdev.Round(4));
            data.Clear();
            for (int i = 0; i < 100; i++)
            {
                data.Add(_faker.Random.Double(1, 100));
            }
            stdev = T3_StandardDeviation.StandardDeviation(data);
            ctrl = T3_StandardDeviation.StandardDeviation_Accord(data);
            Assert.Equal(ctrl.Round(4), stdev.Round(4));
        }
    }
}