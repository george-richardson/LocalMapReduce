using LocalMapReduce;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCountCLI
{
    public class WordCountReducer : Reducer<string, int, Tuple<string, int>>
    {
        public override Tuple<string, int> Reduce(string key, List<int> inputs)
        {
            return new Tuple<string, int>(key, inputs.Sum());
        }
    }
}
