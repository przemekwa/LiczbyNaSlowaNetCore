using LiczbyNaSlowaNETCore;
using System.Threading;
using Xunit;

namespace LiczbyNaSlowaNetCoreTests
{
    public class ThreadSafetyTest
    {
        [Fact]
        public void IsNuberToTextThreadSafe()
        {
            bool failed = false;
            int iterations = 100;
            const string correctResponseThread1 = "jeden tysiąc dziewięćset dziewięćdziesiąt dziewięć";
            const string correctResponseThread2 = "piecdziesiat jeden tysiecy trzynascie zlotych piec groszy";
            // threads interact with some object - either 
            Thread thread1 = new Thread(new ThreadStart(delegate () {
                for (int i = 0; i < iterations; i++)
                {
                    var result = NumberToText.Convert(1999m, stems: true); // call unsafe code
                    // check that object is not out of synch due to other thread
                    if (!result.Equals(correctResponseThread1))
                    {
                        failed = true;
                    }
                }
            }));
            Thread thread2 = new Thread(new ThreadStart(delegate () {
                for (int i = 0; i < iterations; i++)
                {
                    var result = NumberToText.Convert(51013.05m, Currency.PLN); // call unsafe code
                    // check that object is not out of synch due to other thread
                    if (!result.Equals(correctResponseThread2))
                    {
                        failed = true;
                    }
                }
            }));

            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Assert.False(failed, "code was thread safe");
        }
    }
}
