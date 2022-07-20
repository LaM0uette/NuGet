using System.Text.RegularExpressions;

namespace Flaggers;

public static class Flags
{
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
    
    public static List<string> ListString(string mode, string name, List<string> value)
    {
        _regPattern = $"(?:(?<={mode}{name}.\\[|,)|(?<={mode}{name}.\\[|, ))\\w*(?=,.|\\] |\\]$)";

        var listStr = new List<string>();
        foreach (Match match in Regex.Matches(_args, _regPattern, RegOption))
        {
            listStr.Add(match.Value);
        }
        
        return listStr.Count > 0 ? listStr : value;
    }

    public static List<string> ListString(string name, List<string> value) => ListString("-", name, value);

    #endregion
    
    //
    
    #region Byte

    public static byte Byte(string mode, string name, byte value)
    {
        _regPattern = $"(?<={mode}{name}.).*?(?= |$)";

        var match = Regex.Match(_args, _regPattern, RegOption);

        return match.Success ? byte.Parse(match.Value) : value;
    }

    public static byte Byte(string name, byte value) => Byte("-", name, value);
    
    public static List<byte> ListByte(string mode, string name, List<byte> value)
    {
        _regPattern = $"(?:(?<={mode}{name}.\\[|,)|(?<={mode}{name}.\\[|, ))\\d*(?=,.|\\] |\\]$)";

        var listByte = new List<byte>();
        foreach (Match match in Regex.Matches(_args, _regPattern, RegOption))
        {
            listByte.Add(byte.Parse(match.Value));
        }
        
        return listByte.Count > 0 ? listByte : value;
    }

    public static List<byte> ListByte(string name, List<byte> value) => ListByte("-", name, value);

    #endregion
    
    //
    
    #region Int

    public static int Int(string mode, string name, int value)
    {
        _regPattern = $"(?<={mode}{name}.).*?(?= |$)";

        var match = Regex.Match(_args, _regPattern, RegOption);

        return match.Success ? int.Parse(match.Value) : value;
    }

    public static int Int(string name, int value) => Int("-", name, value);
    
    public static List<int> ListInt(string mode, string name, List<int> value)
    {
        _regPattern = $"(?:(?<={mode}{name}.\\[|,)|(?<={mode}{name}.\\[|, ))\\d*(?=,.|\\] |\\]$)";

        var listInt = new List<int>();
        foreach (Match match in Regex.Matches(_args, _regPattern, RegOption))
        {
            listInt.Add(int.Parse(match.Value));
        }
        
        return listInt.Count > 0 ? listInt : value;
    }

    public static List<int> ListInt(string name, List<int> value) => ListInt("-", name, value);

    #endregion
}