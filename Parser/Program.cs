namespace Parser;

public static class Parse
{
    public static bool ParseToBool(this string v)
    {
        return bool.Parse(v);
    }
}