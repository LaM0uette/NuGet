using System.Text.RegularExpressions;

namespace Flaggers;

public static class Flags
{
    // -a=test -b=1 -c test2 -d 2 -e=true -f false -g
    private static string _args = string.Join(" ", Environment.GetCommandLineArgs());
    
    public static bool Bool(string mode, string name, bool value, string description)
    {
        var pattern = $"(?<=-{name}.)(?:true|false)";
        var options = RegexOptions.IgnoreCase;
        
        foreach (Match m in Regex.Matches(_args, pattern, options))
        {
            Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
        }

        return true;
    }

    public static bool Bool(string name, bool value, string description) =>
        Bool("-", name, value, description);
}