using System;
using System.Collections.Generic;
using LocalMapReduce;

namespace WordCountCLI
{
    class Program
    {
        static void Main(string[] args)
        { 
            List<string> inputs = new List<string>
            {
                "How now brown cow",
                "The brainchid of how cow",
                "Apache now is not a cow"
            };

            var mapReduceJob = new Job<WordCountSplitter, WordCountMapper, WordCountReducer, List<string>, string, string, int, Tuple<string, int>>();

            var output = mapReduceJob.Run(inputs);

            foreach(var o in output)
            {
                Console.WriteLine($"{o.Item1}, {o.Item2}");
            }

            Console.Read();
        }
    }
}
