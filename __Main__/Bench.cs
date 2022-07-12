namespace __Main__;

public class Bench
{
using System.Text;
using BenchmarkDotNet.Attributes;

namespace __Main__;

[MemoryDiagnoser]
public class Bench
{
    int _numberOfItems = 100000;
    
    [Benchmark]
    public void ConcatStringsUsingStringBuilder()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < _numberOfItems; i++)
        {
            sb.Append("Hello World!" + i);
        }
    }
    
    [Benchmark]
    public void ConcatStringsUsingGenericList()
    {
        var list = new List<string>(_numberOfItems);
        for (int i = 0; i < _numberOfItems; i++)
        {
            list.Add("Hello World!" + i);
        }
    }
}
}