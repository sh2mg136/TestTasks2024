using System.Diagnostics;
using System.Text;
using TestTasks2024;

namespace TestsProject
{
    public class Task4Tests
    {
        private readonly Bogus.Faker _faker = new();

        [Fact]
        public void Test1()
        {
            var str = "hgBj_ACljklBooAC";
            T4_SubString ts = new T4_SubString(str);
            int res = ts.Find();
            Assert.Equal(2, res);
        }

        [Fact]
        public void Test2()
        {
            var str = "B__AC";
            T4_SubString ts = new T4_SubString(str);
            int res = ts.Find();
            Assert.Equal(1, res);
        }

        [Fact]
        public void Test3()
        {
            var str = "B__ACB__AC";
            T4_SubString ts = new T4_SubString(str);
            int res = ts.Find();
            Assert.Equal(2, res);
        }

        [Fact]
        public void Test43()
        {
            StringBuilder sb = new StringBuilder("B__AC______");
            sb.Append(_faker.Lorem.Text());
            sb.Append(_faker.Lorem.Lines(10));
            sb.Append("ooo_B__AC_ooo");
            sb.Append(_faker.Lorem.Paragraph());
            sb.Append(_faker.Lorem.Lines(10));
            sb.Append("ooo_B__AC_ooo");
            sb.Append(_faker.Lorem.Text());
            Enumerable.Range(0, 5).ToList().ForEach(x =>
            {
                sb.Append(_faker.Lorem.Text());
                sb.Append("__B__AC_");
                sb.Append(_faker.Lorem.Text());
            });
            sb.Append(_faker.Lorem.Text());
            sb.Append("ooo_B__AC_ooo");
            sb.Append(_faker.Lorem.Paragraph());
            sb.Append(_faker.Lorem.Lines(10));
            sb.Append("ooo_B..AC_ooo");
            sb.Append(_faker.Lorem.Text());
            sb.Append(_faker.Lorem.Paragraph());
            sb.Append("B..AC");
            var tmp = sb.ToString();
            var str = string.Concat(tmp, tmp, tmp, tmp, tmp, tmp, tmp, tmp, tmp, tmp, tmp, tmp, tmp, tmp, tmp, tmp, tmp, tmp, tmp, tmp);
            Debug.WriteLine(str.Length);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
            Debug.WriteLine(bytes.Length);
            T4_SubString ts = new(str);
            int res = ts.Find();
            Assert.True(res >= 220);
        }

        [Fact]
        public void Test_Null_Input_Should_Throw_ArgumentNullException()
        {
            string str = null;
            Exception? exception = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                (new T4_SubString(str)).Find();
            });

            try
            {
                (new T4_SubString(str)).Find();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.True(exception is not null && exception.GetType().Equals(typeof(ArgumentNullException)));
        }

        [Fact]
        public void Test_EmptyString_Should_Return_Zero0()
        {
            string str = _faker.Random.Bool() ? string.Empty : "     ";
            int res = (new T4_SubString(str)).Find();
            Assert.Equal(0, res);
        }
    }
}