using System.Collections.Generic;

namespace LocalMapReduce
{
    public abstract class Mapper<Input, Key, Value>
    {
        public Mapper()
        {
            Output = new Dictionary<Key, List<Value>>();
        }

        private Dictionary<Key, List<Value>> Output { get; set; }

        protected abstract void Map(Input input);

        internal Dictionary<Key, List<Value>> Run(Input input)
        {
            Map(input);
            return Output;
        }

        protected void Emit(Key key, Value value)
        {
            if (!Output.ContainsKey(key))
            {
                Output.Add(key, new List<Value> { value });
            } else
            {
                Output[key].Add(value);
            }
        }
    }
}
