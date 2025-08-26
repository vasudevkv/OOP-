using System;

namespace CounterTask
{
    internal class Program
    {
        private static void PrintCounters(Counter[] counters)
        {
            foreach (Counter c in counters)
            {
                Console.WriteLine("{0} is {1}", c.Name, c.Ticks);
            }
        }

        static void Main()
        {
            Counter[] myCounters = new Counter[3];

            myCounters[0] = new Counter("Counter 1");
            myCounters[1] = new Counter("Counter 2");
            myCounters[2] = myCounters[0]; 

            for (int i = 1; i <= 9; i++)
            {
                myCounters[0].Increment();
            }

            for (int i = 1; i <= 14; i++)
            {
                myCounters[1].Increment();
            }

            Console.WriteLine("Counter After incrementg: ");

            PrintCounters(myCounters);

            myCounters[2].Reset();

            Console.WriteLine("Counter After resetting: ");

            PrintCounters(myCounters);
        }
    }
}
