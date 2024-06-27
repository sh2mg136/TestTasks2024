namespace TestTasks2024
{
    internal class T3_StandardDeviation
    {
        /// <summary>
        /// Standard Deviation
        ///
        /// https://www.calculator.net/standard-deviation-calculator.html
        ///
        /// 1: Find the mean (average).
        /// 2: Subtract the mean from each score.
        /// 3: Square each deviation.
        /// 4: Add the squared deviations.
        /// 5: Divide the sum by the number of scores.
        /// 6: Take the square root of the result from Step 5.
        ///
        ///                   N
        /// σ² =   (1 / N)    ∑   (x_i − μ)²
        ///                  i=1
        ///
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double StandardDeviation(List<double> data)
        {
            if (data == null || data.Count == 0)
                throw new ArgumentException(nameof(data));

            double avg = data.Average();
            double sum = data.Select(val => (val - avg) * (val - avg)).Sum();
            double mid = sum / data.Count;
            double stdev = Math.Sqrt(mid);

            return stdev;
        }

        public static double StandardDeviation_Accord(List<double> data)
        {
            return Accord.Statistics.Measures.StandardDeviation(data.ToArray(), false);
        }

        public static double StandardDeviation_MathNet(List<double> data)
        {
            return MathNet.Numerics.Statistics.Statistics.StandardDeviation(data.ToArray());
        }
    }
}