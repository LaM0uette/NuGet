using System.Text.RegularExpressions;

namespace Flaggers;

public static class Flags
{
    // -a=test -b=1 -c test2 -d 2 -e=true -f false -g
    
    public static bool Bool(string mode, string name, string defaultValue, string description)
    {
        var args = string.Join(" ", Environment.GetCommandLineArgs());

        foreach (var arg in args)
        {
            var pattern = $"(?<=-{name}.)(?:true|false)";
            var options = RegexOptions.Multiline | RegexOptions.IgnoreCase;
        
            foreach (Match m in Regex.Matches(args, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }

        return true;
    }
}