using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestsProject")]

namespace TestTasks2024
{
    internal interface ISortingMethod
    {
        int Sort(int[] array);
    }

    /// <summary>
    /// Time complexity: O( ( n * (n - 1) ) / 2 )
    ///
    ///         n * (n - 1)
    ///   O (  ------------  )
    ///             2
    ///
    /// very poor
    /// </summary>
    internal class MyBubbleSortDesc : ISortingMethod
    {
        public int Sort(int[] array)
        {
            int iterCounter = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    }

                    iterCounter++;
                }
            }

            return iterCounter;
        }
    }

    /// <summary>
    /// OK for most cases,
    /// but Array.MaxLength = 2 147 483 591
    /// </summary>
    internal class MyAdequateSortDesc : ISortingMethod
    {
        public int Sort(int[] data)
        {
            Array.Sort(data);
            Array.Reverse(data);
            return 0;
        }
    }

    /// <summary>
    /// Write code that sorts given array of integer from MAX to MIN.
    /// </summary>
    internal class T1_Sorting
    {
        private readonly ISortingMethod _sortingMethod;
        public int[] Data => _data;
        public int IterCounter => _iter_conter;

        private int _max_value = 100;
        private int _iter_conter = 0;
        private int[] _data;
        private Random _random = new Random();

        public T1_Sorting(int[] array, ISortingMethod sortingMethod)
        {
            _data = array;
            _sortingMethod = sortingMethod;
        }

        public T1_Sorting(int arraySize, ISortingMethod sortingMethod, int maxValue = 100)
        {
            if (arraySize > Array.MaxLength)
                throw new InvalidOperationException("Sorry dude I can't create such a huge array");

            _sortingMethod = sortingMethod;
            _data = new int[arraySize];
            _max_value = maxValue;
            for (int i = 0; i < arraySize; i++)
            {
                _data[i] = _random.Next(_max_value);
            }
        }

        public void Sort()
        {
            _iter_conter = _sortingMethod.Sort(_data);
        }

        public override string ToString() => string.Join(" : ", _data);

        public string Info => $"L = {_data.Length}. Iters = {IterCounter}";
    }

    /// <summary>
    /// Found on internet
    /// </summary>
    internal class MyParallelSortDesc : ISortingMethod
    {
        public int Sort(int[] array)
        {
            ParallelSort(array);
            return 0;
        }

        private static void ParallelSort(int[] array)
        {
            int threshold = 10000; // Threshold for switching to sequential sort

            if (array.Length <= threshold)
            {
                Array.Sort(array);
                Array.Reverse(array);
            }
            else
            {
                int mid = array.Length / 2;
                int[] left = new int[mid];
                int[] right = new int[array.Length - mid];

                Array.Copy(array, 0, left, 0, mid);
                Array.Copy(array, mid, right, 0, array.Length - mid);

                Parallel.Invoke(
                    () => ParallelSort(left),
                    () => ParallelSort(right)
                );

                Merge(array, left, right);
            }
        }

        private static void Merge(int[] array, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    array[k++] = left[i++];
                }
                else
                {
                    array[k++] = right[j++];
                }
            }

            while (i < left.Length)
            {
                array[k++] = left[i++];
            }

            while (j < right.Length)
            {
                array[k++] = right[j++];
            }
        }
    }
}