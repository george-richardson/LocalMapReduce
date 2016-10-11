using System.Collections.Generic;

namespace LocalMapReduce
{
    public abstract class Reducer<Key, Input, Output>
    {
        public abstract Output Reduce(Key key, List<Input> inputs);
    }
}
