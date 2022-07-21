namespace Parser;

public static class Parse
{
    public static bool ParseToBool(this string str) => bool.TryParse(str, out _);
    
    public static bool ParseToBool(this byte i) => Convert.ToBoolean(i);
    
    public static bool ParseToBool(this int i) => Convert.ToBoolean(i);
    
    public static bool ParseToChar(this string str) => char.TryParse(str, out _);
}