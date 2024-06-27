using System.Runtime.InteropServices;
using TestTasks2024;

namespace TestsProject
{
    public class Task1Tests
    {
        private readonly ISortingMethod _sortingMethod = new MyBubbleSortDesc();
        // private readonly ISortingMethod _sortingMethod = new MyAdequateSortDesc();

        private void Sorting(int array_size, int max_array_value)
        {
            TestTasks2024.T1_Sorting ts = new(array_size, _sortingMethod, max_array_value);
            int[] copy = new int[ts.Data.Length];
            ts.Data.CopyTo(copy, 0);
            Assert.NotNull(copy);
            Assert.Equal(copy.Length, ts.Data.Length);
            ts.Sort();
            Array.Sort(copy);
            Array.Reverse(copy);
            Assert.Equal(ts.Data, copy);
        }

        private void SortingEx(int array_size, int max_array_value)
        {
            TestTasks2024.T1_Sorting ts = new(array_size, _sortingMethod, max_array_value);
            ts.Sort();
            Assert.True(CheckIfArraySortedCorrectly(ts.Data));
        }

        private bool CheckIfArraySortedCorrectly(int[] arr)
        {
            if (arr == null) return false;
            var ok = true;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] < arr[i + 1])
                {
                    ok = false;
                    break;
                }
            }
            return ok;
        }

        [Fact]
        public void Test1() => Sorting(100, 100);

        [Fact]
        public void Test2() => Sorting(1000, 10000);

        [Fact]
        public void Test3() => SortingEx(10000, 1000000);

        [Fact]
        public void Test4()
        {
            TestTasks2024.T1_Sorting ts = new([1, 2, 3, 4, 5], _sortingMethod);
            ts.Sort();
            Assert.True(CheckIfArraySortedCorrectly(ts.Data));
        }

        [Fact]
        public void Test5()
        {
            TestTasks2024.T1_Sorting ts = new([5, 4, 3, 2, 1], _sortingMethod);
            ts.Sort();
            Assert.True(CheckIfArraySortedCorrectly(ts.Data));
        }

        [Fact]
        public void Test6()
        {
            TestTasks2024.T1_Sorting ts = new([1, 2, 3, 4, 5], _sortingMethod);
            ts.Sort();
            Assert.True(CheckIfArraySortedCorrectly(ts.Data));
        }

        [Fact]
        public void Test7()
        {
            TestTasks2024.T1_Sorting ts = new([5, 5, 8, 0, 7, 9, 1, 8, 12, 7, 5, 4, 6, 3, 2, int.MaxValue], _sortingMethod);
            ts.Sort();
            Assert.True(CheckIfArraySortedCorrectly(ts.Data));
            Assert.Equal(int.MaxValue, ts.Data[0]);
        }

        /// <summary>
        /// This can take a long long time.
        /// MaxArraySize = 2147483591 (Array.MaxLength)
        /// </summary>
        [Fact]
        public void Test8()
        {
            // SortingEx(Array.MaxLength, int.MaxValue);
        }

        [Fact]
        public void Test9()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                SortingEx(int.MaxValue, int.MaxValue);
            });
        }
    }
}