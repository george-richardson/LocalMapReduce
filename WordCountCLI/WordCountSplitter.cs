using LocalMapReduce;
using System.Collections.Generic;

namespace WordCountCLI
{
    class WordCountSplitter : Splitter<List<string>, string>
    {
        public override List<string> Split(List<string> input)
        {
            return input;
        }
    }
}
