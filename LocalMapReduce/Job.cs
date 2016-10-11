using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMapReduce
{
    public class Job<Splitter, Mapper, Reducer, Input, MapInput, Key, Value, Output> 
        where Splitter : Splitter<Input, MapInput>, new()
        where Mapper : Mapper<MapInput, Key, Value>, new()
        where Reducer : Reducer<Key, Value, Output>, new()
    {

        public List<Output> Run(Input input)
        {  
            List<MapInput> split = new Splitter().Split(input);
            List<Task<Dictionary<Key, List<Value>>>> mapTasks = split.Select(min => new Task<Dictionary<Key, List<Value>>>(() => new Mapper().Run(min))).ToList();
            
            foreach(var mapTask in mapTasks)
            {
                mapTask.Start();
            }

            Task.WaitAll(mapTasks.ToArray());

            var mapResults = mapTasks.Select(t => t.Result).SelectMany(d => d.Select(kv => kv)).GroupBy(kv => kv.Key).ToDictionary(g => g.Key, g => g.SelectMany(a => a.Value));

            List<Task<Output>> reduceTasks = mapResults.Select(mr => new Task<Output>(() => new Reducer().Reduce(mr.Key, mr.Value.ToList()))).ToList();
            foreach(var reduceTask in reduceTasks)
            {
                reduceTask.Start();
            }

            Task.WaitAll(reduceTasks.ToArray());

            return reduceTasks.Select(rt => rt.Result).ToList();
        }
    }
}
