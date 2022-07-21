namespace Parser;

public static class Parse
{
    public static bool ParseToBool(this string str)
    {
        return bool.TryParse(str, out _);
    }
}