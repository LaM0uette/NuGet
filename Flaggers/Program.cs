using System.Text.RegularExpressions;

namespace Flaggers;

public static class Flags
{
    // -b=1 -d 2

    #region Statements

    private const RegexOptions RegOption = RegexOptions.IgnoreCase;
    
    private static string _args = string.Join(" ", Environment.GetCommandLineArgs());

    private static string? _regPattern;

    #endregion
    
    //

    #region Bool

    public static bool Bool(string mode, string name, bool value)
    {
        _regPattern = $"(?:(?<={mode}{name}.)(?:true|false|t|f)|(?<= |^){mode}{name}(?=(?: |$)))";

        var match = Regex.Match(_args, _regPattern, RegOption);

        return match.Success ? !value : value;
    }

    public static bool Bool(string name, bool value) => Bool("-", name, value);

    #endregion
    
    //

    #region String

    public static string String(string mode, string name, string value)
    {
        _regPattern = $"(?<={mode}{name}.).*?(?= |$)";

        var match = Regex.Match(_args, _regPattern, RegOption);

        return match.Success ? match.Value : value;
    }

    public static string String(string name, string value) => String("-", name, value);

    #endregion
}