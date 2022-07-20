using System.Text.RegularExpressions;

namespace Flaggers;

public static class Flags
{
    // -a=test -b=1 -c test2 -d 2 -e=true -f false -g

    #region Statements

    private const RegexOptions RegOption = RegexOptions.IgnoreCase;
    
    private static string _args = string.Join(" ", Environment.GetCommandLineArgs());

    private static string? _regPattern;

    #endregion
    
    //

    #region Bool

    public static bool Bool(string mode, string name, bool value)
    {
        _regPattern = $"(?<={mode}{name}.)(?:true|false)";

        var match = Regex.Match(_args, _regPattern, RegOption);

        return match.Success ? !value : value;
    }

    public static bool Bool(string name, bool value) =>
        Bool("-", name, value);

    #endregion
}