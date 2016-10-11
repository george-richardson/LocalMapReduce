using System.Collections.Generic;

namespace LocalMapReduce
{
    public abstract class Splitter<Input, Output>
    {
        public abstract List<Output> Split(Input input);
    }
}
