using LocalMapReduce;

namespace WordCountCLI
{
    class WordCountMapper : Mapper<string, string, int>
    {
        protected override void Map(string input)
        {
            foreach(var word in input.Split())
            {
                Emit(word, 1);
            }
        }
    }
}
